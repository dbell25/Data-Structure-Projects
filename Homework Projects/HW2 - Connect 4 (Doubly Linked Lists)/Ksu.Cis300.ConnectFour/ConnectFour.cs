/* ConnectFour.cs
 * Author: Daniel Bell
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

namespace Ksu.Cis300.ConnectFour
{
    public partial class ConnectFour : Form
    {
        /// <summary>
        /// Initializes a new game.
        /// </summary>
        private Game _game = new Game();

        /// <summary>
        /// Keeps track of full columns to determine a draw.
        /// </summary>
        private int _count = 0;
        
        /// <summary>
        /// Initializes the Connect Four interface.
        /// </summary>
        public ConnectFour()
        {
            InitializeComponent();
            uxTurnLabel.BackColor = Color.Red;
            uxTurnLabel.Text = "Red";

            for (int i = 'A'; i < 'A' + 7; i++)
            {
                DoubleLinkedListCell<DoubleLinkedListCell<GamePiece>> c 
                    = new DoubleLinkedListCell<DoubleLinkedListCell<GamePiece>>(((char)i).ToString());
                if (_game.Column != null)
                {
                    _game.Column.Next = c;
                }
                c.Prev = _game.Column;
                _game.Column = c;

                Button temp = new Button();
                temp.Name = ((char)i).ToString();
                temp.Text = ((char)i).ToString();
                temp.Width = 45;
                temp.Height = 20;
                temp.Margin = new Padding(5);
                uxPlaceButtonContainer.Controls.Add(temp);
                temp.Click += new EventHandler(uxPlaceButtonClick);

                for (int j = Game.ColumnSize; j > 0; j--)
                {
                    Label slot = new Label();
                    slot.Width = 45;
                    slot.Height = 45;
                    slot.Margin = new Padding(5);
                    slot.BackColor = Color.White;
                    slot.Name = ((char)i).ToString() + j;
                    uxBoardContainer.Controls.Add(slot);
                }
            }
        }

        /// <summary>
        /// Handles the button click of the top row of buttons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void uxPlaceButtonClick(object sender, EventArgs e)
        {
            Color color;
            string temp = ((Button)sender).Text;

            _game.FindColumn(temp);
            DoubleLinkedListCell<GamePiece> cell = _game.Column.Data;

            if (_game.Turn == Game.PlayersTurn.Red)
            {
                color = Color.Red;
                _game.Turn = Game.PlayersTurn.Black;
                uxTurnLabel.BackColor = Color.Black;
                uxTurnLabel.ForeColor = Color.White;
                uxTurnLabel.Text = "Black";
            }
            else
            {
                color = Color.Black;
                _game.Turn = Game.PlayersTurn.Red;
                uxTurnLabel.BackColor = Color.Red;
                uxTurnLabel.ForeColor = Color.Black;
                uxTurnLabel.Text = "Red";
            }

            if (_game.Column.Data == null)
            {
                _game.Column.Data = new DoubleLinkedListCell<GamePiece>(temp + 1);
                _game.Column.Data.Data = new GamePiece(color, 1, Convert.ToChar(temp));
                SetColor(_game.Column.Data.Id, _game.Column.Data.Data.PieceColor);
            }
            else
            {
                int r = _game.Column.Data.Data.Row + 1;
                GamePiece gp = new GamePiece(color, r, Convert.ToChar(temp));
                DoubleLinkedListCell<GamePiece> TempCell = new DoubleLinkedListCell<GamePiece>(temp + r);
                TempCell.Data = gp;
                TempCell.Prev = _game.Column.Data;

                _game.Column.Data.Next = TempCell;
                _game.Column.Data = TempCell;
                SetColor(_game.Column.Data.Id, _game.Column.Data.Data.PieceColor);

                if (r == Game.ColumnSize)
                {
                    ((Button)sender).Enabled = false;
                    _count++;
                    if (_count == 7)
                    {
                        MessageBox.Show("Draw!");
                        Environment.Exit(0);
                    }
                }
            }

            if (_game.CheckWin(_game.Column.Data))
            {
                if (_game.Turn == Game.PlayersTurn.Black)
                {
                    MessageBox.Show("Red has won!");
                    Environment.Exit(0);
                }
                else if ((_game.Turn == Game.PlayersTurn.Red))
                {
                    MessageBox.Show("Black has won!");
                    Environment.Exit(0);
                }   
            }
        }

        /// <summary>
        /// Method for setting the color piece on the board.
        /// </summary>
        /// <param name="column"></param>
        /// <param name="player"></param>
        private void SetColor(string column, Color player)
        {
            ((Label)uxBoardContainer.Controls.Find(column, true)[0]).BackColor = player;
        }
    }
}