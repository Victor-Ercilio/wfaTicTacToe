using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    internal class Player : IPlayGame
    {
        public Player(string name, char mark)
        {
            Name = name;
            Mark = Char.ToUpper(mark);
            Score = 0;
        }

        public string Name { get; set; }
        public int Score { get; set; }
        public char Mark {  get; set; }

        public event EventHandler<MarkBoardEventArgs> MarkBoard;
        
        void IPlayGame.MakeMark(BoardArea vertical, BoardArea horizontal)
        {
            try
            {
                MarkBoardEventArgs e = new MarkBoardEventArgs
                {
                    Vertical = vertical,
                    Horizontal = horizontal
                };
                OnMarkedBoard(this, e);
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }

        protected void OnMarkedBoard(object sender, MarkBoardEventArgs e)
        {
            try
            {
                MarkBoard?.Invoke(this, e);
            }catch(Exception ex)
            {
                throw ex;
            }
        }

    }

}
