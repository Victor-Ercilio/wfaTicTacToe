using System;

namespace TicTacToe
{
    /// <include file='docs/board.xml' path='MyDocs/Doc[@name="Class"]'/>
    public class Board
    {
        protected char[,] board;

        /// <include file='docs/board.xml' path='MyDocs/Doc[@name="EmptyConstructor"]'/>
        public Board() 
        {
            board = new char[3, 3];
            Clear();
        }

        /// <include file='docs/board.xml' path='MyDocs/Doc[@name="IntIndexer"]'/>
        public char this[int i, int j]
        {
            get
            {
                try
                {
                    ValidateIntIndexers(i, j);
                    return board[i,j];
                }
                catch (Exception)
                {
                    throw;
                }
            }
            set
            {
                try
                {
                    ValidateIntIndexers(i,j);
                    board[i,j] = value;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        /// <include file='docs/board.xml' path='MyDocs/Doc[@name="AreaIndexer"]'/>
        public char this[VerticalArea v, HorizontalArea h]
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

        /// <include file='docs/board.xml' path='MyDocs/Doc[@name="Enum:VerticalArea"]'/>
        public enum VerticalArea
        {
            Top = 0,
            Center = 1,
            Bottom = 2,
        }

        /// <include file='docs/board.xml' path='MyDocs/Doc[@name="Enum:HorizontalArea"]'/>
        public enum HorizontalArea
        {
            Left = 0,
            Center = 1,
            Right = 2
        }

        /// <include file='docs/board.xml' path='MyDocs/Doc[@name="Func:ValidateIntIndexers"]'/>
        private void ValidateIntIndexers(int i, int j)
        {
            if (i <= 0 || i >= board.GetLength(0))
                throw new ArgumentException($"Indexer i is out of range (0 <= i <= {board.GetLength(0)}).");
            if (j <= 0 || j >= board.GetLength(1))
                throw new ArgumentException($"Indexer j is out of range (0 <= j <= {board.GetLength(1)}).");
        }

        /// <include file='docs/board.xml' path='MyDocs/Doc[@name="Func:Clear"]'/>
        public void Clear()
        {
            for(int i = 0; i < board.GetLength(0); i ++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    board[i, j] = '\0';
                }
            }
        }
    }
}
