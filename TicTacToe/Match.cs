using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class Match
    {
        public readonly int NoMove = 0;
        public readonly int TotalMoves = 9;
        public Match(Player player1, Player player2)
        {
            Players = new List<Player>();

            player1.Move = UpdateTable;
            player2.Move = UpdateTable;

            player1.EndMove = NextTurn;
            player2.EndMove = NextTurn;
            
            Players.Add(player1);
            Players.Add(player2);

            Table = new int[3, 3];
            MovesLeft = TotalMoves;
        }

        public List<Player> Players { get; private set; }
        public Player PlayerTurn {  get; private set; }
        public int[,] Table { get; private set; }
        public int MovesLeft { get; private set; }
        public bool HasEnded { get; private set; } = false;
        public bool HasWinner { get; private set; } = false;
        
        public void Start()
        {
            Random coin = new Random();
            int firstToPlay = coin.Next(0, Players.Count);
            PlayerTurn = Players[firstToPlay];
        }

        public void UpdateTable(int x, int y)
        {
            if (x < 0 && x >= Table.GetLength(0))
                throw new ArgumentException($"x ({x}) is out of ange", "x");
            if (y < 0 && y >= Table.GetLength(1))
                throw new ArgumentException($"y ({y}) is out of ange", "y");
            
            MovesLeft--;
            Table[x, y] = Players.IndexOf(PlayerTurn) + 1;
        }

        public void NextTurn()
        {
            if(!EndGame())
            {
                int actualPlayer = Players.IndexOf(PlayerTurn);
                int nextPlayer = (actualPlayer + 1) % Players.Count;
                PlayerTurn = Players[nextPlayer];
            }
            else if (HasWinner)
            {
                PlayerTurn.Score++;
                HasEnded = true;
            }
            else
            {
                HasEnded = true;
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
            
            if (Table[0, 0] == Table[1, 1] && Table[1, 1] == Table[2, 2])
                return true;
            else if (Table[0, 2] == Table[1, 1] && Table[1, 1] == Table[2, 0])
                return true;
            return false;
        }

        private bool WinByColumn()
        {
            int cols = Table.GetLength(0);
            for (int i = 0; i < cols; i++)
            {
                if (Table[i, 0] == Table[i, 1] && Table[i, 1] == Table[i, 2])
                    return true;
            }
            return false;
        }

        private bool WinByRow()
        {
            int rows = Table.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                if (Table[0, i] == Table[1, i] && Table[1, i] == Table[2, i])
                    return true;
            }
            return false;
        }
    }
}
