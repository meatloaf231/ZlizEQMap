using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.AccessControl;
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

    public interface IMapDrawable
    {
        Pen MapPen { get; set; }
        void Draw(Graphics g, float renderScale = 1F, int xOffset = 0, int yOffset = 0);
    }

    public class MapEllipse : MapPoint, IMapDrawable
    {
        public Pen MapPen { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public MapEllipse(Pen pen, int x, int y, int width, int height)
        {
            MapPen = pen;
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public void Draw(Graphics g, float renderScale, int xOffset = 0, int yOffset = 0)
        {
            //Pen = new Pen(Color.FromArgb(opacity,   2F)
            g.DrawEllipse(MapPen, (X * renderScale) + xOffset, (Y * renderScale) + yOffset, Width * renderScale, Height * renderScale);
        }
    }

    public class MapLine : IMapDrawable
    {
        public Pen MapPen { get; set; }
        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }

        public MapLine(Pen pen, Point startPoint, Point endPoint)
        {
            MapPen = pen;
            StartPoint = startPoint;
            EndPoint = endPoint;
        }

        public void Draw(Graphics g, float renderScale, int xOffset = 0, int yOffset = 0)
        {
            Point ScaledStartPoint = new Point((int)(StartPoint.X * renderScale) + xOffset, (int)(StartPoint.Y * renderScale) + yOffset);
            Point ScaledEndPoint = new Point((int)(EndPoint.X * renderScale) + xOffset, (int)(EndPoint.Y * renderScale) + yOffset);
            g.DrawLine(MapPen, ScaledStartPoint, ScaledEndPoint);
        }
    }

    public class MapCross : IMapDrawable
    {
        public Pen MapPen { get; set; }
        public MapLine Line1 { get; set; }
        public MapLine Line2 { get; set; }

        public MapCross(Pen pen, MapLine line1, MapLine line2)
        {
            MapPen = pen;
            Line1 = line1;
            Line2 = line2;
        }

        public MapCross(Pen pen, 
            int line1StartX, int line1StartY, int line1EndX, int line1EndY,
            int line2StartX, int line2StartY, int line2EndX, int line2EndY)
        {
            MapPen = pen;
            Line1 = new MapLine(pen, new Point(line1StartX, line1StartY), new Point(line1EndX, line1EndY));
            Line2 = new MapLine(pen, new Point(line2StartX, line2StartY), new Point(line2EndX, line2EndY));
        }

        public void Draw(Graphics g, float renderScale, int xOffset = 0, int yOffset = 0)
        {
            Line1.Draw(g, renderScale, xOffset, yOffset);
            Line2.Draw(g, renderScale, xOffset, yOffset);
        }
    }

    public class MapPoint
    {
        public int Y { get; set; }
        public int X { get; set; }
    }

    public class MapAnnotation : MapPoint, IMapDrawable
    {
        public string Note { get; set; }

        public IMapDrawable MapMarker { get; set; }
        public Pen MapPen { get => MapMarker.MapPen; set => MapMarker.MapPen = value; }

        public MapAnnotation(IMapDrawable mapMarker, int posX, int posY, string note)
        {
            X = posX;
            Y = posY;
            MapMarker = mapMarker;
            Note = note;
        }

        public void Draw(Graphics g, float renderScale = 1, int xOffset = 0, int yOffset = 0)
        {
            MapMarker.Draw(g, renderScale, xOffset, yOffset);
            //Font fonttest = new Font("Arial", 12 * renderScale, FontStyle.Bold);
            //PointF testpoint = new PointF((X * renderScale) + xOffset, (Y * renderScale) + yOffset);
            g.DrawString(Note, Settings.NotesFont, MapMarker.MapPen.Brush, (X * renderScale) + xOffset, (Y * renderScale) + yOffset);
        }
    }

    //public abstract class MapMarkerCollection : IMapDrawable
    //{
    //    public ICollection<IMapDrawable> Markers { get; set; }

    //    public void Draw(Graphics g, float renderScale, int xOffset, int yOffset)
    //    {
    //        foreach (IMapDrawable marker in Markers)
    //        {
    //            marker.Draw(g, renderScale, xOffset, yOffset);
    //        }
    //    }
    //}

    //public class NavigationMarkers : IMapDrawable
    //{
    //    public Pen PlayerPen = new Pen(Color.Red, 2f);
    //    public Pen PlayerHistoryPen = new Pen(Color.Yellow, 2f);
    //    public Pen PlayerPenArrow = new Pen(Color.Red, 2f);
    //    public Pen WaypointPen = new Pen(Color.Blue, 2f);

    //    public int MaxHistoryLocations { get; set; } = 1;
    //    public List<Point> PlayerLocHistory { get; set; }
    //    public MapCross CurrentPlayerLocationMarker { get; set; }
    //    public MapEllipse CurrentWaypointMarker { get; set; }


    //    public NavigationMarkers()
    //    {
    //        PlayerLocHistory = new List<Point>();
    //    }

    //    public void UpdatePlayerLocation(int x, int y)
    //    {
    //        PlayerLocHistory.Add(new Point(x, y));
    //    }

    //    public void Draw(Graphics g, float renderScale = 1F, int xOffset = 0, int yOffset = 0)
    //    {
    //        // Draw the waypoint marker(s)
    //        CurrentWaypointMarker.Draw(g, renderScale, xOffset, yOffset);
    //        CurrentPlayerLocationMarker.Draw(g, renderScale, xOffset, yOffset);
    //        RenderPlayerLocHistoryAsLine(g);
    //    }

    //    private void RenderPlayerLocHistoryAsLine(Graphics g) {
    //        //g.DrawLines(Pen, PlayerLocHistory.ToArray());

    //        // We do need more than one point to make a line, it turns out
    //        if (PlayerLocHistory.Count > 1)
    //        {
    //            for (int i = Math.Min(MaxHistoryLocations, PlayerLocHistory.Count); i > 0; i--)
    //            {
    //                g.DrawLine(PlayerHistoryPen, PlayerLocHistory[i], PlayerLocHistory[i - 1]);
    //            }
    //        }
    //    }
    //}


    public class PointSet
    {
        public Point Point1 { get; set; }
        public Point Point2 { get; set; }
    }
}
