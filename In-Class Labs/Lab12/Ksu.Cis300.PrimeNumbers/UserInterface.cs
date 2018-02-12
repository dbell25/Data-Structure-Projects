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

namespace Ksu.Cis300.PrimeNumbers
{
    /// <summary>
    /// A GUI for a program to find all prime numbers less than a given value.
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
        /// Handles a Click event on the "Find Primes" button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxFindPrimes_Click(object sender, EventArgs e)
        {
            LinkedListCell<int> primes = GetPrimesLessThan((int)uxInput.Value);
            uxPrimes.BeginUpdate();
            uxPrimes.Items.Clear();
            for (LinkedListCell<int> p = primes; p != null; p = p.Next)
            {
                uxPrimes.Items.Add(p.Data);
            }
            uxPrimes.EndUpdate();
        }

        /// <summary>
        /// Forms a linked list containing all prime numbers less than the given value.
        /// </summary>
        /// <param name="value">The upper limit (exclusive) on the prime numbers to generate.</param>
        /// <returns>A linked list containing all the prime numbers less than value.</returns>
        private LinkedListCell<int> GetPrimesLessThan(int value)
        {
            LinkedListCell<int> x = GetNumbersLessThan(value);
            LinkedListCell<int> temp = x;
            while(temp != null)
            {
                RemoveMultiples(temp.Data, temp);
                temp = temp.Next;
            }
            return x;
        }

        /// <summary>
        /// Returns a linked list beginning at 2 and is less than n
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        private LinkedListCell<int> GetNumbersLessThan(int n)
        {
            LinkedListCell<int> temp = new LinkedListCell<int>();

            for(int i = n-1; i > 1; i--)
            {
                LinkedListCell<int> cell = new LinkedListCell<int>();
                cell.Data = i;
                cell.Next = temp;
                temp = cell;
            }
            return temp;
        }

        /// <summary>
        /// Removes non-prime values from the linked list
        /// </summary>
        /// <param name="k"></param>
        /// <param name="list"></param>
        private void RemoveMultiples(int k, LinkedListCell<int> list)
        {
            while(list.Next != null)
            {
                if (list.Next.Data % k == 0)
                    list.Next = list.Next.Next;
                else
                    list = list.Next;
            }
        }
    }
}
