using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Timers;
using System.Windows.Forms;

namespace ZlizEQMap
{
    // It's a big dumb static class that does way too much. I could spend another few days re-engineering it but whatever. It does the job.
    public class CartographyService
    {
        // ~~regexes~~ everyone's favorite
        Regex regExEnteredZone = new Regex(@"^\[.+\] You have entered (.+)\.$", RegexOptions.Compiled);
        Regex regExLocation = new Regex(@"^\[.+\] Your Location is (.+), (.+), .+$", RegexOptions.Compiled);
        Regex regExDirection = new Regex(@"^\[.+\] You think you are heading (.+)\.$", RegexOptions.Compiled);

        // Drawing presets - markers, maps, arrows, etc.
        public List<IMapDrawable> Markers = new List<IMapDrawable>();
        public Pen PlayerPen = new Pen(Color.Red, 2f);
        public Pen PlayerHistoryPen = new Pen(Color.Red, 2f);
        public Pen PlayerPenArrow = new Pen(Color.Red, 2f);
        public Pen WaypointPen = new Pen(Color.Blue, 2f);
        public Pen AnnotationPen = new Pen(Color.Green, 2f);

        // Defaults and presets, hooray
        public int defaultWaypointOffsetValue = 4;
        public int defaultPlayerMarkerOffsetValue = 4;
        public int defaultPlayerCircleOffsetValue = 7;
        public int defaultOrdVal = 7;
        public int defaultInterordVal = 6;
        public int MaxHistoryLocations = 25;

        // Character info and waypoints
        // Note that since there's two types of coordinates:
        //  1. Points, which are raw X/Y values from the log parser. I tried to make sure these were named "[whatever]Coords".
        //  2. MapPoints, which are the points that have been scaled to the map. These are gonna be scaled and weird and unpredictable. I tried to keep these named "[whatever]MapLocation"
        // Hopefully I used the right ones in the right places. God. It's been a weird week.
        public DateTime LastCharacterChange = DateTime.Now.Subtract(TimeSpan.FromMinutes(1));
        public DateTime LastRecordedDirectionDateTime = DateTime.Now;
        public DateTime LastRecordedLocationDateTime = DateTime.Now;
        public DateTime LastRecordedZoneChange = DateTime.Now;
        public Point PlayerCoords;
        public MapPoint PlayerMapLocation = null;
        public MapPoint Waypoint = null;
        public Direction PlayerDirection = Direction.Unknown;

        // Player coordinate history, in raw unscaled values from the logs.
        public List<Point> PlayerCoordsHistory { get; set; } = new List<Point>();

        // Player map location history, in scaled values.
        public List<MapPoint> PlayerMapLocationHistory { get; set; } = new List<MapPoint>();

        // File system stuff. Weehoo.
        public FileSystemWatcher Watcher;
        public LogFileParser Parser;
        
        // Zone and map info.
        public ZoneAnnotationService ZoneAnnotationManager = new ZoneAnnotationService();
        public List<ZoneAnnotation> CurrentZoneAnnotations { get => ZoneAnnotationManager.GetFilteredZoneAnnotations(CurrentZoneData.ShortName, CurrentZoneData.SubMapIndex); }

        public List<ZoneData> Zones;
        public ZoneData CurrentZoneData = null;
        public ZoneMap CurrentZoneMap = null;
        public string CurrentTitle = "";

        // Miscellaneous booleans and state trackers. Gotta have em. 
        public int showZoneAnnotations = 1;
        public bool showPlayerLocationHistory = false;
        public bool timerEnabled = false;
        public bool locationIsWithinMap = false;
        public bool locInZoneHasBeenRecorded = false;
        public bool initialLoadCompleted = false;
        public bool forceLogReselection = false;
        public bool suspendAutoParse = false;

        // Events! We could definitely use these for more stuff. But this one works for now for at least making sure the maps get redrawn.
        public static EventHandler RedrawMapsEH;
        //public static EventHandler ZoneChangedEH;

        public void RaiseRedrawMaps(object sender, EventArgs e)
        {
            RedrawMapsEH?.DynamicInvoke(sender, e);
        }

        // Math stuff, reducing number of redundant calls.
        // Amount of coords per pixel of the map image, on the X axis (horizontal)
        public float ImageYCoordRatio
        {
            get
            {
                //return ((float)CurrentZoneData.TotalY / (float)CurrentZoneMap.ImageY) * renderScale;
                return ((float)CurrentZoneData.TotalY / (float)CurrentZoneMap.ImageY);
            }
        }

        // Amount of coords per pixel of the map image, on the Y axis (vertical)
        public float ImageXCoordRatio
        {
            get
            {
                //return ((float)CurrentZoneData.TotalX / (float)currentZoneMap.ImageX) * renderScale;
                return ((float)CurrentZoneData.TotalX / (float)CurrentZoneMap.ImageX);
            }
        }

