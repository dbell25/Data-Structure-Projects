/* StreetSegment.cs
 * Author: Daniel Bell
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Ksu.Cis300.MapViewer
{
    public struct StreetSegment
    {
        /// <summary>
        /// Stores coordinate data for the end point.
        /// </summary>
        private PointF _end;

        /// <summary>
        /// Stores color data for the line segments.
        /// </summary>
        private Pen _pen;

        /// <summary>
        /// Stores coordinate data for the beginning point.
        /// </summary>
        private PointF _start;

        /// <summary>
        /// Stores an integer representing the current level of zoom on the map.
        /// </summary>
        private int _visibleLevels;

        /// <summary>
        /// Gets and sets data for the private field _end.
        /// </summary>
        public PointF End
        {
            get
            {
                return _end;
            }
            set
            {
                _end = value;
            }
        }

        /// <summary>
        /// Gets and sets data for the private field _start.
        /// </summary>
        public PointF Start
        {
            get
            {
                return _start;
            }
            set
            {
                _start = value;
            }
        }

        /// <summary>
        /// Gets data from the private field _zoom.
        /// </summary>
        public int VisibleLevels
        {
            get
            {
                return _visibleLevels;
            }
        }

        /// <summary>
        /// Draws the line segements on the map to scale.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="scale"></param>
        public void Draw(Graphics a, int scale)
        {
            a.DrawLine(_pen, (scale * _start.X), (scale * _start.Y), (scale * _end.X), (scale * _end.Y));
        }

        /// <summary>
        /// Constructs and initializes all map data.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="line"></param>
        /// <param name="width"></param>
        /// <param name="zoom"></param>
        public StreetSegment(PointF x, PointF y, Color line, float width, int zoom)
        {
            _start = x;
            _end = y;
            _pen = new Pen(line, width);
            _visibleLevels = zoom;
        }
    }
}
