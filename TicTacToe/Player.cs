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
        public Game.Move MoveTo { get; set; }

        //public action move { get; set; }
        //public actionend endmove { get; set; }

        //public void executemoveto(int x, int y)
        //{
        //    move(x, y);
        //    endmove();
        //}
    }
}
