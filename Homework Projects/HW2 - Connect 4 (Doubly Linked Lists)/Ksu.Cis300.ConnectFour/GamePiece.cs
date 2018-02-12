/* GamePiece.cs
 * Author: Daniel Bell
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Ksu.Cis300.ConnectFour
{
    class GamePiece
    {
        /// <summary>
        /// Private fields for storing data.
        /// </summary>
        private Color _pieceColor;
        private int _row;
        private char _column;

        /// <summary>
        /// A constructor for initializing gamepieces
        /// </summary>
        /// <param name="color"></param>
        /// <param name="row"></param>
        /// <param name="column"></param>
        public GamePiece(Color color, int row, char column)
        {
            _pieceColor = color;
            _row = row;
            _column = column;
        }

        /// <summary>
        /// Gets and sets a piece's color.
        /// </summary>
        public Color PieceColor
        {
            get
            {
                return _pieceColor;
            }
            set
            {
                _pieceColor = value;
            }
        }

        /// <summary>
        /// Gets and sets a piece's row.
        /// </summary>
        public int Row
        {
            get
            {
                return _row;
             }
            set
            {
                _row = value;
            }
        }

        /// <summary>
        /// Gets and sets a piece's column.
        /// </summary>
        public char Column
        {
            get
            {
                return _column;
            }
            set
            {
                _column = value;
            }
        }
    }
}