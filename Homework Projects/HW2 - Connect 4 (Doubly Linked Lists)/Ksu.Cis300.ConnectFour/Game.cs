/* Game.cs
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
    class Game
    {
        /// <summary>
        /// Declares Column Size.
        /// </summary>
        public const int ColumnSize = 6;

        /// <summary>
        /// Sets up possible player color options.
        /// </summary>
        public enum PlayersTurn
        {
            Red,
            Black
        }

        /// <summary>
        /// Creates a field for column data.
        /// </summary>
        private DoubleLinkedListCell<DoubleLinkedListCell<GamePiece>> _column;

        /// <summary>
        /// Initializes an array of player colors.
        /// </summary>
        public readonly Color[] PlayerColors = {Color.Red, Color.Black};

        /// <summary>
        /// creates a field for turn data.
        /// </summary>
        private PlayersTurn _turn;

        /// <summary>
        /// Gets and sets turn data.
        /// </summary>
        public PlayersTurn Turn
        {
            get
            {
                return _turn;
            }
            set
            {
                _turn = value;
            }
        }

        /// <summary>
        /// Gets and sets the Column values.
        /// </summary>
        public DoubleLinkedListCell<DoubleLinkedListCell<GamePiece>> Column
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

        /// <summary>
        /// Sets _column to the cell cooresponding with the column ID
        /// </summary>
        /// <param name="columnid"></param>
        public void FindColumn(string columnid)
        {
            bool right = true;
            while (columnid != _column.Id)
            {
                if (_column.Next == null) right = false;
                if (right)
                {
                    _column = _column.Next;
                }
                else
                {
                    _column = _column.Prev;
                }
            }
        }

        /// <summary>
        /// Finds a particular cell.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DoubleLinkedListCell<GamePiece> FindCell(string id)
        {
            FindColumn(id[0].ToString());
            DoubleLinkedListCell<GamePiece> cell = _column.Data;
            while (cell != null)
            {
                if (cell.Id == id)
                {
                    return cell;
                }
                else
                {
                    cell = cell.Prev;
                }
            }
            return null;
        }
       
        /// <summary>
        /// Checks for four continous pieces in any direction.
        /// </summary>
        /// <param name="cell"></param>
        /// <returns></returns>
        public bool CheckWin(DoubleLinkedListCell<GamePiece> cell)
        {
            int row = cell.Data.Row;
            char col = cell.Data.Column;

            if (Check(row, col, -1, -1, cell.Data.PieceColor)) return true;
            if (Check(row, col, -1, 1, cell.Data.PieceColor)) return true;
            if (Check(row, col, 0, 1, cell.Data.PieceColor)) return true;
            if (Check(row, col, 1, 0, cell.Data.PieceColor)) return true;
            else return false;
        }

        /// <summary>
        /// Performs the actual check for the above method.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="rowDirection"></param>
        /// <param name="colDirection"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        private bool Check(int row, char col, int rowDirection, int colDirection, Color color)
        {
            bool both = false, track = true;

            for(int i = 0; i <= 4; i++)
            {
                if (0 < row && row <= ColumnSize && col >= 'A' && col <= 'G')
                {
                    DoubleLinkedListCell<GamePiece> x = FindCell(col.ToString() + row);
                    if (x == null)
                    {
                        if (both)
                        {
                            track = false;
                            break;
                        }
                        else
                        {
                            rowDirection = rowDirection * -1;
                            colDirection = colDirection * -1;
                            both = true;
                            i = 0;
                        }
                    }
                    else if (x.Data.PieceColor != color)
                    {
                        if (both)
                        {
                            track = false;
                            break;
                        }
                        else
                        {
                            rowDirection = rowDirection * -1;
                            colDirection = colDirection * -1;
                            both = true;
                            i = 0;
                        }
                    }
                }
                else
                {
                    if (both)
                    {
                        track = false;
                        break;
                    }
                    else
                    {
                        rowDirection = rowDirection * -1;
                        colDirection = colDirection * -1;
                        both = true;
                        i = 0;
                    }
                }
                row += rowDirection;
                col = (char)(col + colDirection);
            }
            return track;
        }
    }
}