        public CartographyService()
        {
            Load();
        }

        private void Load()
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
            PlayerCoordsHistory = new List<Point>();
            showPlayerLocationHistory = Settings.LocHistoryShow;
            
            showZoneAnnotations = Settings.NotesShow;
            AnnotationPen.Color = Settings.NotesColor;
        }

        public void UnLoad()
        {
            Watcher.Dispose();
        }

        private bool HandleSettings()
        {
            if (!Directory.Exists(Paths.SettingsFileDirectory))
                Directory.CreateDirectory(Paths.SettingsFileDirectory);

            if (!Settings.SettingsFileExists)
                return HandleFirstRun();
            else
            {
                Settings.LoadSettings();

                if (!Directory.Exists(Settings.GetEQDirectoryPath()))
                    return HandleFirstRun();

                Zones = ZoneDataFactory.GetAllZones(Settings.GetZoneDataSet());
                return true;
            }
        }

        private bool HandleFirstRun()
        {
            FirstRun form = new FirstRun();
            form.ShowDialog();

            if (form.EQDirectoryValid)
            {
                Settings.InitializeSettings();
                Settings.EQDirectoryPath1 = form.EQDirectory;
                Settings.LogsInLogsDir1 = form.LogsInLogsDir;
                Settings.ZoneDataSet1 = form.ZoneDataSet;
                Settings.SaveSettings();

                return true;
            }
            else
                return false;
        }

        private string GetLogFileDirectory()
        {
            string logFileDirectory = "";

            if (Settings.GetLogsInLogsDir() == SettingsLogsInLogsDir.LogsDir)
                logFileDirectory = Path.Combine(Settings.GetEQDirectoryPath(), "Logs");
            else if (Settings.GetLogsInLogsDir() == SettingsLogsInLogsDir.RootDir)
                logFileDirectory = Settings.GetEQDirectoryPath();

            return logFileDirectory;
        }

        private void SetupFileSystemWatcher()
        {
            string logFileDirectory = GetLogFileDirectory();

            if (Watcher != null)
            {
                Watcher.Dispose();
                Watcher.EnableRaisingEvents = false;
                Parser = null;
            }

            Watcher = new FileSystemWatcher();

            Watcher.Path = logFileDirectory;
            Watcher.Filter = "eqlog_*.txt";
            Watcher.NotifyFilter = NotifyFilters.LastWrite;
            Watcher.Changed += new FileSystemEventHandler(watcher_Changed);
            //Watcher.SynchronizingObject = this;
            Watcher.EnableRaisingEvents = true;
        }

        private void watcher_Changed(object sender, FileSystemEventArgs e)
        {
            // Prevent spam from the FileSystemWatcher - a character change more than every 20 seconds is highly unlikely
            if (DateTime.Now > LastCharacterChange.AddSeconds(5) || forceLogReselection)
            {
                if (Parser == null || e.FullPath != Parser.LogFilePath)
                {
                    Parser = new LogFileParser(e.FullPath);
                    UpdateTitle(CurrentZoneData.FullName);
                    timerEnabled = true;
                    LastCharacterChange = DateTime.Now;
                }
            }

            forceLogReselection = false;
        }

        public void CheckLogParserForNewLines()
        {
            if (Parser == null || suspendAutoParse)
                return;
            
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

        public string OSSwitchToZoneByShortName(string zoneShortName)
        {
            ZoneData zone = ZoneDataFactory.FetchByShortZoneName(Zones, zoneShortName);
            if (zone == null)
                zone = ZoneDataFactory.FetchByShortZoneName(Zones, "POKNOWLEDGE"); // makeit default to something if something goes wrong with the "lastZoneName" value
            if (zone == null)//if still null
                zone = ZoneDataFactory.FetchByShortZoneName(Zones, "ecommons"); // make it default to something else for p99 people maybe?
            OSSwitchToZone(zone.FullName, 1);
            return zone.FullName;
        }

        public bool OSSwitchToZone(string zoneName, int subMapIndex)
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

            CurrentZoneData = zoneData;
            CurrentZoneMap = new ZoneMap(CurrentZoneData.ImageFilePath);
            LastRecordedZoneChange = DateTime.Now;

            UpdateTitle(zoneName);
            RefreshCurrentZoneAnnotations();
            RaiseRedrawMaps(null, null);
            return true;
        }

        public void UpdateTitle(string zoneName)
        {
            if (Parser != null)
                CurrentTitle = String.Format("{0} ({1}) - ZlizEQMap", zoneName, GetActiveCharacterName(Parser.LogFilePath));
            else
                CurrentTitle = String.Format("{0} - ZlizEQMap", zoneName);
        }

