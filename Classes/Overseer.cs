using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ZlizEQMap
{
    public static class Overseer
    {
        static Regex regExEnteredZone = new Regex(@"^\[.+\] You have entered (.+)\.$", RegexOptions.Compiled);
        static Regex regExLocation = new Regex(@"^\[.+\] Your Location is (.+), (.+), .+$", RegexOptions.Compiled);
        static Regex regExDirection = new Regex(@"^\[.+\] You think you are heading (.+)\.$", RegexOptions.Compiled);

        // Drawing presets
        public static List<IMapMarker> Markers = new List<IMapMarker>();
        //public static List<IMapMarker> PlayerCoordinates = new List<IMapMarker>();
        //public static List<IMapMarker> Waypoints = new List<IMapMarker>();
        //public static List<IMapMarker> MapNotes = new List<IMapMarker>();

        public static Pen PlayerPen = new Pen(Color.Red, 2f);
        public static Pen PlayerPenArrow = new Pen(Color.Red, 2f);
        public static Pen WaypointPen = new Pen(Color.Blue, 2f);
        public static int defaultWaypointOffsetValue = 4;
        public static int defaultPlayerMarkerOffsetValue = 4;
        public static int defaultPlayerCircleOffsetValue = 7;
        public static int defaultOrdVal = 7;
        public static int defaultInterordVal = 6;
        public static int maxMarkers = 5;

        // Character info and waypoints
        public static DateTime LastCharacterChange = DateTime.Now.Subtract(TimeSpan.FromMinutes(1));
        public static DateTime LastRecordedDirectionDateTime = DateTime.Now;
        public static DateTime LastRecordedLocationDateTime = DateTime.Now;
        public static MapPoint PlayerLocation = null;
        public static MapPoint Waypoint = null;
        public static Direction PlayerDirection = Direction.Unknown;

        // File system stuff
        public static FileSystemWatcher Watcher;
        public static LogFileParser Parser;
        
        // Zone and map info
        public static List<ZoneData> Zones;
        public static ZoneData CurrentZoneData = null;
        public static ZoneMap CurrentZoneMap = null;

        public static string CurrentTitle = "";

        // Miscellaneous booleans
        public static bool timerEnabled = false;
        public static bool locationIsWithinMap = false;
        public static bool locInZoneHasBeenRecorded = false;
        public static bool initialLoadCompleted = false;
        public static bool forceLogReselection = false;

        public static EventHandler RedrawMaps;

        public static void RaiseRedrawMaps(object sender, EventArgs e)
        {
            RedrawMaps?.DynamicInvoke(sender, e);
        }

        // Math stuff, reducing number of redundant calls.
        // Amount of coords per pixel of the map image, on the X axis (horizontal)
        public static float ImageYCoordRatio
        {
            get
            {
                //return ((float)CurrentZoneData.TotalY / (float)CurrentZoneMap.ImageY) * renderScale;
                return ((float)CurrentZoneData.TotalY / (float)CurrentZoneMap.ImageY);
            }
        }

        // Amount of coords per pixel of the map image, on the Y axis (vertical)
        public static float ImageXCoordRatio
        {
            get
            {
                //return ((float)CurrentZoneData.TotalX / (float)currentZoneMap.ImageX) * renderScale;
                return ((float)CurrentZoneData.TotalX / (float)CurrentZoneMap.ImageX);
            }
        }

        public static void InitializeOverseer()
        {
            Load();
            // OVERSEER ONLINE
        }

        private static void Load()
        {
            if (HandleSettings())
            {
                string logFileDirectory = GetLogFileDirectory();

                if (!Directory.Exists(logFileDirectory))
                {
                    MessageBox.Show(String.Format("Log file directory '{0}' does not exist. Ensure the log file directory exists at this location.", logFileDirectory), "ZlizEQMap", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(1);
                }
            }
            else
            {
                Environment.Exit(0);
            }

            // Okay, we loaded fine, set the rest up now.
            SetupFileSystemWatcher();
            PlayerPenArrow.CustomEndCap = new AdjustableArrowCap(5, 4);
        }

        public static void UnLoad()
        {
            Watcher.Dispose();
        }

        private static bool HandleSettings()
        {
            if (!Directory.Exists(Paths.SettingsFileDirectory))
                Directory.CreateDirectory(Paths.SettingsFileDirectory);

            if (!Settings.SettingsFileExists)
                return HandleFirstRun(true);
            else
            {
                Settings.LoadSettings();

                if (!Directory.Exists(Settings.GetEQDirectoryPath()))
                    return HandleFirstRun(false);

                Zones = ZoneDataFactory.GetAllZones(Settings.GetZoneDataSet());
                return true;
            }
        }

        private static bool HandleFirstRun(bool initializeDefaultSettings)
        {
            FirstRun form = new FirstRun();
            form.ShowDialog();

            if (form.EQDirectoryValid)
            {
                if (initializeDefaultSettings)
                    Settings.InitializeDefaultSettings();

                Settings.EQDirectoryPath1 = form.EQDirectory;
                Settings.LogsInLogsDir1 = form.LogsInLogsDir;
                Settings.ZoneDataSet1 = form.ZoneDataSet;
                Settings.SaveSettings();

                return true;
            }
            else
                return false;
        }

        private static string GetLogFileDirectory()
        {
            string logFileDirectory = "";

            if (Settings.GetLogsInLogsDir() == SettingsLogsInLogsDir.LogsDir)
                logFileDirectory = Path.Combine(Settings.GetEQDirectoryPath(), "Logs");
            else if (Settings.GetLogsInLogsDir() == SettingsLogsInLogsDir.RootDir)
                logFileDirectory = Settings.GetEQDirectoryPath();

            return logFileDirectory;
        }

        private static void SetupFileSystemWatcher()
        {
            string logFileDirectory = GetLogFileDirectory();

            if (Watcher != null)
            {
                Watcher.Dispose();
                Watcher.EnableRaisingEvents = false;
                Parser = null;
                //timer1.Enabled = false;
            }

            Watcher = new FileSystemWatcher();

            Watcher.Path = logFileDirectory;
            Watcher.Filter = "eqlog_*.txt";
            Watcher.NotifyFilter = NotifyFilters.LastWrite;
            Watcher.Changed += new FileSystemEventHandler(watcher_Changed);
            //watcher.SynchronizingObject = this;
            Watcher.EnableRaisingEvents = true;
        }

        private static void watcher_Changed(object sender, FileSystemEventArgs e)
        {
            // Prevent spam from the FileSystemWatcher - a character change more than every 20 seconds is highly unlikely
            if (DateTime.Now > LastCharacterChange.AddSeconds(5) || forceLogReselection)
            {
                if (Parser == null || e.FullPath != Parser.LogFilePath)
                {
                    Parser = new LogFileParser(e.FullPath);
                    //SetFormTitle(CurrentZoneData.FullName);
                    //timer1.Enabled = true;
                    timerEnabled = true;
                    LastCharacterChange = DateTime.Now;
                }
            }

            forceLogReselection = false;
        }

        public static void TimerTick(object sender, EventArgs e)
        {
            Direction direction = Direction.Unknown;
            int? locx = null;
            int? locy = null;

            string zone = null;

            List<string> lines = Parser.GetNewLines();
            lines.Reverse();

            foreach (string line in lines)
            {
                Match matchZone = regExEnteredZone.Match(line);

                if (zone == null && matchZone.Groups[1].Value != "an Arena (PvP) area" && matchZone.Success)
                    zone = matchZone.Groups[1].Value;

                Match matchDirection = regExDirection.Match(line);

                if (direction == Direction.Unknown && matchDirection.Success)
                    direction = (Direction)Enum.Parse(typeof(Direction), matchDirection.Groups[1].Value);

                if (zone != null || CurrentZoneData != null)
                {
                    Match matchLocation = regExLocation.Match(line);

                    if (locx == null && matchLocation.Success)
                    {
                        string locxString = matchLocation.Groups[2].Value;
                        string locyString = matchLocation.Groups[1].Value;

                        locxString = locxString.Substring(0, locxString.IndexOf('.'));
                        locyString = locyString.Substring(0, locyString.IndexOf('.'));

                        locx = Convert.ToInt32(locxString);
                        locy = Convert.ToInt32(locyString);
                    }
                }

                if (zone != null && direction != Direction.Unknown && locx != null)
                    break;
            }

            if (!String.IsNullOrEmpty(zone))
                OSSwitchToZone(zone, 1);

            if (direction != Direction.Unknown)
            {
                PlayerDirection = direction;
                LastRecordedDirectionDateTime = DateTime.Now;
            }

            if (locx.HasValue)
                UpdatePlayerLocation(Convert.ToInt32(locx.Value), Convert.ToInt32(locy.Value));
        }

        public static string OSSwitchToZoneByShortName(string zoneShortName)
        {
            ZoneData zone = ZoneDataFactory.FetchByShortZoneName(Zones, zoneShortName);
            if (zone == null)
                zone = ZoneDataFactory.FetchByShortZoneName(Zones, "POKNOWLEDGE"); // makeit default to something if something goes wrong with the "lastZoneName" value
            if (zone == null)//if still null
                zone = ZoneDataFactory.FetchByShortZoneName(Zones, "ecommons"); // make it default to something else for p99 people maybe?
            OSSwitchToZone(zone.FullName, 1);
            return zone.FullName;
        }

        public static bool OSSwitchToZone(string zoneName, int subMapIndex)
        {
            locInZoneHasBeenRecorded = false;
            Waypoint = null;
            PlayerLocation = null;

            ZoneData zoneData = ZoneDataFactory.FetchByFullZoneName(Zones, zoneName, subMapIndex);
            if (zoneData == null)
            {
                return false;
            }

            UpdateTitle(zoneName);
            
            CurrentZoneData = zoneData;
            CurrentZoneMap = new ZoneMap(CurrentZoneData);

            return true;
        }

        public static void UpdateTitle(string zoneName)
        {
            if (Parser != null)
                CurrentTitle = String.Format("{0} ({1}) - ZlizEQMap", zoneName, GetActiveCharacterName(Parser.LogFilePath));
            else
                CurrentTitle = String.Format("{0} - ZlizEQMap", zoneName);
            RaiseRedrawMaps(null, null);
        }

        private static string GetActiveCharacterName(string logFilePath)
        {
            string logFileName = Path.GetFileNameWithoutExtension(logFilePath);

            int i = logFileName.IndexOf('_') + 1;
            int j = logFileName.LastIndexOf('_');

            return logFileName.Substring(i, j - i);
        }

        public static void UpdatePlayerLocation(int x, int y)
        {
            locInZoneHasBeenRecorded = true;
            LastRecordedLocationDateTime = DateTime.Now;

            MapPoint point = GetMapImageLocationPoint(x, y);

            if (point != null)
            {
                PlayerLocation = point;
                locationIsWithinMap = true;
            }
            else
                locationIsWithinMap = false;

            RaiseRedrawMaps(null, null);
        }

        public static MapPoint GetMapImageLocationPoint(int x, int y)
        {
            int newLocationXPixel = (int)(CurrentZoneData.ZeroLocation.X - ((float)x) / ImageXCoordRatio);
            int newLocationYPixel = (int)(CurrentZoneData.ZeroLocation.Y - ((float)y) / ImageYCoordRatio);

            //int rawscaledX = (int)(newLocationXPixelUnscaled * renderScale);
            //int rawscaledY = (int)(newLocationYPixelUnscaled * renderScale);

            if (PlayerLocationIsWithinMapImage(newLocationXPixel, newLocationYPixel, CurrentZoneMap.ImageX, CurrentZoneMap.ImageY))
            {
                MapPoint point = new MapPoint() { X = newLocationXPixel, Y = newLocationYPixel };
                return point;
            }
            else
                return null;
        }

        private static bool PlayerLocationIsWithinMapImage(int locationXPixel, int locationYPixel, int imageHeight, int imageWidth)
        {
            return (locationXPixel > 0 && locationYPixel > 0 && locationXPixel < imageWidth && locationYPixel < imageHeight);
        }

        public static void CharacterNameChange(string characterName)
        {
            string charNameFilter = "";

            if (string.IsNullOrWhiteSpace(charNameFilter))
            {
                Watcher.Filter = string.Format("eqlog_*.txt");
            }
            else
            {
                Watcher.Filter = string.Format("eqlog_{0}.txt", charNameFilter);
            }

            forceLogReselection = true;
            RaiseRedrawMaps(null, null);
        }

        public static void EQDirSettingsChanged()
        {
            Zones = ZoneDataFactory.GetAllZones(Settings.GetZoneDataSet());
            OSSwitchToZoneByShortName(CurrentZoneData.ShortName);
            RaiseRedrawMaps(null, null);
        }

        public static void SetWaypoint(int x, int y)
        {
            Waypoint = GetMapImageLocationPoint(x, y);
            RaiseRedrawMaps(null, null);
        }

        public static void ClearWaypoint()
        {
            Waypoint = null;
            RaiseRedrawMaps(null, null);
        }

        internal static void PaintPlease(object sender, PaintEventArgs e, bool useDirectional)
        {
            float renderScale = 1F;

            if (locInZoneHasBeenRecorded)
            {
                int plCOV = (int)Math.Round(defaultPlayerCircleOffsetValue * renderScale);
                int plMOV = (int)Math.Round(defaultPlayerMarkerOffsetValue * renderScale);

                int plX = PlayerLocation.X;
                int plY = PlayerLocation.Y;

                if (!locationIsWithinMap)
                {
                    // Draw circle indicating that the location was the last successfully recorded (player is probably out of the bounds of the map now)
                    if (PlayerLocation != null)
                        Markers.Add(new MapEllipse(PlayerPen, plX - plCOV, plX - plCOV, 2 * plCOV, 2 * plCOV));
                    else
                        Markers.Add(new MapEllipse(PlayerPen, 1, 1, 2 * plCOV, 2 * plCOV));
                }
                else
                {
                    if (PlayerDirection == Direction.Unknown || !useDirectional || LastRecordedLocationDateTime - LastRecordedDirectionDateTime > TimeSpan.FromMilliseconds(1500))
                    {
                        // Draw player location X
                        MapLine XLine1 = new MapLine(PlayerPen, new Point(plX - plMOV, plY - plMOV), new Point(plX + plMOV, plY + plMOV));
                        MapLine XLine2 = new MapLine(PlayerPen, new Point(plX + plMOV, plY - plMOV), new Point(plX - plMOV, plY + plMOV));

                        Markers.Add(new MapCross(PlayerPen, XLine1, XLine2));
                    }
                    else if (LastRecordedLocationDateTime - LastRecordedDirectionDateTime <= TimeSpan.FromMilliseconds(1500))
                    {
                        PointSet pointSet = GetDirectionLinePointSet(renderScale);
                        Markers.Add(new MapLine(PlayerPenArrow, pointSet.Point1, pointSet.Point2));
                    }
                }
            }

            if (Waypoint != null)
            {
                int wpOV = (int)Math.Round(defaultWaypointOffsetValue * renderScale);
                int wpX = Waypoint.X;
                int wpY = Waypoint.Y;

                Markers.Add(new MapEllipse(WaypointPen, (wpX - wpOV), (wpY - wpOV), 2 * wpOV, 2 * wpOV));
            }

            int fullTransparency = 255;
            int transparencyIncrement = fullTransparency / maxMarkers;
            int currentTransparency = fullTransparency;

            int markerCap = Math.Min(maxMarkers, Markers.Count);

            for (int markerCounter = 0; markerCounter < markerCap; markerCounter++)
            {
                Markers[markerCounter].Pen = new Pen(Color.FromArgb(100, Color.Aqua));
                currentTransparency = Math.Max(0, currentTransparency - transparencyIncrement);
            }
        }

        private static PointSet GetDirectionLinePointSet(float renderScale)
        {
            int ordVal = (int)Math.Round(defaultOrdVal * renderScale);
            int interordVal = (int)Math.Round(defaultInterordVal * renderScale);

            int plX = PlayerLocation.X;
            int plY = PlayerLocation.Y;

            switch (PlayerDirection)
            {
                case Direction.North:
                    return new PointSet() { Point1 = new Point(plX, plY + ordVal), Point2 = new Point(plX, plY - ordVal) };
                case Direction.NorthEast:
                    return new PointSet() { Point1 = new Point(plX - interordVal, plY + interordVal), Point2 = new Point(plX + interordVal, plY - interordVal) };
                case Direction.East:
                    return new PointSet() { Point1 = new Point(plX - ordVal, plY), Point2 = new Point(plX + ordVal, plY) };
                case Direction.SouthEast:
                    return new PointSet() { Point1 = new Point(plX - interordVal, plY - interordVal), Point2 = new Point(plX + interordVal, plY + interordVal) };
                case Direction.South:
                    return new PointSet() { Point1 = new Point(plX, plY - ordVal), Point2 = new Point(plX, plY + ordVal) };
                case Direction.SouthWest:
                    return new PointSet() { Point1 = new Point(plX + interordVal, plY - interordVal), Point2 = new Point(plX - interordVal, plY + interordVal) };
                case Direction.West:
                    return new PointSet() { Point1 = new Point(plX + ordVal, plY), Point2 = new Point(plX - ordVal, plY) };
                case Direction.NorthWest:
                    return new PointSet() { Point1 = new Point(plX + interordVal, plY + interordVal), Point2 = new Point(plX - interordVal, plY - interordVal) };

                default:
                    throw new Exception("Unhandled playerDirection");
            }
        }

        //private static void RegisterPicBoxForInvalidation(PictureBox picBox)
        //{
        //    SettingsHelp settingsHelp = new SettingsHelp();
        //    settingsHelp.OnEQDirSettingsChanged += new EventHandler(settingsHelp_OnEQDirSettingsChanged);
        //    settingsHelp.ShowDialog();
        //}

        //void settingsHelp_OnEQDirSettingsChanged(object sender, EventArgs e)
        //{
        //    zones = ZoneDataFactory.GetAllZones(Settings.GetZoneDataSet());
        //    Initialize();
        //    SwitchZoneByShortName(currentZoneData.ShortName);
        //}
    }
}
