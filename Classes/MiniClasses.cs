using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace ZlizEQMap
{
    //public class MapMarker
    //{
    //    public MapPoint Location { get; set; }
    //    public int Style { get; set; }

    //    public MapMarker()
    //    {
    //        Location = new MapPoint() { X = 0, Y = 0 };
    //        Style = 0;
    //    }

    //    public MapMarker(int x, int y)
    //    {
    //        Location = new MapPoint() { X = x, Y = y };
    //        Style = 0;
    //    }
    //}

    public interface IMapMarker
    {
        Pen Pen { get; set; }

        void Draw(Graphics g, float renderScale = 1F, int xOffset = 0, int yOffset = 0, int opacity = 255);
    }

    public class MapEllipse : IMapMarker
    {
        public Pen Pen { get; set; }

        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public MapEllipse(Pen pen, int x, int y, int width, int height)
        {
            Pen = pen;
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public void Draw(Graphics g, float renderScale, int xOffset = 0, int yOffset = 0, int opacity = 0)
        {
            //Pen = new Pen(Color.FromArgb(opacity,   2F)
            g.DrawEllipse(Pen, (X * renderScale) + xOffset, (Y * renderScale) + yOffset, Width * renderScale, Height * renderScale);
        }
    }

    public class MapLine : IMapMarker
    {
        public Pen Pen { get; set; }

        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }

        public MapLine(Pen pen, Point startPoint, Point endPoint)
        {
            Pen = pen;
            StartPoint = startPoint;
            EndPoint = endPoint;
        }

        public void Draw(Graphics g, float renderScale, int xOffset = 0, int yOffset = 0, int opacity = 255)
        {
            Point ScaledStartPoint = new Point((int)(StartPoint.X * renderScale) + xOffset, (int)(StartPoint.Y * renderScale) + yOffset);
            Point ScaledEndPoint = new Point((int)(EndPoint.X * renderScale) + xOffset, (int)(EndPoint.Y * renderScale) + yOffset);
            g.DrawLine(Pen, ScaledStartPoint, ScaledEndPoint);
        }
    }

    public class MapCross : IMapMarker
    {
        public Pen Pen { get; set; }

        public MapLine Line1 { get; set; }
        public MapLine Line2 { get; set; }

        public MapCross(Pen pen, MapLine line1, MapLine line2)
        {
            Pen = pen;
            Line1 = line1;
            Line2 = line2;
        }

        public void Draw(Graphics g, float renderScale, int xOffset = 0, int yOffset = 0, int opacity = 255)
        {
            Line1.Draw(g, renderScale, xOffset, yOffset, opacity);
            Line2.Draw(g, renderScale, xOffset, yOffset, opacity);
        }
    }

    public class MapPoint
    {
        public int Y { get; set; }
        public int X { get; set; }
    }

    public class PointSet
    {
        public Point Point1 { get; set; }
        public Point Point2 { get; set; }
    }
}
