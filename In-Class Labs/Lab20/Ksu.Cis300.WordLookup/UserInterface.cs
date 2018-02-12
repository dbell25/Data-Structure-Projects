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

namespace Ksu.Cis300.WordLookup
{
    public partial class UserInterface : Form
    {
        public UserInterface()
        {
            InitializeComponent();
        }
        private Trie _dictionary;

        /// <summary>
        /// Opens a file to be used as the dictionary of words.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxOpen_Click(object sender, EventArgs e)
        {
            if (uxOpenDialog.ShowDialog() == DialogResult.OK)
            {
                _dictionary = new Trie();
                try
                {
                    using (StreamReader input = File.OpenText(uxOpenDialog.FileName))
                    {
                        while (!input.EndOfStream)
                        {
                            string word = input.ReadLine();
                            _dictionary.Add(word);
                        }
                    }
                    MessageBox.Show("Dictionary successfully read.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        /// <summary>
        /// Uses the Trie class to search for a given word in the dictionary.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxLookUp_Click(object sender, EventArgs e)
        {
            if (_dictionary.Contains(uxWord.Text))
            {
                MessageBox.Show("The word is found.");
            }
            else
            {
                MessageBox.Show("The word is not found.");
            }
        }
    }
}
