/* UserInterface.cs
 * Author: Rod Howell
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
using KansasStateUniversity.TreeViewer2;
using Ksu.Cis300.ImmutableBinaryTrees;
using Ksu.Cis300.Sort;
using System.IO;

namespace Ksu.Cis300.HuffmanTree
{
    /// <summary>
    /// A user interface for a program that constructs and displays Huffman trees from files.
    /// </summary>
    public partial class UserInterface : Form
    {
        /// <summary>
        /// Constructs the GUI.
        /// </summary>
        public UserInterface()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles a Click event on the "Select a File" button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxSelectFile_Click(object sender, EventArgs e)
        {
            if (uxOpenDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    BinaryTreeNode<byte> t = null;
                    t = BuildTree(BuildLeaves(BuildTable(uxOpenDialog.FileName)));
  
                    new TreeForm(t, 100).Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        /// <summary>
        /// Builds a frequency table from a given file.
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        private long[] BuildTable(string file)
        {
            long[] table = new long[256];
            using (FileStream input = File.OpenRead(file))
            {
                int k;
                while ((k = input.ReadByte()) != -1)
                {
                    table[k]++;
                }
            }
            return table;
        }

        /// <summary>
        /// Builds the leaves of the Huffman tree.
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        private MinPriorityQueue<long, BinaryTreeNode<byte>> BuildLeaves(long[] table)
        {
            MinPriorityQueue<long, BinaryTreeNode<byte>>leaves = new MinPriorityQueue<long, BinaryTreeNode<byte>>();
            for(int i = 0; i < table.Length; i++)
            {
                if (table[i] != 0)
                {
                    BinaryTreeNode<byte> temp = new BinaryTreeNode<byte>((byte)i, null, null);
                    leaves.Add(table[i], temp);
                }
            }
            return leaves;
        }

        /// <summary>
        /// Builds the Huffman tree from the leaves.
        /// </summary>
        /// <param name="leaves"></param>
        /// <returns></returns>
        private BinaryTreeNode<byte> BuildTree(MinPriorityQueue<long, BinaryTreeNode<byte>>leaves)
        {
            while(leaves.Count > 1)
            {
                long priority1 = leaves.MinimumPriority;
                BinaryTreeNode<byte> tree1 = leaves.RemoveMinimumPriority();
                long priority2 = leaves.MinimumPriority;
                BinaryTreeNode<byte> tree2 = leaves.RemoveMinimumPriority();

                leaves.Add((priority1 + priority2), new BinaryTreeNode<byte>(0, tree1, tree2));
            }
            return leaves.RemoveMinimumPriority();
        }
    }
}
