/* NameInformation.cs
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
using KansasStateUniversity.TreeViewer2;

namespace Ksu.Cis300.BTrees
{
    public partial class NameLookup : Form
    {
        /// <summary>
        /// Globally stores the tree that is created by reading in a name information file.
        /// </summary>
        private BTree<string, NameInformation> _names;

        /// <summary>
        /// The public constructor that only initializes the UI components.
        /// </summary>
        public NameLookup()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This method takes in the file name of a name information file and reads it using a StreamReader.
        /// </summary>
        /// <param name="fn"></param>
        /// <returns></returns>
        private BTree<string, NameInformation> ReadFile(string fn)
        {
            using (StreamReader input = new StreamReader(fn))
            {
                int min = Convert.ToInt32(uxMinDegree.Text);
                BTree<string, NameInformation> tree = new BTree<string, NameInformation>(min);

                while (!input.EndOfStream)
                {
                    String name = input.ReadLine().Trim();
                    float frequency = Convert.ToSingle(input.ReadLine());
                    int rank = Convert.ToInt32(input.ReadLine());
                    NameInformation temp = new NameInformation(name, frequency, rank);
                    tree.Insert(name, temp);
                }
                return tree;
            }
        }

        /// <summary>
        /// Event handler for the Get Statistics Button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxLookup_Click(object sender, EventArgs e)
        {
            String name = uxName.Text.Trim().ToUpper();
            NameInformation temp = _names.Find(name);
            if (temp.Name != null)
            {
                uxFrequency.Text = _names.Find(name).Frequency.ToString();
                uxRank.Text = _names.Find(name).Rank.ToString();
            }
            else
            {
                MessageBox.Show("Name Not Found.");
                uxFrequency.Text = "";
                uxRank.Text = "";
            }
        }

        /// <summary>
        /// Creates a B-tree to use for testing.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxMakeTree_Click(object sender, EventArgs e)
        {
            int min = Convert.ToInt32(uxMinDegree.Value);
            BTree<int, int> tree = new BTree<int, int>(min);
            for (int i = 1; i <= uxCount.Value; i++)
            {
                tree.Insert(i, i);
            }
            new TreeForm(tree, 100).Show();
        }

        /// <summary>
        /// An event handler for the open data file button. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxOpen_Click(object sender, EventArgs e)
        {
            if (uxOpenDialog.ShowDialog() == DialogResult.OK)
            {
                _names = ReadFile(uxOpenDialog.FileName);
                new TreeForm(_names, 100).Show();
            }
        }
    }
}