using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Drawing2D;
using TheArtOfDev.HtmlRenderer.WinForms;
using System.Threading;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Configuration;

namespace ZlizEQMap
{
    public partial class ZlizEQMapFormExperimental : Form
    {
        DateTime LastRecordedZoneChange = DateTime.Now;

        bool initialLoadCompleted = false;
        int flowSubMapssubMapsTotalHeight = 1;
        float renderScale = 1.0F;
        public static Dictionary<PictureBox, ZoneData> subMapPictureBoxes = new Dictionary<PictureBox, ZoneData>();
        PopoutMap popoutMap;

        public ZlizEQMapFormExperimental()
        {
            InitializeComponent();
            SetControlProperties();
            Initialize();
        }

        private void Initialize()
        {
            PopulateZoneComboBox();
            SetControlsFromSettings();

            Overseer.OSSwitchToZoneByShortName(Settings.LastSelectedZone);
            ZoneChangedUpdateUI();

            Overseer.RedrawMaps += ZlizEQMapFormExperimental_OverseerSaysRedraw;

            initialLoadCompleted = true;

            if (checkAutoSizeOnMapSwitch.Checked)
                AutoSizeForm();

            dgv_ZoneAnnotation.DataSource = zoneAnnotationBindingSource;
            dgv_ZoneAnnotation.AutoGenerateColumns = false;
            dgv_ZoneAnnotation.AutoSize = false;

            ReloadNoteData();

            btnAutosize.Select();
            picBox.Invalidate();
        }

        private void ZlizEQMapFormExperimental_OverseerSaysRedraw(object sender, EventArgs e)
        {
            picBox.Invalidate();
        }

        private void SetControlsFromSettings()
        {
            checkAutoSizeOnMapSwitch.Checked = Settings.CheckAutoSizeOnMapSwitch;
            checkGroupByContinent.Checked = Settings.CheckGroupByContinent;
            checkEnableDirection.Checked = Settings.CheckEnableDirection;
            checkLegend.Checked = Settings.CheckEnableLegend;
            
            sliderOpacity.Value = Settings.OpacityLevel;
            SetFormOpacity();
            
            checkAlwaysOnTop.Checked = Settings.AlwaysOnTop;
            SetAlwaysOnTop();

            check_AutoUpdateNoteLocation.Checked = Settings.NotesAutoUpdate;
            check_ClearNoteAfterEntry.Checked = Settings.NotesClearAfterEntry;
            check_ShowAnnotations.CheckState = (CheckState)Settings.NotesShow;
            check_ShowPlayerLocHistory.Checked = Settings.LocHistoryShow;
            
            nud_HistoryToKeep.Value = Settings.LocHistoryNumberToTrack;
            button_NotesFont.Font = Settings.NotesFont;
            button_NotesColor.BackColor = Settings.NotesColor;
        }

        private void PopulateZoneComboBox()
        {
            comboZone.Items.Clear();

            if (!checkGroupByContinent.Checked)
            {
                foreach (ZoneData map in Overseer.Zones.Where(x => x.SubMapIndex == 1).OrderBy(x => x.FullName))
                {
                    comboZone.Items.Add(map.FullName);
                }
            }
            else
            {
                List<string> continents = new List<string>();

                foreach (ZoneData map in Overseer.Zones.OrderBy(x => x.ContinentSortOrder))
                {
                    if (!continents.Contains(map.Continent))
                        continents.Add(map.Continent);
                }

                foreach (string continent in continents)
                {
                    comboZone.Items.Add(String.Format("-------------------- {0} --------------------", continent));

                    foreach (ZoneData map in Overseer.Zones.Where(x => x.Continent == continent && x.SubMapIndex == 1).OrderBy(x => x.FullName))
                    {
                        comboZone.Items.Add(map.FullName);
                    }
                }
            }

            if (Overseer.CurrentZoneData != null)
                comboZone.SelectedItem = Overseer.CurrentZoneData.FullName;
        }

