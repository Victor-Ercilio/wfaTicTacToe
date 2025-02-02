using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public interface IPlayGame
    {
        int Score { get; set; }
        string Name { get; set; }
        char Mark {  get; set; }

        event EventHandler<MarkBoardEventArgs> MarkBoard;
        void MakeMark(BoardArea vertical, BoardArea horizontal);
    }
}
