using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.Nim
{
    public class Board
    {
        /// <summary>
        /// The number of stones on each pile.
        /// </summary>
        private int[] _piles;

        /// <summary>
        /// The limit for each pile.
        /// </summary>
        private int[] _limits;

        /// <summary>
        /// Gets the number of piles.
        /// </summary>
        public int NumberOfPiles
        {
            get
            {
                return _piles.Length;
            }
        }

        /// <summary>
        /// Gets the number of stones on the given pile.
        /// </summary>
        /// <param name="pile">The pile.</param>
        /// <returns>The number of stones on the given pile.</returns>
        public int GetValue(int pile)
        {
            if (pile < 0 || pile >= _piles.Length)
            {
                throw new ArgumentException();
            }
            return _piles[pile];
        }

        /// <summary>
        /// Gets the limit for the given pile.
        /// </summary>
        /// <param name="pile">The pile.</param>
        /// <returns>The limit for the given pile.</returns>
        public int GetLimit(int pile)
        {
            if (pile < 0 || pile >= _piles.Length)
            {
                throw new ArgumentException();
            }
            return _limits[pile];
        }

        /// <summary>
        /// Public constructor for creating a new board.
        /// </summary>
        /// <param name="pile"></param>
        /// <param name="limit"></param>
        public Board(int[] pile, int[] limit)
        {
            if (pile.Length != limit.Length)
            {
                throw new ArgumentException();
            }
            int[] temp1 = new int[pile.Length], temp2 = new int[limit.Length];

            for (int i = 0; i < pile.Length; i++)
            {
                temp1[i] = pile[i];
                temp2[i] = limit[i];
            }
            _piles = temp1;
            _limits = temp2;
        }

        /// <summary>
        /// Add a definition for the == operator to compare two Boards.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bool operator ==(Board x, Board y)
        {
            if (Equals(x, null))
            {
                return (Equals(y, null));
            }
            else if (Equals(y, null))
            {
                return false;
            }
            else
            {
                if (x._piles.Length != y._limits.Length) return false;
                else
                {
                    for (int i = 0; i < x._piles.Length; i++)
                    {
                        if (x._piles[i] != y._limits[i]) return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Add a definition for the != operator to compare two Boards.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bool operator !=(Board x, Board y)
        {
            return !(x == y);
        }

        /// <summary>
        /// Add definitions for the Equals operator.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object x)
        {
            if (x is Board)
            {
                return this == (Board)x;
            }
            else
            {
                return false;
            }
        }
    }
}
