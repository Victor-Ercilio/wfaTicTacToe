using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal interface IPlayGame
    {
        Game.Move MoveTo { get; set; }
        int Score { get; set; }
        string Name { get; set; }
        char Mark {  get; set; }

    }
}
