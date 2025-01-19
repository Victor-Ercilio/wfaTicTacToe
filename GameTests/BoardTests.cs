using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe;
using Area = TicTacToe.Board.Area;

namespace TicTacToeTests
{
    internal class BoardTests
    {
        [Test]
        public void Constructor_NoArgs_ReturnsIntanceOfBoard()
        {
            Board board;

            board = new Board();

            Assert.That(board, Is.Not.Null);
            Assert.IsInstanceOf<Board>(board);
        }

        #region IntIndexer
        [Test]
        public void GetValueIntIndexer_ValueHasBeingSet_ReturnValue()
        {
            Board board = new Board();
            char actual;
            char expected = 'A';
            board[0, 0] = 'A';

            actual = board[0, 0];

            Assert.That(actual, Is.EqualTo(expected));
        }
        #endregion

        #region AreaIndexer
        [Test]
        public void GetValueAreaIndexer_ValueHasBeingSet_ReturnValue()
        {
            Board board = new Board();
            char actual;
            char expected = 'A';
            board[Area.Top, Area.Left] = 'A';

            actual = board[Area.Top, Area.Left];

            Assert.That(actual, Is.EqualTo(expected));
        }
        #endregion
    }
}
