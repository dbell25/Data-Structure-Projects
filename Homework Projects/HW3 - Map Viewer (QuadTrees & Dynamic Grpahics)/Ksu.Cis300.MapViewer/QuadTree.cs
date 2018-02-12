/* QuadTree.cs
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
    class QuadTree
    {
        /// <summary>
        /// Initializes new QuadTrees in which to store the children
        /// </summary>
        private QuadTree _northwestChild;
        private QuadTree _northeastChild;
        private QuadTree _southwestChild;
        private QuadTree _southeastChild;

        /// <summary>
        /// Describes the rectangle in map coordinates that this node represents.
        /// </summary>
        private RectangleF _bounds;

        /// <summary>
        /// Contains the street segments associated with a node.
        /// </summary>
        private List<StreetSegment> _streets;

        /// <summary>
        /// Draws the contents of the quad tree.
        /// </summary>
        /// <param name="draw"></param>
        /// <param name="scale"></param>
        /// <param name="depth"></param>
        public void Draw(Graphics draw, int scale, int depth)
        {
            RectangleF converted = new RectangleF(draw.ClipBounds.X / scale, draw.ClipBounds.Y / scale, draw.ClipBounds.Width / scale, draw.ClipBounds.Height / scale);
            if (converted.IntersectsWith(_bounds))
            {
                foreach (StreetSegment i in _streets)
                {
                    i.Draw(draw, scale);
                }
                if (depth > 0)
                {
                    _northwestChild.Draw(draw, scale, depth - 1);
                    _northeastChild.Draw(draw, scale, depth - 1);
                    _southwestChild.Draw(draw, scale, depth - 1);
                    _southeastChild.Draw(draw, scale, depth - 1);
                }
            }
        }

        /// <summary>
        /// Initializes and constructs a QuadTree
        /// </summary>
        public QuadTree(List<StreetSegment> list, RectangleF area, int height)
        {
            _bounds = area;
            if(height == 0)
            {
                _streets = list;   
            }
            else
            {
                float x = ((area.Width) / 2) + area.Left;
                float y = ((area.Height) / 2) + area.Top;
                List<StreetSegment> north = new List<StreetSegment>();
                List<StreetSegment> south = new List<StreetSegment>();
                List<StreetSegment> NE = new List<StreetSegment>();
                List<StreetSegment> NW = new List<StreetSegment>();
                List<StreetSegment> SE = new List<StreetSegment>();
                List<StreetSegment> SW = new List<StreetSegment>();
                List<StreetSegment> temp = new List<StreetSegment>();
                _streets = new List<StreetSegment>();

                SplitHeights(list, height, _streets, temp);
                SplitNorthSouth(temp, y, south, north);
                SplitEastWest(north, x, NW, NE);
                SplitEastWest(south, x, SW, SE);

                _northwestChild = new QuadTree(NW, area, height - 1);
                _northeastChild = new QuadTree(NE, area, height - 1);
                _southwestChild = new QuadTree(SW, area, height - 1);
                _southeastChild = new QuadTree(SE, area, height - 1);
            }
        }

        /// <summary>
        /// Splits street segments into an east portion and a west portion.
        /// </summary>
        /// <param name="tosplit"></param>
        /// <param name="west"></param>
        /// <param name="east"></param>
        private static void SplitEastWest(List<StreetSegment> tosplit, float value, List<StreetSegment> west, List<StreetSegment> east)
        {
            foreach(StreetSegment temp in tosplit)
            {
                if(temp.Start.X <= value && temp.End.X <= value)
                {
                    west.Add(temp);
                }
                else if (temp.Start.X >= value && temp.End.X >= value)
                {
                    east.Add(temp);
                }
                else
                {
                    if(temp.Start.X != temp.End.X)
                    {
                        float y = (((temp.End.Y - temp.Start.Y) / (temp.End.X - temp.Start.X)) * (value - temp.Start.X)) + temp.Start.Y;
                        PointF mid = new PointF(value, y);
                        StreetSegment w = temp;
                        StreetSegment e = temp;
                        w.End = mid;
                        e.Start = mid;
                        if (w.Start.X <= value)
                        {
                            west.Add(w);
                            east.Add(e);
                        }
                        else
                        {
                            west.Add(e);
                            east.Add(w);
                        }
                       
                    }
                }
            }
        }

        /// <summary>
        /// Split street segments by visibility.
        /// </summary>
        /// <param name="tosplit"></param>
        /// <param name="visible"></param>
        /// <param name="invisible"></param>
        private static void SplitHeights(List<StreetSegment> tosplit, int Zoom, List<StreetSegment> visible, List<StreetSegment> invisible)
        {
            foreach (StreetSegment temp in tosplit)
            {
                if (temp.VisibleLevels > Zoom)
                {
                    visible.Add(temp);
                }
                else
                {
                    invisible.Add(temp);
                }
            }
        }

        /// <summary>
        /// Splits street segments into a north portion and a south portion.
        /// </summary>
        /// <param name="tosplit"></param>
        /// <param name="north"></param>
        /// <param name="south"></param>
        private static void SplitNorthSouth(List<StreetSegment> tosplit, float value, List<StreetSegment> north, List<StreetSegment> south)
        {
            foreach (StreetSegment temp in tosplit)
            {
                if (temp.Start.Y <= value && temp.End.Y <= value)
                {
                    south.Add(temp);
                }
                else if (temp.Start.Y >= value && temp.End.Y >= value)
                {
                    north.Add(temp);
                }
                else
                {
                    if (temp.Start.X != temp.End.X)
                    {
                        float x = (((temp.End.X - temp.Start.X) / (temp.End.Y - temp.Start.Y)) * (value - temp.Start.Y)) + temp.Start.X;
                        PointF mid = new PointF(x, value);
                        StreetSegment n = temp;
                        StreetSegment s = temp;
                        n.End = mid;
                        s.Start = mid;

                       if(n.Start.Y >= value)
                        {
                            north.Add(n);
                            south.Add(s);
                        }
                        else
                        {
                            north.Add(s);
                            south.Add(n);
                        }
                        
                    }
                }
            }
        }
    }
}
