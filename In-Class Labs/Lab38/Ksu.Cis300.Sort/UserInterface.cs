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

namespace Ksu.Cis300.Sort
{
    /// <summary>
    /// A GUI for a program that sorts files of integers.
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
        /// Swaps the values at the given locations in the given list.
        /// </summary>
        /// <param name="list">The list containing the elements to swap.</param>
        /// <param name="i">The location of one of the elements to swap.</param>
        /// <param name="j">The location of the other element.</param>
        private void Swap(IList<int> list, int i, int j)
        {
            int temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }

        /// <summary>
        /// Sorts the given list using selection sort.
        /// </summary>
        /// <param name="list">The list to sort.</param>
        private void Sort(IList<int> list)
        {
            Sort(list, 0, list.Count);
            /*
            for (int i = 1; i < start + len; i++)
            {
                int j = i;
                int n = list[i];

                while (j > 0 && n < list[j - 1])
                {
                    list[j] = list[j - 1];
                    j--;
                }
                list[j] = n;
            }
            */
        }

        /// <summary>
        /// Handles a Click event on the "Sort File" button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxSort_Click(object sender, EventArgs e)
        {
            if (uxOpenDialog.ShowDialog() == DialogResult.OK && uxSaveDialog.ShowDialog() == DialogResult.OK)
            {
                List<int> values = new List<int>();
                try
                {
                    using (StreamReader input = new StreamReader(uxOpenDialog.FileName))
                    {
                        while (!input.EndOfStream)
                        {
                            int value = Convert.ToInt32(input.ReadLine());
                            values.Add(value);
                        }
                    }
                    Sort(values);
                    using (StreamWriter output = new StreamWriter(uxSaveDialog.FileName))
                    {
                        foreach (int i in values)
                        {
                            output.WriteLine("{0,10:D}", i);
                        }
                    }
                    MessageBox.Show("Sorting complete.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("The following error occurred: " + ex.ToString());
                }
            }
        }

        /// <summary>
        /// Merges the two portions into a single temp array.
        /// </summary>
        /// <param name="list"></param>
        /// <param name="start"></param>
        /// <param name="len1"></param>
        /// <param name="len2"></param>
        private void Merge(IList<int> list, int start, int len1, int len2)
        {
            int[] temp = new int[len1 + len2];
            int pos = 0;
            int start1 = start;
            int start2 = start + len1;
            int end1 = start + len1;
            int end2 = start2 + len2;

            while (start1 != end1 && start2 != end2)
            {
                if (list[start1] < list[start2])
                {
                    temp[pos] = list[start1];
                    pos++;
                    start1++;
                }
                else
                {
                    temp[pos] = list[start2];
                    pos++;
                    start2++;
                }
            }
            while (start1 != end1)
            {
                temp[pos] = list[start1];
                pos++;
                start1++;
            }
            while (start2 != end2)
            {
                temp[pos] = list[start2];
                pos++;
                start2++;
            }
            for (int i = 0; i < temp.Length; i++)
            {
                list[i + start] = temp[i];
            }
        }

        /// <summary>
        /// Recusively sorts the data.
        /// </summary>
        /// <param name="list"></param>
        /// <param name="start"></param>
        /// <param name="len"></param>
        private void Sort(IList<int> list, int start, int len)
        {
            if (len > 1)
            {
                int first = len / 2;
                int second = len - first;
                Sort(list, start, first);
                Sort(list, start + first, second);
                Merge(list, start, first, second);
            }
        }
    }
}
