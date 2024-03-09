using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ZlizEQMap
{
    public class MapMarker
    {
        public MapPoint Location { get; set; }
        public int Style { get; set; }

        public MapMarker()
        {
            Location = new MapPoint() { X = 0, Y = 0 };
            Style = 0;
        }

        public MapMarker(int x, int y)
        {
            Location = new MapPoint() { X = x, Y = y };
            Style = 0;
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
