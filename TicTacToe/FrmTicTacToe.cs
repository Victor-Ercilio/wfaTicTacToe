using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class FrmTicTacToe : Form
    {
        private readonly Player playerX;
        private readonly Player playerO; 
        private readonly Game game;

        public FrmTicTacToe()
        {
            InitializeComponent();
            playerX = new Player("The Boss", 'X');
            playerO = new Player("Batman", 'O');
            game = new Game(playerX, playerO);

            btnStart.Click += game.StartMatch;

            game.Match_HasWinner += OnScoreChange;
            game.Match_Start += OnMatchStart;
            game.BoardChanged += OnBoardChange;
            game.Match_WaitingPlayer += OnWaitingPlayer;
            game.Match_End += OnMatchEnd;
        }

        #region Methods
        private void OnScoreChange(object sender, EventArgs e)
        {
            txtScorePlayer1.Text = playerX.Score.ToString();
            txtScorePlayer2.Text = playerO.Score.ToString();
        }
        private void OnMatchStart(object sender, EventArgs e)
        {
            lblPlayer1.Text = playerX.Name;
            lblPlayer2.Text = playerO.Name;
        }
        private void OnBoardChange(object sender, BoardChangedEventArgs e)
        {
            IPlayGame player = (IPlayGame)sender;
            if(e.Vertical == BoardArea.Top)
                switch (e.Horizontal)
                {
                    case BoardArea.Left: 
                        lblAreaNW.Text = player.Mark.ToString(); break;
                    case BoardArea.Center: 
                        lblAreaN.Text = player.Mark.ToString(); break;
                    case BoardArea.Right: 
                        lblAreaNE.Text = player.Mark.ToString(); break;
                }
            else if(e.Vertical == BoardArea.Center)
                switch (e.Horizontal)
                {
                    case BoardArea.Left:
                        lblAreaW.Text = player.Mark.ToString(); break;
                    case BoardArea.Center:
                        lblAreaO.Text = player.Mark.ToString(); break;
                    case BoardArea.Right:
                        lblAreaE.Text = player.Mark.ToString(); break;
                }
            else
                switch (e.Horizontal)
                {
                    case BoardArea.Left:
                        lblAreaSW.Text = player.Mark.ToString(); break;
                    case BoardArea.Center:
                        lblAreaS.Text = player.Mark.ToString(); break;
                    case BoardArea.Right:
                        lblAreaSE.Text = player.Mark.ToString(); break;
                }
        }
        private void OnWaitingPlayer(object sender, EventArgs e)
        {
            lblResult.Text = $"Your turn {game.PlayerTurn.Name}";
        }
        private void OnMatchEnd(object sender, EventArgs e)
        {
            if (game.HasWinner())
                lblResult.Text = $"{game.Winner.Name} win!!";
            else
                lblResult.Text = "No winners this time";
        }
        #endregion

        #region Game Area
        private void LblAreaNW_Click(object sender, EventArgs e)
        {
            try
            {
                game.PlayerTurn.MakeMark(BoardArea.Top, BoardArea.Left);
            }
            catch (NullReferenceException ex)
            {
                lblResult.Text = ex.Message;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LblAreaN_Click(object sender, EventArgs e)
        {
            try 
            { 
                game.PlayerTurn.MakeMark(BoardArea.Top, BoardArea.Center);
            }
            catch (NullReferenceException ex)
            {
                lblResult.Text = ex.Message;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LblAreaNE_Click(object sender, EventArgs e)
        {
            try 
            { 
                game.PlayerTurn.MakeMark(BoardArea.Top, BoardArea.Right);
            }
            catch (NullReferenceException ex)
            {
                lblResult.Text = ex.Message;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LblAreaW_Click(object sender, EventArgs e)
        {
            try
            {
                game.PlayerTurn.MakeMark(BoardArea.Center, BoardArea.Left);
            }            
            catch (NullReferenceException ex)
            {
                lblResult.Text = ex.Message;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LblAreaO_Click(object sender, EventArgs e)
        {
            try
            {        
                game.PlayerTurn.MakeMark(BoardArea.Center, BoardArea.Center);
            }
            catch (NullReferenceException ex)
            {
                lblResult.Text = ex.Message;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LblAreaE_Click(object sender, EventArgs e)
        {
            try
            {        
                game.PlayerTurn.MakeMark(BoardArea.Center, BoardArea.Right);
            }
            catch (NullReferenceException ex)
            {
                lblResult.Text = ex.Message;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LblAreaSW_Click(object sender, EventArgs e)
        {
            try
            {        
                game.PlayerTurn.MakeMark(BoardArea.Bottom, BoardArea.Right);
            }
            catch (NullReferenceException ex)
            {
                lblResult.Text = ex.Message;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LblAreaS_Click(object sender, EventArgs e)
        {
            try
            {        
                game.PlayerTurn.MakeMark(BoardArea.Bottom, BoardArea.Center);
            }
            catch (NullReferenceException ex)
            {
                lblResult.Text = ex.Message;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LblAreaSE_Click(object sender, EventArgs e)
        {
            try
            {        
                game.PlayerTurn.MakeMark(BoardArea.Bottom, BoardArea.Left);
            }
            catch (NullReferenceException ex)
            {
                lblResult.Text = ex.Message;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion


    }
}
