using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ksu.Cis300.ParenthesisMatcher
{
    public partial class UserInterface : Form
    {
        public UserInterface()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Event handler for the check button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Stack<char> s = new Stack<char>();
            string temp = textBox1.Text;

            foreach (char i in temp)
            {
                if (s.Count == 0)
                {
                    if (IsClosingParenthesis(i))
                    {
                        ShowError();
                    }
                    else
                    {
                        s.Push(i);
                    }
                }
                else
                {
                    if (IsOpeningParenthesis(i)) 
                    {
                        s.Push(i);
                    }
                    else if(IsClosingParenthesis(i))
                    {
                        if (Matches(s.Peek(), i))
                        {
                            s.Pop();
                        }
                        else
                        {
                            ShowError();
                            return;
                        }
                    } 
                }
            }
            if (s.Count == 0)
            {
                ShowSuccess();
            }
            else
            {
                ShowError();
            }
        }

        /// <summary>
        /// Determines whether the given character is an opening parenthesis.
        /// </summary>
        /// <param name="c">The character to check.</param>
        /// <returns>Whether c is an opening parenthesis.</returns>
        private bool IsOpeningParenthesis(char c)
        {
            return c == '(' || c == '[' || c == '{';
        }

        /// <summary>
        /// Determines whether the given character is a closing parenthesis.
        /// </summary>
        /// <param name="c">The character to check.</param>
        /// <returns>Whether c is a closing parenthesis.</returns>
        private bool IsClosingParenthesis(char c)
        {
            return c == ')' || c == ']' || c == '}';
        }

        /// <summary>
        /// Determines whether the given characters for a matched pair
        /// of parentheses.
        /// </summary>
        /// <param name="a">The opening character.</param>
        /// <param name="b">The closing character.</param>
        /// <returns>Whether a and b form a matched pair of parentheses.</returns>
        private bool Matches(char a, char b)
        {
            return (a == '(' && b == ')') || (a == '[' && b == ']') ||
                (a == '{' && b == '}');
        }

        /// <summary>
        /// Displays a success message.
        /// </summary>
        private void ShowSuccess()
        {
            MessageBox.Show("The string is matched.");
        }

        /// <summary>
        /// Displays an error message.
        /// </summary>
        private void ShowError()
        {
            MessageBox.Show("The string is not matched.");
        }
    }
}
