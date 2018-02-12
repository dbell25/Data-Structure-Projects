/* UserInterface.cs
 * Author: Daniel Bell
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Ksu.Cis300.MapViewer
{
    public partial class UserInterface : Form
    {
        /// <summary>
        /// Initializes the user interface GUI.
        /// </summary>
        public UserInterface()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Stores in the scale factor at minimum zoom.
        /// </summary>
        private int _initialScale = 10;

        /// <summary>
        /// Stores the current map.
        /// </summary>
        private Map _map;

        /// <summary>
        /// Reads in data from input files.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="bounds"></param>
        /// <returns></returns>
        private static List<StreetSegment> ReadFile(string name, out RectangleF bounds)
        {
            List<StreetSegment> Data = new List<StreetSegment>();

            using (StreamReader input = new StreamReader(name))
            {
                string[] line = input.ReadLine().Split(',');
               
                float width = Convert.ToSingle(line[0]);
                float height = Convert.ToSingle(line[1]);
                bounds = new RectangleF(0, 0, width, height);

                while (!input.EndOfStream)
                {
                    line = input.ReadLine().Split(',');
                    Color color = Color.FromArgb(Convert.ToInt32(line[4]));
                    PointF X = new PointF(Convert.ToSingle(line[0]), Convert.ToSingle(line[1]));
                    PointF Y = new PointF(Convert.ToSingle(line[2]), Convert.ToSingle(line[3]));
                    StreetSegment temp = new StreetSegment(X, Y, color, Convert.ToSingle(line[5]), Convert.ToInt32(line[6]));
                    Data.Add(temp);
                }
            }
            return Data;
        }

        /// <summary>
        /// Opens a dialog box for selecting map files.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxOpenMapButton_Click(object sender, EventArgs e)
        {
            if(uxOpenDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    RectangleF bounds;
                    List<StreetSegment> streets = ReadFile(uxOpenDialog.FileName, out bounds);

                    _map = new Map(streets, bounds, _initialScale);
                    uxMapContainer.Controls.Clear();
                    uxMapContainer.Controls.Add(_map);
                    uxZoomIn.Enabled = true;
                    uxZoomOut.Enabled = false;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        /// <summary>
        /// Zooms in on the map and resets resolution when available.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxZoomIn_Click(object sender, EventArgs e)
        {
            Point position = uxMapContainer.AutoScrollPosition;
            position.X *= -1;
            position.Y *= -1;
            _map.ZoomIn();
            uxZoomOut.Enabled = true;

            if (_map.CanZoomIn()) uxZoomIn.Enabled = true;
            else uxZoomIn.Enabled = false;

            position.X = (position.X * 2) + (uxMapContainer.ClientSize.Width / 2);
            position.Y = (position.Y * 2) + (uxMapContainer.ClientSize.Height / 2);
            uxMapContainer.AutoScrollPosition = new Point(position.X, position.Y);
        }

        /// <summary>
        /// Zooms out on the map and resets resolution when available.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxZoomOut_Click(object sender, EventArgs e)
        {
            Point position = uxMapContainer.AutoScrollPosition;
            position.X *= -1;
            position.Y *= -1;
            _map.ZoomOut();
            uxZoomIn.Enabled = true;

            if (_map.CanZoomOut()) uxZoomOut.Enabled = true;
            else uxZoomOut.Enabled = false;

            position.X = (position.X / 2) - (uxMapContainer.ClientSize.Width / 4);
            position.Y = (position.Y / 2) - (uxMapContainer.ClientSize.Height / 4);
            uxMapContainer.AutoScrollPosition = new Point(position.X, position.Y);
        }
    }
}