/* Map.cs
 * Author: Daniel Bell
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ksu.Cis300.MapViewer
{
    public partial class Map : UserControl
    {
        /// <summary>
        /// Initializes a field of for the maximum zoom level to 6.
        /// </summary>
        private const int _maxZoom = 6;

        /// <summary>
        /// Initializes a field for storing map scale factor.
        /// </summary>
        private int _scale = 1;

        /// <summary>
        /// Initializes a field for storing the zoom level.
        /// </summary>
        private int _zoom = 0;

        /// <summary>
        /// Initializes a field for storing map data.
        /// </summary>
        private QuadTree _data;

        /// <summary>
        /// Returns wether or not the map can zoom in.
        /// </summary>
        /// <returns></returns>
        public bool CanZoomIn()
        {
            return (_zoom < _maxZoom);
        }

        /// <summary>
        /// Returns wether or not the map can zoom out.
        /// </summary>
        /// <returns></returns>
        public bool CanZoomOut()
        {
            return (_zoom > 0);
        }

        /// <summary>
        /// Determine whether a given point is within a given rectangle.
        /// </summary>
        /// <param name="point"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        private static bool IsWithinBounds(PointF point, RectangleF x)
        {
            return (point.X >= x.Left && point.X <= x.Right && point.Y >= x.Top && point.Y <= x.Bottom);
        }

        /// <summary>
        /// Initializes graphics for the map class.
        /// </summary>
        public Map(List<StreetSegment> streets, RectangleF bounds, int scale)
        {
            InitializeComponent();
            foreach (StreetSegment a in streets)
            {
                if (!IsWithinBounds(a.Start, bounds)) throw new ArgumentException();
                if (!IsWithinBounds(a.End, bounds)) throw new ArgumentException();
            }
            _data = new QuadTree(streets, bounds, _maxZoom);
            _scale = scale;
            Size = new Size((int)(bounds.Width * scale), (int)(bounds.Height * scale));
        }

        /// <summary>
        /// Control when the map needs to be redrawn.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics toPaint = e.Graphics;
            toPaint.Clip = new Region(ClientRectangle);
            _data.Draw(toPaint, _scale, _zoom);
        }

        /// <summary>
        /// Redraws the screen for zooming in.
        /// </summary>
        public void ZoomIn()
        {
            if (CanZoomIn())
            {
                _zoom++;
                _scale *= 2;
                Size = new Size(Size.Width * 2, Size.Height * 2);
                Invalidate();
            }
        }

        /// <summary>
        /// Redraws the screen for zooming out.
        /// </summary>
        public void ZoomOut()
        {
            if (CanZoomOut())
            {
                _zoom--;
                _scale /= 2;
                Size = new Size(Size.Width / 2, Size.Height / 2);
                Invalidate();
            }
        }
    }
}
