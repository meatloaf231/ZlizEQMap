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
                return autoZoom;
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
            //trackBar_Opacity.Visible = !trackBar_Opacity.Visible;
            //trackBar_Zoom.Visible = !trackBar_Zoom.Visible;
            //checkBoxLockState.Visible = !trackBar_Zoom.Visible;
            //groupBox_DisplayStyle.Visible = !trackBar_Zoom.Visible;
            var qControls = this.Controls;
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

            if (!fsState)
            {
                picBoxMinimap.Dock = DockStyle.Fill;
                fsState = true;
            }
            else
            {
                picBoxMinimap.Dock = DockStyle.None;
                fsState = false;
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
            foreach (IMapMarker marker in Overseer.Markers)
            {
                marker.Draw(e.Graphics, renderScale, mapXOffset, mapYOffset);
            }
        }

        // There's GOTTA be a better way to do this.
        private void picBoxMinimap_SizeChanged(object sender, EventArgs e)
        {
            //Rectangle result = new Rectangle(0, 0, 100, 100);
            //Image image = Overseer.CurrentZoneMap.MapImage;
            //Size imageSize = image.Size;

            //int topOffset = picBoxMinimap.Top;
            //int rightOffset = picBoxMinimap.Right - picBoxMinimap.Width;
            //int bottomOffset = picBoxMinimap.Bottom - picBoxMinimap.Height;
            //int leftOffset = picBoxMinimap.Left;

            //Console.WriteLine($"Offsets: {topOffset} / {rightOffset} / {bottomOffset} / {leftOffset} ");

            //float xRatio = (float)ClientRectangle.Width / (float)imageSize.Width;
            //float yRatio = (float)ClientRectangle.Height / (float)imageSize.Height;

            float ratio = Math.Min((float)ClientRectangle.Width / (float)picBoxMinimap.Image.Width, (float)ClientRectangle.Height / (float)picBoxMinimap.Image.Height);
            //result.Width = (int)(imageSize.Width * ratio);
            //result.Height = (int)(imageSize.Height * ratio);
            //result.X = (ClientRectangle.Width - result.Width) / 2;
            //result.Y = (ClientRectangle.Height - result.Height) / 2;

            mapXOffset = (picBoxMinimap.Width - (int)(picBoxMinimap.Image.Width * ratio)) / 2;
            mapYOffset = (picBoxMinimap.Height - (int)(picBoxMinimap.Image.Height * ratio)) / 2;

            // wwwwwwhhhhhhyyyyyyyyyy
            //Console.WriteLine(
            //    $"LOG: " +
            //    $"Dimensions: {picBoxMinimap.Width} / {picBoxMinimap.Height}, " +
            //    $"Ratio: {xRatio} / {yRatio}, " +
            //    $"Spacing: {leftOffset} / {topOffset}, " +
            //    $"Calculated: W/2: {picBoxMinimap.Width / 2} / ratio'd: {imageSize.Width * xRatio} {imageSize.Height * yRatio} / LS: {mapXOffset} / TS: {mapYOffset}"
            //);

            autoZoom = ratio;
        }
    }
}