        private string GetActiveCharacterName(string logFilePath)
        {
            string logFileName = Path.GetFileNameWithoutExtension(logFilePath);

            int i = logFileName.IndexOf('_') + 1;
            int j = logFileName.LastIndexOf('_');

            return logFileName.Substring(i, j - i);
        }

        public void UpdatePlayerLocation(int x, int y)
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
        public MapPoint GetMapImageLocationPoint(int x, int y)
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

        private bool CheckLocationIsWithinMapImage(int locationXPixel, int locationYPixel, int imageWidth, int imageHeight)
        {
            return (locationXPixel > 0 && locationYPixel > 0 && locationXPixel < imageWidth && locationYPixel < imageHeight);
        }

        public void CharacterNameChange(string characterName)
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

        public void EQDirSettingsChanged()
        {
            Zones = ZoneDataFactory.GetAllZones(Settings.GetZoneDataSet());
            OSSwitchToZoneByShortName(CurrentZoneData.ShortName);
            RaiseRedrawMaps(null, null);
        }

        public void SetWaypoint(int x, int y)
        {
            Waypoint = GetMapImageLocationPoint(x, y);
            RaiseRedrawMaps(null, null);
        }

        public void ClearWaypoint()
        {
            Waypoint = null;
            RaiseRedrawMaps(null, null);
        }

        internal void PrepMapMarkersForCanvas(object sender, PaintEventArgs e, bool useDirectional)
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

            if (showZoneAnnotations != 0 && CurrentZoneAnnotations.Any())
            {
                int aOV = (int)Math.Round(defaultWaypointOffsetValue * renderScale);
                List<MapAnnotation> convertedAnnotations = new List<MapAnnotation>();
                AnnotationPen.Color = Settings.NotesColor;
                int noteIndex = 0;
                foreach (ZoneAnnotation zAnno in CurrentZoneAnnotations.Where(za => za.Show == true))
                {
                    MapPoint zAMP = GetMapImageLocationPoint(zAnno.X, zAnno.Y);

                    if (zAMP != null)
                    {
                        MapEllipse annotationEllipse = new MapEllipse(AnnotationPen, (zAMP.X - aOV), (zAMP.Y - aOV), 2 * aOV, 2 * aOV);
                        string note = showZoneAnnotations == 1 ? zAnno.Note : $"{noteIndex}";
                        MapAnnotation newMapAnno = new MapAnnotation(annotationEllipse, zAMP.X, zAMP.Y, note);

                        convertedAnnotations.Add(newMapAnno);
                    }
                    noteIndex++;
                }

                foreach (MapAnnotation annotation in convertedAnnotations)
                {
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

        private PointSet GetDirectionLinePointSet(float renderScale)
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

        public void TogglePlayerLocationHistory(bool state)
        {
            showPlayerLocationHistory = state;
            RaiseRedrawMaps(null, null);
        }

        public void ToggleZoneAnnotations(int state)
        {
            showZoneAnnotations = state;
            RaiseRedrawMaps(null, null);
        }

        public void UpdateNotesColor(Color color)
        {
            Settings.NotesColor = color;
            RaiseRedrawMaps(null, null);
        }

        public void UpdateNotesFont(Font font)
        {
            Settings.NotesFont = font;
            RaiseRedrawMaps(null, null);
        }

        public void AddNote(string noteText, int x, int y)
        {
            ZoneAnnotationManager.AddNote(new ZoneAnnotation(noteText, x, y, CurrentZoneData.ShortName, CurrentZoneData.SubMapIndex));
            RefreshCurrentZoneAnnotations();
        }

        public void RemoveNote(ZoneAnnotation zoneAnnotation)
        {
            ZoneAnnotationManager.ZoneAnnotations.Remove(zoneAnnotation);
            RefreshCurrentZoneAnnotations();
        }

        public void SaveNotes()
        {
            ZoneAnnotationManager.SaveNotesToFile();
            RefreshCurrentZoneAnnotations();
        }

        public void RefreshCurrentZoneAnnotations()
        {
            CurrentZoneAnnotations.Clear();
            CurrentZoneAnnotations.AddRange(ZoneAnnotationManager.GetFilteredZoneAnnotations(CurrentZoneData.ShortName, CurrentZoneData.SubMapIndex));
            RaiseRedrawMaps(null, null);
        }

        public void ToggleAutoParse(bool autoParseState)
        {
            suspendAutoParse = autoParseState;
        }

        internal void SetParseTimerMS(int newParseInterval)
        {
            Settings.AutoParseIntervalMS = newParseInterval;
        }
    }
}
