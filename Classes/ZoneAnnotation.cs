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
    public class ZoneAnnotation : MapPoint
    {
        public string Note { get; set; }
        public bool Show { get; set; }
        
        public string MapShortName { get; set; }


        public ZoneAnnotation(string note, int x, int y, string mapShortName, bool show = true)
        {
            Note = note;
            X = x;
            Y = y;
            MapShortName = mapShortName;
            Show = show;
        }
    }
}
