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
    public partial class UserInterface : Form
    {
        public UserInterface()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Swaps the location of values.
        /// </summary>
        /// <param name="list">an IList of ints</param>
        /// <param name="i">value 1</param>
        /// <param name="j">value 2</param>
        private void Swap(IList<int> list, int i, int j)
        {
            int temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }

        /// <summary>
        /// Sorts the values within list.
        /// </summary>
        /// <param name="list">an IList of ints</param>
        private void Sort(IList<int> list)
        {
            for(int i = 0; i < list.Count - 1; i++)
            {
                int index = list[i];
                int pos = i;
                for(int j = i+1; j < list.Count; j++)
                {
                    if (list[j] < list[pos]) pos = j;
                }
                Swap(list, i, pos);
            }
        }

        /// <summary>
        /// Event handler for the Sort File button click.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxSortFile_Click(object sender, EventArgs e)
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
    }
}
