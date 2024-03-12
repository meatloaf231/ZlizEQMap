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
    // I probably should've just named this class Cartographer.
    // It's a big overblown static class that does probably too much.
    // Could definitely be organized better.
    public static class Overseer
    {
        // ~~regexes~~ everyone's favorite
        static Regex regExEnteredZone = new Regex(@"^\[.+\] You have entered (.+)\.$", RegexOptions.Compiled);
        static Regex regExLocation = new Regex(@"^\[.+\] Your Location is (.+), (.+), .+$", RegexOptions.Compiled);
        static Regex regExDirection = new Regex(@"^\[.+\] You think you are heading (.+)\.$", RegexOptions.Compiled);

        // Drawing presets - markers, maps, arrows, etc.
        public static List<IMapDrawable> Markers = new List<IMapDrawable>();
        public static Pen PlayerPen = new Pen(Color.Red, 2f);
        public static Pen PlayerHistoryPen = new Pen(Color.Red, 2f);
        public static Pen PlayerPenArrow = new Pen(Color.Red, 2f);
        public static Pen WaypointPen = new Pen(Color.Blue, 2f);
        public static Pen AnnotationPen = new Pen(Color.Green, 2f);

        // Defaults and presets, hooray
        public static int defaultWaypointOffsetValue = 4;
        public static int defaultPlayerMarkerOffsetValue = 4;
        public static int defaultPlayerCircleOffsetValue = 7;
        public static int defaultOrdVal = 7;
        public static int defaultInterordVal = 6;
        public static int MaxHistoryLocations = 25;

        // Character info and waypoints
        // Note that since there's two types of coordinates:
        //  1. Points, which are raw X/Y values from the log parser. I tried to make sure these were named "[whatever]Coords".
        //  2. MapPoints, which are the points that have been scaled to the map. These are gonna be scaled and weird and unpredictable. I tried to keep these named "[whatever]MapLocation"
        // Hopefully I used the right ones in the right places. God. It's been a weird week.
        public static DateTime LastCharacterChange = DateTime.Now.Subtract(TimeSpan.FromMinutes(1));
        public static DateTime LastRecordedDirectionDateTime = DateTime.Now;
        public static DateTime LastRecordedLocationDateTime = DateTime.Now;
        public static Point PlayerCoords;
        public static MapPoint PlayerMapLocation = null;
        public static MapPoint Waypoint = null;
        public static Direction PlayerDirection = Direction.Unknown;

        // Player coordinate history, in raw unscaled values from the logs.
        public static List<Point> PlayerCoordsHistory { get; set; } = new List<Point>();

        // Player map location history, in scaled values.
        public static List<MapPoint> PlayerMapLocationHistory { get; set; } = new List<MapPoint>();

        // File system stuff. Weehoo.
        public static FileSystemWatcher Watcher;
        public static LogFileParser Parser;
        
        // Zone and map info.
        public static List<ZoneData> Zones;
        public static ZoneData CurrentZoneData = null;
        public static ZoneMap CurrentZoneMap = null;
        public static string CurrentTitle = "";

        // Miscellaneous booleans. Gotta have em. 
        public static bool showZoneAnnotations = false;
        public static bool showPlayerLocationHistory = false;
        public static bool timerEnabled = false;
        public static bool locationIsWithinMap = false;
        public static bool locInZoneHasBeenRecorded = false;
        public static bool initialLoadCompleted = false;
        public static bool forceLogReselection = false;

        // Events! We could definitely use these for more stuff. But this one works for now for at least making sure all the maps get redrawn.
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
            ZoneAnnotationManager.InitializeZoneAnnotationManager();

            PlayerPenArrow.CustomEndCap = new AdjustableArrowCap(5, 4);
            AnnotationPen.Color = Settings.NotesColor;
            PlayerCoordsHistory = new List<Point>();
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
            PlayerMapLocation = null;
            PlayerMapLocationHistory.Clear();
            PlayerCoordsHistory.Clear();

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

            MapPoint mapPoint = GetMapImageLocationPoint(x, y);

            if (mapPoint != null)
            {
                if (PlayerCoordsHistory.Count >= MaxHistoryLocations)
                {
                    PlayerCoordsHistory.RemoveAt(PlayerCoordsHistory.Count - 1);
                }
                PlayerCoords = new Point(x, y);
                PlayerCoordsHistory.Insert(0, PlayerCoords);

                if (PlayerMapLocationHistory.Count >= MaxHistoryLocations)
                {
                    PlayerMapLocationHistory.RemoveAt(PlayerMapLocationHistory.Count - 1);
                }

                PlayerMapLocation = mapPoint;
                PlayerMapLocationHistory.Insert(0, PlayerMapLocation);
                locationIsWithinMap = true;
            }
            else
                locationIsWithinMap = false;

            RaiseRedrawMaps(null, null);
        }

        /// <summary>
        /// This is the method that converts raw X/Y data to be "scaled" to the map image itself. 
        /// Any coordinates that are going to be drawn on the map itself need go through this method.
        /// Note that this is NOT the render scaling - that's a per-map-window basis, since a popout map could be sized differently than the main map, so that has to live elsewhere.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static MapPoint GetMapImageLocationPoint(int x, int y)
        {
            int newLocationX = (int)(CurrentZoneData.ZeroLocation.X - ((float)x) / ImageXCoordRatio);
            int newLocationY = (int)(CurrentZoneData.ZeroLocation.Y - ((float)y) / ImageYCoordRatio);

            if (CheckLocationIsWithinMapImage(newLocationX, newLocationY, CurrentZoneMap.ImageX, CurrentZoneMap.ImageY))
            {
                MapPoint point = new MapPoint() { X = newLocationX, Y = newLocationY };
                return point;
            }
            else
                return null;
        }

        private static bool CheckLocationIsWithinMapImage(int locationXPixel, int locationYPixel, int imageWidth, int imageHeight)
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

        internal static void PrepMapMarkersForCanvas(object sender, PaintEventArgs e, bool useDirectional)
        {
            float renderScale = 1F;
            Markers.Clear();

            // Find and add the current player location - circle for off-map, X for precise, arrow for directional.
            if (locInZoneHasBeenRecorded)
            {
                int plCOV = (int)Math.Round(defaultPlayerCircleOffsetValue * renderScale);
                int plMOV = (int)Math.Round(defaultPlayerMarkerOffsetValue * renderScale);

                int plX = PlayerMapLocation != null ? PlayerMapLocation.X : 1;
                int plY = PlayerMapLocation != null ? PlayerMapLocation.Y : 1;

                if (!locationIsWithinMap)
                {
                    // Draw circle indicating that the location was the last successfully recorded (player is probably out of the bounds of the map now)
                    Markers.Add(new MapEllipse(PlayerPen, plX - plCOV, plX - plCOV, 2 * plCOV, 2 * plCOV));
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

                MapEllipse currentWaypoint = new MapEllipse(WaypointPen, (wpX - wpOV), (wpY - wpOV), 2 * wpOV, 2 * wpOV);
                Markers.Add(currentWaypoint);
            }

            if (showZoneAnnotations && ZoneAnnotationManager.ZoneAnnotations.Any())
            {
                int aOV = (int)Math.Round(defaultWaypointOffsetValue * renderScale);

                List<MapAnnotation> convertedAnnotations = new List<MapAnnotation>();
                foreach (ZoneAnnotation zAnno in ZoneAnnotationManager.ZoneAnnotations.Where(za => za.Show == true && za.MapShortName == CurrentZoneData.ShortName && za.SubMap == CurrentZoneData.SubMapIndex))
                {
                    MapPoint zAMP = GetMapImageLocationPoint(zAnno.X, zAnno.Y);

                    if (zAMP != null)
                    {
                        MapEllipse annotationEllipse = new MapEllipse(AnnotationPen, (zAMP.X - aOV), (zAMP.Y - aOV), 2 * aOV, 2 * aOV);
                        MapAnnotation newMapAnno = new MapAnnotation(annotationEllipse, zAMP.X, zAMP.Y, zAnno.Note);

                        convertedAnnotations.Add(newMapAnno);
                    }
                }

                foreach (MapAnnotation annotation in convertedAnnotations)
                {
                    Console.WriteLine($"{annotation.X} {annotation.Y} {annotation.Note}");
                    Markers.Add(annotation);
                }
            }

            // Get the player location history line
            // We do need more than one point to make a line, it turns out
            if (showPlayerLocationHistory && PlayerMapLocationHistory.Count >= 2)
            {
                int fullTransparency = 255;
                int transparencyIncrement = fullTransparency / MaxHistoryLocations;
                int currentTransparency = fullTransparency;

                for (int i = 0; i < Math.Min(MaxHistoryLocations, PlayerMapLocationHistory.Count - 1); i++)
                {
                    Point p1 = new Point(PlayerMapLocationHistory[i].X, PlayerMapLocationHistory[i].Y);
                    Point p2 = new Point(PlayerMapLocationHistory[i+1].X, PlayerMapLocationHistory[i+1].Y);

                    Markers.Add(new MapLine(new Pen(Color.FromArgb(currentTransparency, PlayerHistoryPen.Color)), p1, p2));
                    currentTransparency = Math.Max(currentTransparency - transparencyIncrement, 1);
                }
            }
        }

        private static PointSet GetDirectionLinePointSet(float renderScale)
        {
            int ordVal = (int)Math.Round(defaultOrdVal * renderScale);
            int interordVal = (int)Math.Round(defaultInterordVal * renderScale);

            int plX = PlayerMapLocation.X;
            int plY = PlayerMapLocation.Y;

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

        public static void TogglePlayerLocationHistory(bool state)
        {
            showPlayerLocationHistory = state;
            RaiseRedrawMaps(null, null);
        }

        public static void ToggleZoneAnnotations(bool state)
        {
            showZoneAnnotations = state;
            RaiseRedrawMaps(null, null);
        }

        public static void UpdateNotesColor(Color color)
        {
            Settings.NotesColor = color;
            RaiseRedrawMaps(null, null);
        }

        public static void UpdateNotesFont(Font font)
        {
            Settings.NotesFont = font;
            RaiseRedrawMaps(null, null);
        }
    }
}
