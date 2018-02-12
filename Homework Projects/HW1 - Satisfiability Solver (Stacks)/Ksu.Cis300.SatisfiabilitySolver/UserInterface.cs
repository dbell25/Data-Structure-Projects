/* CIS 300 Homework 1
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

namespace Ksu.Cis300.SatisfiabilitySolver
{
    public partial class UserInterface : Form
    {
        /// <summary>
        /// Initializes the form
        /// </summary>
        public UserInterface()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the button click and allows the user to select a file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog file1 = new OpenFileDialog();
            file1.Filter = " Text files|*.txt|All files|*.*  ";

            if (file1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    uxTextBox.Text = "";
                    Update();
                    string[] input = File.ReadAllLines(file1.FileName);
                    int count = Convert.ToInt32(input[0]);
                    bool[] temp = Solver.Solve(input, count);

                    if (temp == null) MessageBox.Show("No Solution Found.");
                    else DisplaySolution(temp);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        /// <summary>
        /// Displays the output of the solver class
        /// </summary>
        private void DisplaySolution(bool[]a)
        {
            StringBuilder sb = new StringBuilder();
            for(int i = 0; i < a.Length; i++)
            {
                if (a[i])
                {
                    sb.Append(Convert.ToChar(i + 'a'));
                }
                else
                {
                    sb.Append(Convert.ToChar(i + 'A'));
                }
            }
            uxTextBox.Text = sb.ToString();
        }
    }
}
