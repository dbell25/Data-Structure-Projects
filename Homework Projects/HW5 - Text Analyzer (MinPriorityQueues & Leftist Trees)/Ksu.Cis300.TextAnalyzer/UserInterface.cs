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
using Ksu.Cis300.Sort;

namespace Ksu.Cis300.TextAnalyzer
{
    /// <summary>
    /// Initializes and runs the user interface.
    /// </summary>
    public partial class UserInterface : Form
    {
        /// <summary>
        /// Initializes the user interface.
        /// </summary>
        public UserInterface()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Event handler for the uxAnalyze button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxAnalyze_Click(object sender, EventArgs e)
        {
            try
            {
                Dictionary<string, WordCount> lookup = new Dictionary<string, WordCount>();
                int x = TextAnalyzer.ProcessFile(uxText1.Text, 0, lookup);
                int y = TextAnalyzer.ProcessFile(uxText2.Text, 1, lookup);
                int[] size = {x, y};
                MinPriorityQueue<float, WordFrequency> queue = TextAnalyzer.GetMostCommonWord(lookup, size, (int)uxNumberOfWords.Value);
                float result = TextAnalyzer.GetDifference(queue);
                MessageBox.Show(result.ToString());
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Event handler for the uxSelectText1 button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxSelectText1_Click(object sender, EventArgs e)
        {
            if (uxOpenDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    uxText1.Text = uxOpenDialog.FileName;
                    if (uxText1.Text != "" && uxText2.Text != "") uxAnalyze.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        /// <summary>
        /// Event handler for the uxSelectText2 button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxSelectText2_Click(object sender, EventArgs e)
        {
            if (uxOpenDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    uxText2.Text = uxOpenDialog.FileName;
                    if (uxText1.Text != "" && uxText2.Text != "") uxAnalyze.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
    }
}
