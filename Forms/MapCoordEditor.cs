using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Windows.Forms;

namespace ZlizEQMap.Forms
{
    public partial class MapCoordEditor : Form
    {
        CartographyService Cartographer;
        ZoneData LoadedZoneData;
        private int ImageWidth; 
        private int ImageHeight;
        private int CoordsX;
        private int CoordsY;
        private Point ZeroLocation;
        private bool Lock = false;


        // Math stuff, reducing number of redundant calls.
        // Amount of coords per pixel of the map image, on the Y axis (vertical)
        public float ImageYCoordRatio
        {
            get
            {
                return (float)CoordsY / (float)ImageHeight;
            }
        }

        // Amount of coords per pixel of the map image, on the X axis (horizontal)
        public float ImageXCoordRatio
        {
            get
            {
                return (float)CoordsX / (float)ImageWidth;
            }
        }

        public MapCoordEditor(CartographyService cartographer)
        {
            Cartographer = cartographer;
            InitializeComponent();
        }

        private void MapCoordFixer_Load(object sender, EventArgs e)
        {
            Initialize();
        }

        public void Initialize()
        {
            pictureBox_MapCoordEditor.Load(Cartographer.CurrentZoneData.ImageFilePath);
            LoadCurrentData();
        }

        public void LoadCurrentData()
        {
            Lock = true;
            //nud_ImageX.DataBindings.Add(new Binding("value", Cartographer.CurrentZoneMap, nameof(Cartographer.CurrentZoneMap.ImageX)));
            //nud_ImageY.DataBindings.Add(new Binding("value", Cartographer.CurrentZoneMap, nameof(Cartographer.CurrentZoneMap.ImageY)));
            //nud_TotalX.DataBindings.Add(new Binding("value", Cartographer.CurrentZoneData, nameof(Cartographer.CurrentZoneData.TotalX)));
            //nud_TotalY.DataBindings.Add(new Binding("value", Cartographer.CurrentZoneData, nameof(Cartographer.CurrentZoneData.TotalY)));
            //nud_ZeroX.DataBindings.Add(new Binding("value", Cartographer.CurrentZoneData.ZeroLocation, nameof(Cartographer.CurrentZoneData.ZeroLocation.X)));
            //nud_ZeroY.DataBindings.Add(new Binding("value", Cartographer.CurrentZoneData.ZeroLocation, nameof(Cartographer.CurrentZoneData.ZeroLocation.Y)));

            ImageWidth = Cartographer.CurrentZoneMap.ImageX;
            ImageHeight = Cartographer.CurrentZoneMap.ImageY;
            CoordsX = Cartographer.CurrentZoneData.TotalX;
            CoordsY = Cartographer.CurrentZoneData.TotalY;
            ZeroLocation = new Point(Cartographer.CurrentZoneData.ZeroLocation.X, Cartographer.CurrentZoneData.ZeroLocation.Y);

            UpdateControlsFromData();
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private MapPoint ScaleToMapPoint(int x, int y)
        {
            int newLocationX = (int)(ZeroLocation.X - ((float)x) / ImageXCoordRatio);
            int newLocationY = (int)(ZeroLocation.Y - ((float)y) / ImageYCoordRatio);

            return new MapPoint(newLocationX, newLocationY);

        }

        private void pictureBox_MapCoordEditor_Paint(object sender, PaintEventArgs e)
        {
            // Draw the 0, 0 loc
            int zeroMarkerSize = 10;
            int zeroMarkerPenWeight = 2;
            Color zeroMarkerPenColor = Color.Black;

            Pen ZeroPen = new Pen(zeroMarkerPenColor, zeroMarkerPenWeight);

            //e.Graphics.DrawLine(ZeroPen, 0, 0, 100, 100);
            e.Graphics.DrawLine(ZeroPen, ZeroLocation.X - zeroMarkerSize, ZeroLocation.Y, ZeroLocation.X + zeroMarkerSize, ZeroLocation.Y);
            e.Graphics.DrawLine(ZeroPen, ZeroLocation.X, ZeroLocation.Y - zeroMarkerSize, ZeroLocation.X, ZeroLocation.Y + zeroMarkerSize);


            // Draw the grid
            int gridPenWeight = 1;
            Color gridPenColor = Color.DarkBlue;
            Pen GridPen = new Pen(gridPenColor, gridPenWeight);
            Font GridFont = new Font("Tacoma", 5);
            
            int gridSize = (int)nud_GridDensity.Value;
            int gridScaleMult = (int)nud_GridMultiplier.Value;

            int xBound = CoordsX - (CoordsX % gridSize) + gridSize;
            int yBound = CoordsY - (CoordsY % gridSize) + gridSize;
            int bound = Math.Max(xBound, yBound);
            bound = bound * gridScaleMult;

            double gridLineCount = bound / gridSize;

            // If there's too many grid lines, we need to offset the count
            int maxGridMarkers = 7;
            double factorChange = gridLineCount / maxGridMarkers;
            double gridMarkerFactor = Math.Ceiling(factorChange);

            for (int x = -bound; x <= bound; x += gridSize)
            {
                MapPoint mp_startV = ScaleToMapPoint(x, -bound);
                MapPoint mp_endV = ScaleToMapPoint(x, bound);

                e.Graphics.DrawLine(GridPen, mp_startV.X, mp_startV.Y, mp_endV.X, mp_endV.Y);

                for (int y = -bound; y <= bound; y += gridSize)
                {
                    MapPoint mp_StartH = ScaleToMapPoint(-bound, y);
                    MapPoint mp_EndH = ScaleToMapPoint(bound, y);

                    e.Graphics.DrawLine(GridPen, mp_StartH.X, mp_StartH.Y, mp_EndH.X, mp_EndH.Y);

                    if (x % (gridSize * gridMarkerFactor) == 0 && y % (gridSize * gridMarkerFactor) == 0)
                    {
                        MapPoint textPoint = ScaleToMapPoint(x, y);
                        e.Graphics.DrawEllipse(GridPen, textPoint.X - 2, textPoint.Y - 2, 4, 4);
                        e.Graphics.DrawString($"{x}, {y}", GridFont, GridPen.Brush, textPoint.X + 2, textPoint.Y + 2);
                    }
                }
            }

            foreach (IMapDrawable marker in Cartographer.Markers)
            {
                marker.Draw(e.Graphics);
            }
        }

        private void ZeroCoordsChanged(object sender, EventArgs e)
        {

        }

        private void GridTotalsChanged(object sender, EventArgs e)
        {
           
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void UpdateDataFromControls()
        {
            ImageWidth = (int)nud_ImageX.Value;
            ImageHeight = (int)nud_ImageY.Value;
            CoordsX = (int)nud_TotalX.Value;
            CoordsY = (int)nud_TotalY.Value;
            ZeroLocation = new Point((int)nud_ZeroX.Value, (int)nud_ZeroY.Value);
        }

        private void UpdateControlsFromData()
        {
            Lock = true;
            nud_ImageX.Value = ImageWidth;
            nud_ImageY.Value = ImageHeight;
            nud_TotalX.Value = CoordsX;
            nud_TotalY.Value = CoordsY;
            nud_ZeroX.Value = ZeroLocation.X;
            nud_ZeroY.Value = ZeroLocation.Y;
            pictureBox_MapCoordEditor.Width = ImageWidth;
            pictureBox_MapCoordEditor.Height = ImageHeight;
            Lock = false;
        }

        private void GridControlsChanged(object sender, EventArgs e)
        {
            if (Lock)
                return;

            UpdateDataFromControls();

            pictureBox_MapCoordEditor.Width = ImageWidth;
            pictureBox_MapCoordEditor.Height = ImageHeight;
            pictureBox_MapCoordEditor.Invalidate();
        }

        private void btn_ResetImageSizeX_Click(object sender, EventArgs e)
        {
            LoadCurrentData();
        }
    }
}