        private void SetFormTitle(string newTitle)
        {
            this.Text = newTitle;
        }

        private void ZoneChangedUpdateUI()
        {
            labelZoneName.Text = Overseer.CurrentZoneData.FullName;
            picBox.Load(Overseer.CurrentZoneData.ImageFilePath);
            SetFormTitle(Overseer.CurrentZoneData.FullName);
            PopulateSubMaps(Overseer.CurrentZoneData);
            comboZone.SelectedItem = Overseer.CurrentZoneData.FullName;
            labelLegend.Text = LegendTextFactory.GetLegendText(Overseer.CurrentZoneData);

            PopulateConnectedZones();
            SetButtonWaypointText();
            ReloadNoteData();

            if (checkAutoSizeOnMapSwitch.Checked)
                AutoSizeForm();
        }

        private void SwitchZone(string zoneName, int subMapIndex)
        {
            if (!Overseer.OSSwitchToZone(zoneName, subMapIndex))
            {
                MessageBox.Show(String.Format("Unable to find zone '{0}' in Zone Data", zoneName), "ZlizEQMap", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ZoneChangedUpdateUI();
        }

        private void PopulateConnectedZones()
        {
            if (Overseer.CurrentZoneData.ConnectedZones.Count > 0)
            {
                panelConnectedZones.Visible = true;
                panelConnectedZones.Controls.Clear();
                panelConnectedZones.Controls.Add(labelConnectedZones);
                panelConnectedZones.Text = "Connected Zones:";

                foreach (ZoneData zone in Overseer.CurrentZoneData.ConnectedZones.OrderBy(x => x.FullName))
                {
                    LinkLabel ll = new LinkLabel();
                    ll.Text = zone.FullName;
                    ll.AutoSize = true;
                    ll.Name = zone.FullName;
                    ll.LinkClicked += new LinkLabelLinkClickedEventHandler(ll_LinkClicked);

                    this.panelConnectedZones.Controls.Add(ll);
                }
            }
            else
                panelConnectedZones.Visible = false;
        }

        void ll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SwitchZone((sender as LinkLabel).Text, 1);
        }

        private void PopulateSubMaps(ZoneData zoneData)
        {
            flowSubMaps.Controls.Clear();
            subMapPictureBoxes.Clear();
            flowSubMaps.Height = 1;
            flowSubMaps.Visible = false;
            var subZones = Overseer.Zones.Where(x => x.FullName == zoneData.FullName);
            int i = 0;

            if (subZones.Count() > 1)
            {
                foreach (ZoneData zone in subZones.OrderBy(x => x.SubMapIndex))
                {
                    Color borderColor = Color.Transparent;

                    if (zone.SubMapIndex == zoneData.SubMapIndex)
                        borderColor = Color.MediumPurple;

                    ZlizPanel panel = new ZlizPanel(borderColor);
                    panel.Size = new System.Drawing.Size(102, 102);
                    panel.Location = new Point(0, i++ * 101);

                    ZlizPictureBox pb = new ZlizPictureBox();
                    pb.SizeMode = PictureBoxSizeMode.StretchImage;
                    pb.WaitOnLoad = true;
                    pb.Load(zone.ImageFilePath);
                    pb.Size = new System.Drawing.Size(100, 100);
                    pb.Location = new Point(1, 1);
                    pb.Click += new EventHandler(pb_Click);
                    pb.MouseHover += new EventHandler(pb_MouseHover);
                    pb.SubMapDescription = zone.SubMapDescription;

                    panel.Controls.Add(pb);

                    flowSubMaps.Controls.Add(panel);
                    subMapPictureBoxes.Add(pb, zone);
                }

                flowSubMapssubMapsTotalHeight = i * 110;
                ReCalcFlowSubMapsHeight();
                flowSubMaps.Visible = true;
            }
        }

        void pb_Click(object sender, EventArgs e)
        {
            PictureBox pb = (sender as PictureBox);

            ZoneData zoneData = subMapPictureBoxes[pb];

            SwitchZone(zoneData.FullName, zoneData.SubMapIndex);
        }

        void pb_MouseHover(object sender, EventArgs e)
        {
            ZlizPictureBox pb = sender as ZlizPictureBox;

            if (pb.SubMapDescription != null)
            {
                ToolTip tt = new ToolTip() { InitialDelay = 200 };

                tt.SetToolTip(pb, pb.SubMapDescription);
            }
        }

        private void picBox_Paint(object sender, PaintEventArgs e)
        {
            if (LastRecordedZoneChange < Overseer.LastRecordedZoneChange)
            {
                ZoneChangedUpdateUI();
            }

            Overseer.PrepMapMarkersForCanvas(sender, e, checkEnableDirection.Checked);

            foreach (IMapDrawable marker in Overseer.Markers)
            {
                marker.Draw(e.Graphics, renderScale);
            }

            //if (Overseer.locInZoneHasBeenRecorded)
            //{
            //    int playerCircleOffsetValue = (int)Math.Round(Overseer.defaultPlayerCircleOffsetValue * renderScale);
            //    int playerMarkerOffsetValue = (int)Math.Round(Overseer.defaultPlayerMarkerOffsetValue * renderScale);

            //    int plX = Overseer.PlayerLocation.X;
            //    int plY = Overseer.PlayerLocation.Y;

            //    if (!Overseer.locationIsWithinMap)
            //    {
            //        // Draw circle indicating that the location was the last successfully recorded (player is probably out of the bounds of the map now)
            //        if (Overseer.PlayerLocation != null)
            //            e.Graphics.DrawEllipse(
            //                Overseer.PlayerPen,
            //                plX - playerCircleOffsetValue,
            //                plX - playerCircleOffsetValue, 
            //                2 * playerCircleOffsetValue, 
            //                2 * playerCircleOffsetValue);
            //        else
            //            e.Graphics.DrawEllipse(Overseer.PlayerPen, 1, 1, 2 * playerCircleOffsetValue, 2 * playerCircleOffsetValue);
            //    }
            //    else
            //    {
            //        if (Overseer.PlayerDirection == Direction.Unknown || !checkEnableDirection.Checked || Overseer.LastRecordedLocationDateTime - Overseer.LastRecordedDirectionDateTime > TimeSpan.FromMilliseconds(1500))
            //        {
            //            // Draw player location X
            //            e.Graphics.DrawLine(
            //                Overseer.PlayerPen, 
            //                new Point(plX - playerMarkerOffsetValue, plY - playerMarkerOffsetValue), 
            //                new Point(plX + playerMarkerOffsetValue, plY + playerMarkerOffsetValue));

            //            e.Graphics.DrawLine(
            //                Overseer.PlayerPen, 
            //                new Point(plX + playerMarkerOffsetValue, plY - playerMarkerOffsetValue), 
            //                new Point(plX - playerMarkerOffsetValue, plY + playerMarkerOffsetValue));
            //        }
            //        else if (Overseer.LastRecordedLocationDateTime - Overseer.LastRecordedDirectionDateTime <= TimeSpan.FromMilliseconds(1500))
            //        {
            //            PointSet pointSet = GetDirectionLinePointSet();
            //            e.Graphics.DrawLine(Overseer.PlayerPenArrow, pointSet.Point1, pointSet.Point2);
            //        }
            //    }
            //}

            //if (Overseer.Waypoint != null)
            //{
            //    int waypointOffsetValue = (int)Math.Round(Overseer.defaultWaypointOffsetValue * renderScale);
            //    e.Graphics.DrawEllipse(Overseer.WaypointPen, (Overseer.Waypoint.X - waypointOffsetValue), (Overseer.Waypoint.Y - waypointOffsetValue), 2 * waypointOffsetValue, 2 * waypointOffsetValue);
            //}
        }

        private void checkEnableDirection_CheckedChanged(object sender, EventArgs e)
        {
            Overseer.RaiseRedrawMaps(null, null);
        }

        private void checkLegend_CheckedChanged(object sender, EventArgs e)
        {
            labelLegend.Visible = checkLegend.Checked;

            if (checkAutoSizeOnMapSwitch.Checked)
                AutoSizeForm();
        }

        private void checkGroupByContinent_CheckedChanged(object sender, EventArgs e)
        {
            if (initialLoadCompleted)
                PopulateZoneComboBox();
        }

        private void comboZone_DropDownClosed(object sender, EventArgs e)
        {
            if (!comboZone.SelectedItem.ToString().StartsWith("-") && initialLoadCompleted)
                SwitchZone(comboZone.SelectedItem.ToString(), 1);
        }

        private void btnAutosize_Click(object sender, EventArgs e)
        {
            AutoSizeForm();
        }

        private void AutoSizeForm()
        {
            if (initialLoadCompleted)
            {
                int width = 1025;
                if (picBox.Width + 60 > width)
                    width = picBox.Width + 70;

                var subMaps = Overseer.Zones.Where(x => x.FullName == Overseer.CurrentZoneData.FullName);

                if (subMaps.Count() > 1)
                    width += flowSubMaps.Width;

                //this.Width = width;

                int legendHeight = labelLegend.Height;

                if (!checkLegend.Checked)
                    legendHeight = 10;

                int height = labelZoneName.Height + picBox.Height + legendHeight + 105;

                Rectangle working = Screen.GetWorkingArea(this.picBox);
                if (height > working.Height - 100)
                    height = working.Height - 100;

                this.Height = height;
            }
        }

        private void ZlizEQMapFormExperimental_FormClosing(object sender, FormClosingEventArgs e)
        {
            Overseer.UnLoad();

            Settings.CheckAutoSizeOnMapSwitch = checkAutoSizeOnMapSwitch.Checked;
            Settings.CheckEnableDirection = checkEnableDirection.Checked;
            Settings.CheckEnableLegend = checkLegend.Checked;
            Settings.CheckGroupByContinent = checkGroupByContinent.Checked;

            if (Overseer.CurrentZoneData != null)
                Settings.LastSelectedZone = Overseer.CurrentZoneData.ShortName;

            Settings.OpacityLevel = sliderOpacity.Value;
            Settings.AlwaysOnTop = checkAlwaysOnTop.Checked;

            Settings.SaveSettings();
        }

        private void ReCalcFlowSubMapsHeight()
        {
            //so we don't hide icons offscren if map is taller than window
            flowSubMaps.Height = Math.Min(flowSubMapssubMapsTotalHeight, panelMain.Height); //check size of number of SubMaps vs main map height 
            flowSubMaps.Height = Math.Min(flowSubMaps.Height, this.Height); //so we don't hide icons offscren if map is taller than window
        }

        private void ZlizEQMapFormExperimental_SizeChanged(object sender, EventArgs e)
        {

            ReCalcFlowSubMapsHeight();

            //labelLegend.MaximumSize = new Size(this.Width - 50, 1000000);
        }

        private void linkLabelWiki_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(String.Format("{0}{1}", Settings.WikiRootURL, Overseer.CurrentZoneData.FullName));
        }

