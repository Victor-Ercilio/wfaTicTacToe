using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TicTacToe;
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

        [Test]
        public void GameState_GameIsBuiltButNotStarted_StateShouldBeInitialize()
        {
            RealGame game = new RealGame(PlayerOne, PlayerTwo);
            RealGame.EState actual;
            RealGame.EState expected = RealGame.EState.Initialize;

            actual = game.State;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void StartMatch_Calling_ShouldTriggerMatchStartedAndWaitingPlayerEvent()
        {
            RealGame game = new RealGame(PlayerOne, PlayerTwo);
            bool startCall = false;
            bool waintingPlayerCall = false;
            game.Match_Start += (o, e) => startCall = true;
            game.Match_WaitingPlayer += (o, e) => waintingPlayerCall = true;

            game.StartMatch(null, EventArgs.Empty);

            Assert.That(startCall, Is.True);
            Assert.That(waintingPlayerCall, Is.True);
        }

        [Test]
        public void GameState_StartMatchHasBeingCall_ShouldChangeStateToStartAndThenToWaitingPlayer()
        {
            Assert.Pass();
        }
    }
}
