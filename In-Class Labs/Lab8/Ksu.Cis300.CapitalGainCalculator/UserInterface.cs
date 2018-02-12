/* UserInterface.cs
 * Author: Rod Howell
 * Modified BY: Daniel Bell
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

namespace Ksu.Cis300.CapitalGainCalculator
{
    /// <summary>
    /// A user interface for a simple captial gain calculator for a single stock commodity.
    /// </summary>
    public partial class UserInterface : Form
    {
        private Queue<decimal> costs = new Queue<decimal>();

        /// <summary>
        /// Constructs the GUI.
        /// </summary>
        public UserInterface()
        {
            InitializeComponent();
        }

        private void uxBuy_Click(object sender, EventArgs e)
        {
            decimal NumShares = uxNumber.Value, CurrentShares = Convert.ToDecimal(uxOwned.Text);
            for(int i = 0; i < NumShares; i++)
            {
                costs.Enqueue(uxCost.Value);
            }
            uxOwned.Text = costs.Count.ToString();
        }

        private void uxSell_Click(object sender, EventArgs e)
        {
            decimal CurrentGains = Convert.ToDecimal(uxGain.Text);
            if (uxNumber.Value > costs.Count)
            {
                MessageBox.Show("You don't own that many shares, please try again.");
            }
            else
            {
                
                int NumShares = (int)uxNumber.Value;
                for (int i = 0; i < NumShares; i++)
                {
                    decimal temp = costs.Dequeue();
                    CurrentGains += (uxCost.Value - temp);
                }
                uxOwned.Text = (costs.Count.ToString());
                uxGain.Text = CurrentGains.ToString();
            }
        }
    }
}
