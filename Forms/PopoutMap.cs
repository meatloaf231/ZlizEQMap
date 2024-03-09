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

        public List<MapMarker> markers = new List<MapMarker>();

        public int zoomfactor = 100;

        public float renderScale = 1F;

        Pen playerPen = new Pen(Color.Red, 2f);
        Pen waypointPen = new Pen(Color.Blue, 2f);

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
            InitializeComponent();
        }

        public void LoadPopoutMap(string imagePath)
        {
            picBoxMinimap.Load(imagePath);
        }


        //const int WM_NCHITTEST = 0x0084;
        //const int HTBOTTOMRIGHT = 17;
        //const int BorderSize = 4;
        //protected override void WndProc(ref Message m)
        //{
        //    base.WndProc(ref m);

        //    if (m.Msg == WM_NCHITTEST)
        //    {
        //        //cursor position
        //        var cursorPosition = PointToClient(Cursor.Position);

        //        //border area
        //        //Rectangle rightBorderRectangle = new Rectangle(ClientSize.Width - BorderSize, 0, BorderSize, ClientSize.Height);
        //        Rectangle resizeRect = new Rectangle(ClientSize.Width - 20, ClientSize.Height - 20, 20, 20);

        //        if (resizeRect.Contains(cursorPosition))
        //            m.Result = (IntPtr)HTBOTTOMRIGHT;

        //    }
        //}



        public void OverwritePopoutMap(PictureBox mainMap)
        {
            picBoxMinimap = mainMap;
        }

        public void DrawAtCoords(int x, int y)
        {
            markers.Clear();
            MapMarker marker = new MapMarker(x, y);
            markers.Add(marker);
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
            zoomfactor = trackBar_Zoom.Value;
        }

        private void picBoxMinimap_Paint(object sender, PaintEventArgs e)
        {
            foreach (MapMarker marker in markers)
            {
                // Draw player location X
                e.Graphics.DrawLine(playerPen, new Point(marker.Location.X - 2, marker.Location.Y - 2), new Point(marker.Location.X + 2, marker.Location.Y + 2));
                e.Graphics.DrawLine(playerPen, new Point(marker.Location.X + 2, marker.Location.Y - 2), new Point(marker.Location.X - 2, marker.Location.Y + 2));
            }
        }
    }
}
