using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealGame = TicTacToe.Game;
using RealPlayer = TicTacToe.Player;

namespace GameTests
{
    internal class Game
    {
        private readonly RealPlayer PlayerOne = new RealPlayer("Foo", 'F');
        private readonly RealPlayer PlayerTwo = new RealPlayer("Bar", 'B');

        [Test]
        public void Constructor_TwoDifferentPlayers_ReturnsInstance()
        {
            RealGame game;

            game = new RealGame(PlayerOne, PlayerTwo);

            Assert.IsInstanceOf<RealGame>(game);
        }

       
    }
}
