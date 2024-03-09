using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;

namespace ZlizEQMap
{
    public class ZoneMap
    {
        private Image _mapImage;
        public Image MapImage
        {
            get
            {
                return _mapImage;
            }
            private set
            {
                _mapImage = value;
            }
        }

        /// <summary>
        /// The size in pixels of the Y-axis (vertical) of the map iamge
        /// </summary>
        public int ImageY {
            get
            {
                return MapImage.Size.Height;
            }
        }

        /// <summary>
        /// The size in pixels of the X-axis (horizontal) of the map iamge
        /// </summary>
        public int ImageX {
            get
            {
                return MapImage.Size.Width;
            }
        }

        public ZoneMap(string imageFilePath)
        {
            MapImage = Image.FromFile(imageFilePath);
        }

        public void LoadMapData(string imageFilePath)
        {
            MapImage = Image.FromFile(imageFilePath);
        }
    }
}
