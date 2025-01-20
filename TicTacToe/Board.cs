using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Board
    {
        protected char[,] board = new char[3,3];

        public char this[int i, int j]
        {
            get
            {
                return board[i,j];
            }
            set
            {
                board[i,j] = value;
            }
        }

        public char this[Area v, Area h]
        {
            get
            {
                return board[(int)v, (int)h];
            }
            set
            {
                board[(int)v, (int)h] = value;
            }
        }

        public enum Area
        {
            Top = 0,
            Center = 1,
            Bottom = 2,
            Left = Top,
            Right = Bottom,
        }
    }
}
