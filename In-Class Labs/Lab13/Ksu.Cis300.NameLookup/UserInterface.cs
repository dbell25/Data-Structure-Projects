/* NameInformation.cs
 * Author: Rod Howell
 * Modified By: Daniel Bell
 */
using System;
using Ksu.Cis300.NameLookup;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Ksu.Cis300.NameLookup
{
    public partial class UserInterface : Form
    {
        /// <summary>
        /// Field for storing linked list
        /// </summary>
        private LinkedListCell<NameInformation> _info;

        /// <summary>
        /// Initializes interface
        /// </summary>
        public UserInterface()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Opens a file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxOpen_Click(object sender, EventArgs e)
        {
            if (uxOpenDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _info = ReadIn(uxOpenDialog.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        /// <summary>
        /// Reads in the File
        /// </summary>
        /// <param name="FileName"></param>
        /// <returns></returns>
        private LinkedListCell<NameInformation> ReadIn(String FileName)
        {
            _info = null;
            LinkedListCell<NameInformation> info = new LinkedListCell<NameInformation>();
            using (StreamReader input = new StreamReader(FileName))
            {
                while (!input.EndOfStream)
                {
                    LinkedListCell<NameInformation> temp = new LinkedListCell<NameInformation>();
                    string Name = input.ReadLine().Trim();
                    float Frequency = Convert.ToSingle(input.ReadLine());
                    int Rank = Convert.ToInt32(input.ReadLine());
                    NameInformation x = new NameInformation(Name, Frequency, Rank);
                    temp.Data = x;
                    temp.Next = info;
                    info = temp;
                }
            }
            return info;
        }

        /// <summary>
        /// Searches for name matches
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxLookup_Click(object sender, EventArgs e)
        {
            LinkedListCell<NameInformation> temp = _info;
            string Name = uxName.Text.Trim().ToUpper();
            while (temp != null)
            {
                if (temp.Data.Name == Name)
                {
                    uxFrequency.Text = temp.Data.Frequency.ToString();
                    uxRank.Text = temp.Data.Rank.ToString();
                    return;
                }
                temp = temp.Next;
            }
            MessageBox.Show("Name not found");
        }
    }
}
