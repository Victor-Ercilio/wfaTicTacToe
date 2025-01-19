using System;
using System.Linq;

namespace TicTacToe
{
    public enum BoardArea
    {
        Top = 0,
        Center  = 1,
        Bottom = 2,
        Left = Top,
        Right = Bottom
    }

    public class Game
    {
        #region Game Events
        public event EventHandler Match_Initialize;
        public event EventHandler Match_Start;
        public event EventHandler Match_WaitingPlayer;
        public event EventHandler Match_HasWinner;
        public event EventHandler Match_End;
        public event EventHandler<BoardChangedEventArgs> BoardChanged;
        #endregion

        public enum EState
        {
            Initialize,
            Start,
            WaitingPlayer,
            PlayerMoved,
            MatchHasWinner,
            End
        }

        private IPlayGame[] _players;
        private EState _state;
        private IPlayGame _playerTurn;
        private IPlayGame _playerWinner;

        public const char NoMove = '\0';
        public const int MinimunMoves = 3;
        public const int TotalMoves = 9;
        public Game(IPlayGame player1, IPlayGame player2)
        {
            State = EState.Initialize;
            _players[0] = player1;
            _players[1] = player2;
        }

        public IPlayGame[] Players
        {
            get { return _players; }
        }
        public IPlayGame PlayerTurn
        {
            get
            {
                return _playerTurn;
            }
            private set
            {
                _playerTurn = value;
                if(value != null)
                    State = EState.WaitingPlayer;
            }
        }
        public IPlayGame Winner
        {
            get
            {
                return _playerWinner;
            }
            private set
            {
                if(value != null && Players.Contains(value))
                {
                    _playerWinner = value;
                    State = EState.HasWinner;
                }
                else if(value == null)
                {
                    _playerWinner = null;
            }
        }
        }
        public char[,] Board { get; private set; } = null;
        public int MovesLeft { get; private set; } = 0;
        public bool HasWinner()
        {
            return WinByColumn() || WinByDiagonal() || WinByRow();
        }

        public EState State
        {
            get { return _state; }
            private set
            {
                _state = value;
                switch (value)
                {
                    case EState.Initialize:
                        OnInitialize();  break;
                    case EState.Start:
                        OnMatchStart(); break;
                    case EState.WaitingPlayer:
                        OnWaitingPlayer(); break;
                    case EState.HasWinner:
                        OnMatchHasWinner(); break;
                    case EState.End:
                        OnMatchEnd(); break;
                }
            }
        }

        protected void OnInitialize()
        {
            try
            {
                Board = Board ?? new char[3, 3];
                _players = _players ?? new IPlayGame[2];
                ResetBoard();
                ResetGame();

                Match_Initialize?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected void OnMatchStart()
        {
            try
            {
                ResetBoard();
                ResetGame();
                SubscribeToPlayersMovements();
                Match_Start?.Invoke(this, EventArgs.Empty);

                SortFirstPlayer();
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected void OnWaitingPlayer()
        {
            try
            {
                Match_WaitingPlayer?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected void OnPlayerMoved(object sender, MarkBoardEventArgs e)
        {
            try
            {
                State = EState.PlayerMoved;

                int i = (int)e.Vertical;
                int j = (int)e.Horizontal;

                if (Board[i, j] == NoMove)
                {
                    Board[i, j] = PlayerTurn.Mark;
                    BoardChanged?.Invoke(sender, e);
                    MovesLeft--;
                }

                if (HasWinner())
                {
                    State = EState.HasWinner;
                }
                else if (GameTied())
                {
                    State = EState.End;
                }
                else
                {
                    PlayerTurn = (Players[0] == PlayerTurn ? Players[1] : Players[0]);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected void OnMatchHasWinner()
        {
            try
            {
                Winner = PlayerTurn;
                Winner.Score++;
                Match_HasWinner?.Invoke(this, EventArgs.Empty);
                State = EState.End;
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected void OnMatchEnd()
        {
            try
            {
                UnsubscribeToPlayerMoviment();
                Match_End?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void PlayerMove(object sender, MarkBoardEventArgs e)
        {
            try
            {
                bool validGameState = State != EState.Initialize || State != EState.End;
                bool validHorizontalArea = e.Horizontal == BoardArea.Left || e.Horizontal == BoardArea.Center || e.Horizontal == BoardArea.Right;
                bool validVerticalArea = e.Vertical == BoardArea.Top || e.Vertical == BoardArea.Center || e.Vertical == BoardArea.Bottom;
                
                if (validGameState && validHorizontalArea && validVerticalArea)
                    OnPlayerMoved(sender, e);
                else if(!validGameState)
                    throw new InvalidOperationException("Start a match to play!");
                else if(!validHorizontalArea)
                    throw new ArgumentException($"Horizontal Area can not be ${e.Horizontal}.");
                else
                    throw new ArgumentException($"Vertical Area can not be ${e.Vertical}.");
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void StartMatch(object sender, EventArgs e)
        {
            try
            {
                State = EState.Start;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void SubscribeToPlayersMovements()
        {
            foreach (var player in _players)
            {
                player.MarkBoard += PlayerMove;
            }
        }
        private void UnsubscribeToPlayerMoviment()
        {
            foreach (var player in _players)
            {
                player.MarkBoard -= PlayerMove;
            }
        }
        private void SortFirstPlayer()
        {
            Random coin = new Random();
            int index = coin.Next(0, Players.Length);
            PlayerTurn = Players[index];
        }

        private void ResetBoard()
        {
            int rows = Board.GetLength(0);
            int cols = Board.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Board[i, j] = NoMove;
                }
            }
        }
        private void ResetGame()
        {
            PlayerTurn = null;
            Winner = null;
            MovesLeft = TotalMoves;
        }
        private bool GameTied()
        {
            return (MovesLeft == NoMove);
        }
        private bool WinByDiagonal()
        {

            if (Board[0, 0] != NoMove && Board[0, 0] == Board[1, 1] && Board[1, 1] == Board[2, 2])
                return true;
            if (Board[0, 2] != NoMove && Board[0, 2] == Board[1, 1] && Board[1, 1] == Board[2, 0])
                return true;
            return false;
        }
        private bool WinByColumn()
        {
            int cols = Board.GetLength(0);
            for (int i = 0; i < cols; i++)
            {
                if (Board[i, 0] != NoMove && Board[i, 0] == Board[i, 1] && Board[i, 1] == Board[i, 2])
                    return true;
            }
            return false;
        }
        private bool WinByRow()
        {
            int rows = Board.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                if (Board[0, i] != NoMove && Board[0, i] == Board[1, i] && Board[1, i] == Board[2, i])
                    return true;
            }
            return false;
        }
    }

    public class BoardChangedEventArgs : EventArgs
    {
        public BoardArea Vertical;
        public BoardArea Horizontal;
    }

    public class MarkBoardEventArgs : BoardChangedEventArgs { }

}
