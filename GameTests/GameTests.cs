using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealGame = TicTacToe.Game;
using RealPlayer = TicTacToe.Player;

namespace GameTests
{
    internal class GameTests
    {
        private readonly RealPlayer PlayerOne = new RealPlayer("Foo", 'F');
        private readonly RealPlayer PlayerTwo = new RealPlayer("Bar", 'B');

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Constructor_TwoDifferentPlayers_ReturnsInstance()
        {
            RealGame game;

            game = new RealGame(PlayerOne, PlayerTwo);

            Assert.IsNotNull(game);
            Assert.IsInstanceOf<RealGame>(game);
        }

       
    }
}
