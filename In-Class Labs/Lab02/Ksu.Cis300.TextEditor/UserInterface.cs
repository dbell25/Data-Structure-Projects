/*
* Daniel Bell
* CIS 300
* UserInterFace.cs
*/
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ksu.Cis300.TextEditor
{
    /// <summary>
    /// text editor class
    /// </summary>
    public partial class UserInterface : Form
    {
        /// <summary>
        ///  initializes interface constructor
        /// </summary>
        public UserInterface()
        {
            InitializeComponent();
        }

        /// <summary>
        /// opens a selected file
        /// </summary>
        private void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (uxOpenFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fn = uxOpenFileDialog1.FileName;
                MessageBox.Show("Can't open file " + fn);
            }
        }
        /// <summary>
        /// Saves the file 
        /// </summary>
        private void saveAsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (uxSaveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fn = uxSaveFileDialog1.FileName;
                MessageBox.Show("Can't write to file " + fn);
            }
        }
    }
}