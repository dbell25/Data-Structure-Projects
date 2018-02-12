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
            if (uxOpenDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    uxDisplay.Text = File.ReadAllText(uxOpenDialog.FileName);
                }
                catch (Exception ex)
                {
                    DisplayErrorMessage(ex);
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
            if (uxSaveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    File.WriteAllText(uxSaveDialog.FileName, uxDisplay.Text);
                }
                catch (Exception ex)
                {
                    DisplayErrorMessage(ex);
                }
            }
        }

        /// <summary>
        /// Displays the given exception as an error message.
        /// </summary>
        /// <param name="e">The exception to be displayed.</param>
        private void DisplayErrorMessage(Exception e)
        {
            MessageBox.Show("The following error occurred: " + e);
        }

        /// <summary>
        /// Rotates the given character c n positions through the alphabet whose first
        /// letter is firstLetter and whose number of letters is alphabetLen. alphabetLen
        /// must be positive.
        /// </summary>
        /// <param name="c">The character to rotate.</param>
        /// <param name="n">The number of positions to rotate c.</param>
        /// <param name="firstLetter">The first letter of the alphabet.</param>
        /// <param name="alphabetLen">The number of letters in the alphabet.</param>
        /// <returns>The result of the rotation.</returns>
        private char Rotate(char c, int n, char firstLetter, int alphabetLen)
        {
            return (char)(firstLetter + (c - firstLetter + n) % alphabetLen);
        }

        /// <summary>
        /// Determines whether or not a char needs to be encrypted and passes it
        /// along to the encryption method Rotate.
        /// </summary>
        /// <param name="temp"></param>
        /// <returns></returns>
        private char EncryptChar(char temp)
        {
            if(temp >= 'a' && temp <= 'z') 
            {
                return Rotate(temp, 13, 'a', 26);
            }
            else if (temp >= 'A' && temp <= 'Z')
            {
                return Rotate(temp, 13, 'A', 26);
            }
            return temp;
        }

        /// <summary>
        /// Copies chars one by one from the textbox for encryption.
        /// The resulting encrypted message is shown in the text box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void stringToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            string temp = uxDisplay.Text, result = "";
            for (int i = 0; i < temp.Length; i++)
            {
                result += EncryptChar(temp[i]);
            }
            uxDisplay.Text = result;
        }

        /// <summary>
        /// Same functionaliy as the previous method but using StringBuilder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void stringBuilderToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            string temp = uxDisplay.Text;
            for (int i = 0; i < temp.Length; i++)
            {
                sb.Append(EncryptChar(temp[i]));
            }
            uxDisplay.Text = sb.ToString();
        }
    }
}
