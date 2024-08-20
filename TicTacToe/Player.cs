using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    internal class Player : IScore
    {
        public delegate void Action(int x, int y);
        public delegate void ActionEnd();
        public Player(string name, string mark)
        {
            Name = name;
            Score = 0;
            Mark = mark;
        }

        public string Name { get; set; }
        public int Score { get; set; }
        public string Mark {  get; set; }
        public Action Move { get; set; }
        public ActionEnd EndMove { get; set; }

        public void ExecuteMoveTo(int x, int y)
        {
            Move(x, y);
            EndMove();
        }
    }
}
