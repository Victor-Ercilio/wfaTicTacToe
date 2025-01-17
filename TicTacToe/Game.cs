using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    enum BoardPosition
    {
        Center,
        CenterLeft,
        CenterRight,
        UpperCenter,
        UpperLeft,
        UpperRight,
        BottomCenter,
        BottomLeft,
        BottomRight
    }

    internal class Game
    {
        public event EventHandler WaitingPlayerMove;
        public event EventHandler End;

        public delegate void Move(BoardPosition p);

        public IPlayGame[] _players;
        private int[,] _board;

        public const int NoMove = 0;
        public const int TotalMoves = 9;
        public Game(IPlayGame player1, IPlayGame player2)
        {
            Player1 = player1;
            Player2 = player2;
        }

        public IPlayGame[] Players
        {
            get { return _players; }

            private set
            {
                _players = value;
            }
        }

        public IPlayGame Player1 { get; private set; }
        public IPlayGame Player2 { get; private set; }
        public IPlayGame PlayerTurn {  get; private set; }
        public char[,] Board { get; private set; }
        public const int TotalPlayers = 2;
        public int MovesLeft { get; private set; }
        public bool HasEnded { get; private set; } = false;
        public bool HasWinner { get; private set; } = false;
        public string WinnerName { get; private set; }
        
        public void Start(object sender, EventArgs e)
        {
            InitializeBoard();
            MovesLeft = TotalMoves;
            HasEnded = false;
            HasWinner = false;
            WinnerName = "";

            AddMoves();

            Random coin = new Random();
            int firstToPlay = coin.Next(0, TotalPlayers);
            //PlayerTurn = Players[firstToPlay];
            PlayerTurn = (firstToPlay == 0) ? Player1 : Player2;
            WaitingPlayerMove?.Invoke(this, e);
        }

        private void AddMoves()
        {
            //foreach (var player in _players)
            //{
            //    player.MoveTo = OnMove;
            //}
            Player1.MoveTo += OnMove;
            Player2.MoveTo += OnMove;
        }

        private void RemoveMoves()
        {
            Player1.MoveTo -= OnMove;
            Player2.MoveTo -= OnMove;
        }

        public void OnMove(BoardPosition position)
        {
            switch (position)
            {
                case BoardPosition.Center:
                    RegisterMove(1, 1);
                    Board[1, 1] = PlayerTurn.Mark;
                    break;
                case BoardPosition.CenterLeft:
                    RegisterMove(1, 0);
                    Board[1, 0] = PlayerTurn.Mark;
                    break;
                case BoardPosition.CenterRight:
                    RegisterMove(1, 2);
                    Board[1, 2] = PlayerTurn.Mark;
                    break;
                case BoardPosition.UpperCenter:
                    RegisterMove(0, 1);
                    Board[0, 1] = PlayerTurn.Mark;
                    break;
                case BoardPosition.UpperLeft:
                    RegisterMove(0, 0);
                    Board[0, 0] = PlayerTurn.Mark;
                    break;
                case BoardPosition.UpperRight:
                    RegisterMove(0, 2);
                    Board[0, 2] = PlayerTurn.Mark;
                    break;
                case BoardPosition.BottomCenter:
                    RegisterMove(2, 1);
                    Board[2, 1] = PlayerTurn.Mark;
                    break;
                case BoardPosition.BottomLeft:
                    RegisterMove(2, 0);
                    Board[2, 0] = PlayerTurn.Mark;
                    break;
                case BoardPosition.BottomRight:
                    RegisterMove(2, 2);
                    Board[2, 2] = PlayerTurn.Mark;
                    break;
            }
            MovesLeft--;
            NextTurn();
        }

        private void InitializeBoard()
        {
            if (_board == null)
                _board = new int[3, 3];
            else
                ResetBoard();

            if(Board == null)
                Board = new char[3, 3];
            else
                ResetBoard();
        }

        private void ResetBoard()
        {
            int rows = _board.GetLength(0);
            int cols = _board.GetLength(1);

            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                {
                    _board[i, j] = NoMove;
                    Board[i, j] = '\0';
                }
        }
        private void RegisterMove(int x, int y)
        {
            if (x < 0 && x >= Board.GetLength(0))
                throw new ArgumentException($"x ({x}) is out of ange", "x");
            if (y < 0 && y >= Board.GetLength(1))
                throw new ArgumentException($"y ({y}) is out of ange", "y");
            
            
            if(PlayerTurn == Player1)
            {
                _board[x, y] = 1;
            }
            else
            {
                _board[x, y] = 2;
            }
        }

        private void NextTurn()
        {
            if(!EndGame())
            {
                if(PlayerTurn == Player1)
                {
                    PlayerTurn = Player2;
                }
                else
                {
                    PlayerTurn = Player1;
                }
                WaitingPlayerMove?.Invoke(this, EventArgs.Empty);
                //int actualPlayer = (PlayerTurn == Player1) ? 1 : 2;
                //int nextPlayer = (actualPlayer) % TotalPlayers;
                //PlayerTurn = Players[nextPlayer];
            }
            else 
            {
                if (HasWinner)
                    PlayerTurn.Score++;

                //foreach (var player in Players)
                //{
                //    player.Move -= RegisterMove;
                //    player.EndMove -= NextTurn;
                //}
                RemoveMoves();
                HasEnded = true;
                End?.Invoke(this, EventArgs.Empty);
            }
        }

        private bool EndWithWinner()
        {
            HasWinner = WinByColumn() || WinByDiagonal() || WinByRow();
            return HasWinner;
        }

        public bool EndGame()
        {
            return (EndWithWinner() || GameTied());
        }

        private bool GameTied()
        {
            return (MovesLeft == 0);
        }

        private bool WinByDiagonal()
        {
            
            if (Board[0, 0] != NoMove && Board[0, 0] == Board[1, 1] && Board[1, 1] == Board[2, 2])
                return true;
            else if (Board[0, 2] != NoMove && Board[0, 2] == Board[1, 1] && Board[1, 1] == Board[2, 0])
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

}
