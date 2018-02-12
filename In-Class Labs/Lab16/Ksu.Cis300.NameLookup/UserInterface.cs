/* UserInterface.cs
 * Author: Rod Howell
 * Modified By: Daniel Bell
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
using Ksu.Cis300.ImmutableBinaryTrees;
using KansasStateUniversity.TreeViewer2;

namespace Ksu.Cis300.NameLookup
{
    /// <summary>
    /// A GUI for a program to look up name information in census data.
    /// </summary>
    public partial class UserInterface : Form
    {
        /// <summary>
        /// The information on all the names.
        /// </summary>
        private BinaryTreeNode<NameInformation> _names = null;

        /// <summary>
        /// Constructs the GUI.
        /// </summary>
        public UserInterface()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Reads the given file into a list.
        /// </summary>
        /// <param name="fn">The name of the file to read.</param>
        /// <returns>A list containing the information from the file.</returns>
        private BinaryTreeNode<NameInformation> ReadFile(string fn)
        {
            BinaryTreeNode<NameInformation> node = null;
            using (StreamReader input = new StreamReader(fn))
            {
                while (!input.EndOfStream)
                {
                    string name = input.ReadLine().Trim();
                    float freq = Convert.ToSingle(input.ReadLine());
                    int rank = Convert.ToInt32(input.ReadLine());
                    node = Add(new NameInformation(name, freq, rank), node);
                }
                return node;
            }
        }

        /// <summary>
        /// Handles a Click event on the "Open Data File" button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxOpen_Click(object sender, EventArgs e)
        {
            if (uxOpenDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _names = ReadFile(uxOpenDialog.FileName);
                    new TreeForm(_names, 100).Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        /// <summary>
        /// Gets binary tree information.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        private NameInformation GetInformation(string name, BinaryTreeNode<NameInformation> t)
        {
            NameInformation result = new NameInformation();
            if (t == null)
            {
                return result;
            }
            else
            {
                int temp = t.Data.Name.CompareTo(name);
                if(temp == 0)
                {
                    return t.Data;
                }
                else if(temp < 0)
                {
                    return GetInformation(name, t.RightChild);
                }
                else
                {
                    return GetInformation(name, t.LeftChild);
                }
            }

        }

        /// <summary>
        /// Adds binary tree information.
        /// </summary>
        /// <param name="info"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        private BinaryTreeNode<NameInformation> Add(NameInformation info, BinaryTreeNode<NameInformation> t)
        {
            if (t == null)
            {
                return new BinaryTreeNode<NameInformation>(info, null, null);
            }
            int temp = info.Name.CompareTo(t.Data.Name);
            if (temp < 0)
            {
                return new BinaryTreeNode<NameInformation>(t.Data, Add(info, t.LeftChild), t.RightChild);
            }
            else if(temp == 0)
            {
                throw new ArgumentException();
            }
            else
            {
                return new BinaryTreeNode<NameInformation>(t.Data, t.LeftChild, Add(info, t.RightChild));
            }
        }

        /// <summary>
        /// Handles a Click event on the "Get Statistics" button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxLookup_Click(object sender, EventArgs e)
        {
            string name = uxName.Text.Trim().ToUpper();
            NameInformation info = GetInformation(name, _names);
            if (info.Name == null)
            {
                MessageBox.Show("Name not found.");
                uxFrequency.Text = "";
                uxRank.Text = "";
            }
            else
            {
                uxFrequency.Text = info.Frequency.ToString();
                uxRank.Text = info.Rank.ToString();
                return;
            }
        }
    }
}