        private void btnSettingsHelp_Click(object sender, EventArgs e)
        {
            SettingsHelp settingsHelp = new SettingsHelp();
            settingsHelp.OnEQDirSettingsChanged += new EventHandler(settingsHelp_OnEQDirSettingsChanged);

            settingsHelp.ShowDialog();
        }

        void settingsHelp_OnEQDirSettingsChanged(object sender, EventArgs e)
        {
            Overseer.EQDirSettingsChanged();
            Initialize();
        }

        private void sliderOpacity_Scroll(object sender, EventArgs e)
        {
            SetFormOpacity();
        }

        private void SetFormOpacity()
        {
            this.Opacity = sliderOpacity.Value * 5 / 100f;
        }

        private void ZlizEQMapFormExperimental_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized && Settings.MinimizeToTray)
            {
                notifyIcon1.Visible = true;
                this.Hide();
            }
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            this.Show();
            notifyIcon1.Visible = false;
            this.WindowState = FormWindowState.Normal;
        }

        private void checkAlwaysOnTop_CheckedChanged(object sender, EventArgs e)
        {
            SetAlwaysOnTop();
        }

        private void SetAlwaysOnTop()
        {
            this.TopMost = checkAlwaysOnTop.Checked;
        }

        private Point ParseTextToPoint(string text)
        {
            Point result = new Point(0, 0);
            string[] items = text.Split(',');

            if (items.Length == 2)
            {
                int y;
                int x;

                if (Int32.TryParse(items[0].Trim(), out y) && Int32.TryParse(items[1].Trim(), out x))
                {
                    result.X = x;
                    result.Y = y;
                }
            }

            return result;
        }

        private void ForceSetWaypoint()
        {
            Point parsedWaypoint = ParseTextToPoint(txtWaypoint.Text);
            Overseer.SetWaypoint(parsedWaypoint.X, parsedWaypoint.Y);
            SetButtonWaypointText();
        }

        private void SetButtonWaypointText()
        {
            if (Overseer.Waypoint == null)
                btnSetWaypoint.Text = "Set WP";
            else
                btnSetWaypoint.Text = "Clear";
        }

        private void textBoxCharName_TextChanged(object sender, EventArgs e)
        {
            Overseer.CharacterNameChange(textBoxCharName.Text);
        }

        private void InitializeDebugging()
        {
            picBox.SizeMode = PictureBoxSizeMode.Zoom;
            ForceSetPlayerLocation();
            ForceSetWaypoint();
            ResizeMap();
        }

        private void btnSetWaypoint_Click(object sender, EventArgs e)
        {
            if (Overseer.Waypoint == null)
            {
                string[] items = txtWaypoint.Text.Split(',');

                if (items.Length == 2)
                {
                    int y;
                    int x;

                    if (Int32.TryParse(items[0].Trim(), out y) && Int32.TryParse(items[1].Trim(), out x))
                    {
                        Overseer.SetWaypoint(x, y);
                    }
                }
            }
            else
                Overseer.ClearWaypoint();

            SetButtonWaypointText();
        }

        private void ForceSetPlayerLocation()
        {
            Overseer.UpdatePlayerLocation((int)nud_playerX.Value, (int)nud_playerY.Value);
        }

        private void ResizeMap()
        {
            //var test = currentZoneData.ZeroLocation;

            //picBox.Width = currentZoneData.ImageX * renderScale;
            //picBox.Height = currentZoneData.ImageY * renderScale;

            var roundedX = Math.Round(Overseer.CurrentZoneMap.ImageX * renderScale);
            var roundedY = Math.Round(Overseer.CurrentZoneMap.ImageY * renderScale);

            picBox.Width = (int)roundedX;
            picBox.Height = (int)roundedY;

            ForceSetWaypoint();
            ForceSetPlayerLocation();
        }

        private void buttonAutosize_Click(object sender, EventArgs e)
        {
            picBox.SizeMode = PictureBoxSizeMode.AutoSize;
        }

        private void buttonStretch_Click(object sender, EventArgs e)
        {
            picBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void buttonCenter_Click(object sender, EventArgs e)
        {
            picBox.SizeMode = PictureBoxSizeMode.CenterImage;
        }

        private void buttonZoom_Click(object sender, EventArgs e)
        {
            picBox.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void buttonNormal_Click(object sender, EventArgs e)
        {
            picBox.SizeMode = PictureBoxSizeMode.Normal;
        }

        private void buttonForceRedraw_Click(object sender, EventArgs e)
        {
            ResizeMap();
        }

        private void nud_scale_ValueChanged(object sender, EventArgs e)
        {
            float ratio = (float)nud_scale.Value;
            renderScale = ratio;
            ResizeMap();
        }

        private void buttonSetPlayerXY_Click(object sender, EventArgs e)
        {
            ForceSetPlayerLocation();
        }

        private void nud_playerY_ValueChanged(object sender, EventArgs e)
        {
            ForceSetPlayerLocation();
        }

        private void nud_playerX_ValueChanged(object sender, EventArgs e)
        {
            ForceSetPlayerLocation();
        }

        private void button_reinit_Click(object sender, EventArgs e)
        {
            InitializeDebugging();
        }

        private void sliderZoom_Scroll(object sender, EventArgs e)
        {
            SetZoomSlider();
        }

        private void SetZoomSlider()
        {
            float sliderValue = (float)sliderZoom.Value;
            float calc = sliderValue / 100F;
            renderScale = calc;
            ResizeMap();
        }

        public void OpenPopoutMap()
        {
            popoutMap = new PopoutMap();
            popoutMap.LoadPopoutMap(Overseer.CurrentZoneData.ImageFilePath);
            popoutMap.Show();
        }

        private void buttonOpenPopoutMap_Click(object sender, EventArgs e)
        {
            OpenPopoutMap();
        }

        private void button_AddNote_Click(object sender, EventArgs e)
        {
            Point noteCoords = ParseTextToPoint(txt_NewNoteCoords.Text);

            ZoneAnnotationManager.AddNote(new ZoneAnnotation(txt_NewNote.Text, noteCoords.X, noteCoords.Y, Overseer.CurrentZoneData.ShortName, Overseer.CurrentZoneData.SubMapIndex));
            ZoneAnnotationManager.SaveNotes();

            if (check_ClearNoteAfterEntry.Checked)
            {
                txt_NewNote.Clear();
                txt_NewNoteCoords.Clear();
            }

            ReloadNoteData();
        }

        private void ReloadNoteData()
        {
            zoneAnnotationBindingSource.Clear();
            foreach (var anno in ZoneAnnotationManager.ZoneAnnotations.Where(za => za.MapShortName == Overseer.CurrentZoneData.ShortName && za.SubMap == Overseer.CurrentZoneData.SubMapIndex))
            {
                zoneAnnotationBindingSource.Add(anno);
            }

            Overseer.RaiseRedrawMaps(null, null);
        }

        private void check_ShowPlayerLocHistory_CheckedChanged(object sender, EventArgs e)
        {
            Overseer.TogglePlayerLocationHistory(check_ShowPlayerLocHistory.Checked);
        }

        private void button_SetNoteCoordsToPlayerLoc_Click(object sender, EventArgs e)
        {
            txt_NewNoteCoords.Text = $"{Overseer.PlayerCoords.X}, {Overseer.PlayerCoords.Y}";
        }

        private void dgv_ZoneAnnotation_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            ZoneAnnotationManager.SaveNotes();
            Overseer.RaiseRedrawMaps(null, null);
        }

        private void button_NotesColor_Click(object sender, EventArgs e)
        {
            DialogResult result = colorDialog_Notes.ShowDialog();
            if (result == DialogResult.OK)
            {
                button_NotesColor.BackColor = colorDialog_Notes.Color;
                Overseer.UpdateNotesColor(colorDialog_Notes.Color);
            }
        }

        private void button_NotesFont_Click(object sender, EventArgs e)
        {
            DialogResult result = fontDialog_Notes.ShowDialog();
            if (result == DialogResult.OK)
            {
                button_NotesFont.Font = fontDialog_Notes.Font;
                Overseer.UpdateNotesFont(fontDialog_Notes.Font);
            }
        }

        private void button_ResetZoom_Click(object sender, EventArgs e)
        {
            sliderZoom.Value = 100;
            SetZoomSlider();
        }

        private void ZlizEQMapFormExperimental_Load(object sender, EventArgs e)
        {

        }

        private void check_ShowAnnotations_CheckStateChanged(object sender, EventArgs e)
        {
            Overseer.ToggleZoneAnnotations((int)check_ShowAnnotations.CheckState);
        }
    }
}
