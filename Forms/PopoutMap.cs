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
        CartographyService Cartographer;

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
                if (picBox_PopoutMap.SizeMode == PictureBoxSizeMode.Zoom)
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

        public PopoutMap(CartographyService cartographer)
        {
            Cartographer = cartographer;
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            CartographyService.RedrawMapsEH += PopoutMap_CartographerSaysRedraw;
            Opacity = Settings.PopoutMapOpacityLevel;
            check_AOT.Checked = Settings.PopoutMapAlwaysOnTop;
        }

        private void PopoutMap_CartographerSaysRedraw(object sender, EventArgs e)
        {
            picBox_PopoutMap.Invalidate();
        }

        public void LoadMapByPath(string imagePath)
        {
            picBox_PopoutMap.Load(imagePath);
            MapHasBeenResized();
        }

        private void buttonClosePopupMap_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DisplayStyleRadioButtons_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_Centered.Checked)
            {
                picBox_PopoutMap.SizeMode = PictureBoxSizeMode.CenterImage;
            }

            if (radioButton_ZoomSize.Checked)
            {
                picBox_PopoutMap.SizeMode = PictureBoxSizeMode.Zoom;
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

        private void picBox_PopoutMap_DoubleClick(object sender, EventArgs e)
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

        private void picBox_PopoutMap_Paint(object sender, PaintEventArgs e)
        {
            foreach (IMapDrawable marker in Cartographer.Markers)
            {
                marker.Draw(e.Graphics, renderScale, mapXOffset, mapYOffset);
            }
        }

        // There's GOTTA be a better way to do this.
        private void picBox_PopoutMap_SizeChanged(object sender, EventArgs e)
        {
            MapHasBeenResized();
        }

        private void MapHasBeenResized()
        {
            float ratio = Math.Min((float)ClientRectangle.Width / (float)picBox_PopoutMap.Image.Width, (float)ClientRectangle.Height / (float)picBox_PopoutMap.Image.Height);

            mapXOffset = (picBox_PopoutMap.Width - (int)(picBox_PopoutMap.Image.Width * ratio)) / 2;
            mapYOffset = (picBox_PopoutMap.Height - (int)(picBox_PopoutMap.Image.Height * ratio)) / 2;

            autoZoom = ratio;
        }

        private void SetAlwaysOnTop()
        {
            this.TopMost = check_AOT.Checked;
        }

        private void check_AOT_CheckedChanged(object sender, EventArgs e)
        {
            Settings.PopoutMapAlwaysOnTop = check_AOT.Checked;
            SetAlwaysOnTop();
        }

        private void PopoutMap_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.SaveSettings();
        }
    }
}
