/* UserInterface.cs
 * Author: Rod Howell
 * Modified by: Daniel Bell
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

namespace Ksu.Cis300.FolderSizes
{
    /// <summary>
    /// A GUI for a program that finds the sizes of folders.
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
        /// Recursively calculates folder size.
        /// </summary>
        /// <param name="folder"></param>
        /// <returns></returns>
        private long TotalSize(DirectoryInfo folder)
        {
            try
            {
                long Total = 0;
                FileInfo[] f = folder.GetFiles();
                for (int i = 0; i < f.Length; i++)
                {
                    long FileSize = f[i].Length;
                    Total += FileSize;
                }

                DirectoryInfo[] d = folder.GetDirectories();
                for (int j = 0; j < d.Length; j++)
                {
                    Total += TotalSize(d[j]);
                }
                return Total;

            }
            catch(Exception ex)
            {
                return 0;
            }

        }

        /// <summary>
        /// Sets the currently-analyzed folder to the given path name.
        /// </summary>
        /// <param name="folder">The path name for the folder to analyze.</param>
        private void SetCurrentFolder(DirectoryInfo folder)
        {
            uxCurrentFolder.Text = folder.FullName;
            long size = TotalSize(folder);
            uxSize.Text = size.ToString("N0");
            uxFolderList.Items.Clear();
            uxUp.Enabled = (folder.Parent != null);
            try
            {
                foreach (DirectoryInfo d in folder.GetDirectories())
                {
                    uxFolderList.Items.Add(d);
                }
            }
            catch
            {
                // If we can't access the sub-folders, we can't add them to the list.
            }
        }

        private void uxSetFolder_Click(object sender, EventArgs e)
        {
            if (uxFolderBrowser.ShowDialog() == DialogResult.OK)
            {
                SetCurrentFolder(new DirectoryInfo(uxFolderBrowser.SelectedPath));
            }
        }

        /// <summary>
        /// Event handler for uxFolderList.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxFolderList_SelectedIndexChanged(object sender, EventArgs e)
        {
            DirectoryInfo d = (DirectoryInfo)uxFolderList.SelectedItem;
            if (d != null)
            {
                SetCurrentFolder(d);
            }
        }

        /// <summary>
        /// Event handler for uxUp button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxUp_Click(object sender, EventArgs e)
        {
            DirectoryInfo d = new DirectoryInfo(uxCurrentFolder.Text);
            SetCurrentFolder(d.Parent);
        }
    }
}
