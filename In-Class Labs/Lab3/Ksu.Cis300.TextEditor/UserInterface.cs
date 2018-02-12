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

namespace Ksu.Cis300.TextEditor
{
    /// <summary>
    /// A GUI for a simple text editor.
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
        /// Handles a Click event on the Open menu item.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxOpen_Click(object sender, EventArgs e)
        {
            string fn = uxOpenDialog.FileName;
            if (uxOpenDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    uxDisplay.Text = File.ReadAllText(fn);
                }
                catch (Exception ex)
                {
                    ErrorDisplay(ex);
                }
            }
        }

        /// <summary>
        /// Handles a Click event on the Save As menu item.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxSaveAs_Click(object sender, EventArgs e)
        {
            string fn = uxSaveDialog.FileName;
            if (uxOpenDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    File.WriteAllText(fn, uxDisplay.Text);
                }
                catch (Exception ex)
                {
                    ErrorDisplay(ex);
                }
            }
        }
        /// <summary>
        /// Display an error message if exception is thrown
        /// </summary>
        /// <param name="ex"></param>
        static private void ErrorDisplay(Exception ex)
        {
            MessageBox.Show("The following error occurred: " + ex.ToString());
        }
    }
}
