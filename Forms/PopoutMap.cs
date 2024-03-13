using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ZlizEQMap
{
    public partial class PopoutMap : Form
    {
        DateTime LastRecordedZoneChange = DateTime.Now;

        public Boolean testval;
        public int lockState = 0;
        public int configureState = 1;
        public int borderState = 1;

        public int manualZoom = 100;
        public float autoZoom = 1F;

        // Since the map itself is not necessarily going to fill the entire picturebox
        public int mapXOffset = 0;
        public int mapYOffset = 0;

        public int maxmarkers = 5;

        public float renderScale
        {
            get
            {
                if (picBoxMinimap.SizeMode == PictureBoxSizeMode.Zoom)
                {
                    return autoZoom;
                }
                else
                {
                    return manualZoom;
                }
            }
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        private void HandleClickAndDrag(object sender, MouseEventArgs e)
        {
            if (lockState == 0 || (lockState == 2 && sender == panel_DragMove))
            {
                if (e.Button == MouseButtons.Left)
                {
                    ReleaseCapture();
                    SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
                }
            }
        }

        public PopoutMap()
        {
            Overseer.RedrawMaps += PopoutMap_OverseerSaysRedraw;

            InitializeComponent();
        }

        private void PopoutMap_OverseerSaysRedraw(object sender, EventArgs e)
        {
            picBoxMinimap.Invalidate();
        }

        public void LoadPopoutMap(string imagePath)
        {
            picBoxMinimap.Load(imagePath);
        }

        public void OverwritePopoutMap(PictureBox mainMap)
        {
            picBoxMinimap = mainMap;
        }

        public void DrawAtCoords(int x, int y)
        {
            MapEllipse ellipse = new MapEllipse(Overseer.PlayerPen, x, y, 5, 5);
            Overseer.Markers.Add(ellipse);
            picBoxMinimap.Invalidate();
        }

        private void buttonClosePopupMap_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DisplayStyleRadioButtons_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_Centered.Checked)
            {
                picBoxMinimap.SizeMode = PictureBoxSizeMode.CenterImage;
            }

            if (radioButton_ZoomSize.Checked)
            {
                picBoxMinimap.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void checkBoxLockState_CheckedChanged(object sender, EventArgs e)
        {
            switch (checkBoxLockState.CheckState)
            {
                case CheckState.Unchecked:
                    lockState = 0;
                    break;
                case CheckState.Checked:
                    lockState = 1;
                    break;
                case CheckState.Indeterminate:
                    lockState = 2;
                    break;
                default:
                    break;
            }
        }

        bool fsState = false;
        private void ToggleControls()
        {
            foreach (Control tctl in Controls)
            {
                if (tctl.Tag != null)
                {
                    if (tctl.Tag.ToString() == "ToggleVis")
                    {
                        tctl.Visible = !tctl.Visible;
                    }
                }
            }
        }

        private void buttonConfigurePopupMap_Click(object sender, EventArgs e)
        {
            ToggleControls();
        }

        private void picBoxMinimap_DoubleClick(object sender, EventArgs e)
        {
            ToggleControls();
        }


        int Mx;
        int My;
        int Sw;
        int Sh;

        bool mov;

        private void panel_Resize_MouseDown(object sender, MouseEventArgs e)
        {
            mov = true;
            My = MousePosition.Y;
            Mx = MousePosition.X;
            Sw = Width;
            Sh = Height;
        }

        private void panel_Resize_MouseMove(object sender, MouseEventArgs e)
        {
            if (mov == true)
            {
                Width = MousePosition.X - Mx + Sw;
                Height = MousePosition.Y - My + Sh;
            }
        }

        private void panel_Resize_MouseUp(object sender, MouseEventArgs e)
        {
            mov = false;

        }

        private void trackBar_Opacity_ValueChanged(object sender, EventArgs e)
        {
            this.Opacity = trackBar_Opacity.Value / 100f;
        }

        private void trackBar_Zoom_ValueChanged(object sender, EventArgs e)
        {
            manualZoom = trackBar_Zoom.Value;
        }

        private void picBoxMinimap_Paint(object sender, PaintEventArgs e)
        {
            if (LastRecordedZoneChange < Overseer.LastRecordedZoneChange)
            {
                ZoneChangedUpdateUI();
            }

            foreach (IMapDrawable marker in Overseer.Markers)
            {
                marker.Draw(e.Graphics, renderScale, mapXOffset, mapYOffset);
            }
        }


        private void ZoneChangedUpdateUI()
        {
            picBoxMinimap.Load(Overseer.CurrentZoneData.ImageFilePath);
        }

        // There's GOTTA be a better way to do this.
        private void picBoxMinimap_SizeChanged(object sender, EventArgs e)
        {
            float ratio = Math.Min((float)ClientRectangle.Width / (float)picBoxMinimap.Image.Width, (float)ClientRectangle.Height / (float)picBoxMinimap.Image.Height);

            mapXOffset = (picBoxMinimap.Width - (int)(picBoxMinimap.Image.Width * ratio)) / 2;
            mapYOffset = (picBoxMinimap.Height - (int)(picBoxMinimap.Image.Height * ratio)) / 2;

            autoZoom = ratio;
        }

        private void SetAlwaysOnTop()
        {
            this.TopMost = check_AOT.Checked;
        }

        private void check_AOT_CheckedChanged(object sender, EventArgs e)
        {
            SetAlwaysOnTop();
        }
    }
}
