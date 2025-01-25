using System;

namespace TicTacToe
{
    /// <include file='docs/board.xml' path='MyDocs/Doc[@name="Class"]'/>
    public class Board
    {
        protected char[,] board;

        /// <include file='docs/board.xml' path='MyDocs/Doc[@name="ConstEmptyArea"]'/>
        public const char EmptyArea = '\0';

        /// <include file='docs/board.xml' path='MyDocs/Doc[@name="Event:BoardChanged"]'/>
        public event EventHandler<BoardChangedEventArgs> BoardChanged;

        /// <include file='docs/board.xml' path='MyDocs/Doc[@name="EmptyConstructor"]'/>
        public Board() 
        {
            board = new char[3, 3];
            Clear();
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
                OnBoardChange(value, v, h);
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
                    board[i, j] = EmptyArea;
                    OnBoardChange(EmptyArea,(VerticalArea) i, (HorizontalArea) j);
                }
            }
                }

        /// <include file='docs/board.xml' path='MyDocs/Doc[@name="EventHandler:OnBoardChange"]'/>
        protected void OnBoardChange(char key, VerticalArea v, HorizontalArea h)
        {
            BoardChangedEventArgs args = new BoardChangedEventArgs
            {
                Key = key,
                VerticalArea = v,
                HorizontalArea = h
            };
            BoardChanged?.Invoke(this, args);
            }
        }

    public class BoardChangedEventArgs : EventArgs
    {
        public char Key;
        public Board.HorizontalArea HorizontalArea;
        public Board.VerticalArea VerticalArea;
    }
}
