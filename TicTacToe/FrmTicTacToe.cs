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
            lblPlayer1.Text = $"{playerX.Name} - {playerX.Mark}";
            lblPlayer2.Text = $"{playerO.Mark} - {playerO.Name}";
        }
        private void OnBoardChange(object sender, BoardChangedEventArgs e)
        {
            if(e.Vertical == BoardArea.Top)
                switch (e.Horizontal)
                {
                    case BoardArea.Left: 
                        lblAreaNW.Text = e.Mark.ToString(); break;
                    case BoardArea.Center: 
                        lblAreaN.Text = e.Mark.ToString(); break;
                    case BoardArea.Right: 
                        lblAreaNE.Text = e.Mark.ToString(); break;
                }
            else if(e.Vertical == BoardArea.Center)
                switch (e.Horizontal)
                {
                    case BoardArea.Left:
                        lblAreaW.Text = e.Mark.ToString(); break;
                    case BoardArea.Center:
                        lblAreaO.Text = e.Mark.ToString(); break;
                    case BoardArea.Right:
                        lblAreaE.Text = e.Mark.ToString(); break;
                }
            else
                switch (e.Horizontal)
                {
                    case BoardArea.Left:
                        lblAreaSW.Text = e.Mark.ToString(); break;
                    case BoardArea.Center:
                        lblAreaS.Text = e.Mark.ToString(); break;
                    case BoardArea.Right:
                        lblAreaSE.Text = e.Mark.ToString(); break;
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
        private void Area_Click(BoardArea vertical, BoardArea horizontal)
        {
            try
            {
                game.PlayerTurn.MakeMark(vertical, horizontal);
            }
            catch (NullReferenceException)
            {
                lblResult.Text = "Start a match before play!";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LblAreaNW_Click(object sender, EventArgs e)
        {
            Area_Click(BoardArea.Top, BoardArea.Left);
        }

        private void LblAreaN_Click(object sender, EventArgs e)
        {
            Area_Click(BoardArea.Top, BoardArea.Center);
        }    
        private void LblAreaNE_Click(object sender, EventArgs e)
        {
            Area_Click(BoardArea.Top, BoardArea.Right);
        }

        private void LblAreaW_Click(object sender, EventArgs e)
        {
            Area_Click(BoardArea.Center, BoardArea.Left);
        }

        private void LblAreaO_Click(object sender, EventArgs e)
        {
            Area_Click(BoardArea.Center, BoardArea.Center);
        }

        private void LblAreaE_Click(object sender, EventArgs e)
        {
            Area_Click(BoardArea.Center, BoardArea.Right);
        }

        private void LblAreaSW_Click(object sender, EventArgs e)
        {
            Area_Click(BoardArea.Bottom, BoardArea.Left);
        }

        private void LblAreaS_Click(object sender, EventArgs e)
        {
            Area_Click(BoardArea.Bottom, BoardArea.Center);
        }

        private void LblAreaSE_Click(object sender, EventArgs e)
        {
            Area_Click(BoardArea.Bottom, BoardArea.Right);
        }

        #endregion

        private void LblArea_MouseHover(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            lbl.BackColor = SystemColors.ControlLight;
        }

        private void LblArea_MouseLeave(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            lbl.BackColor = SystemColors.Control;
        }

    }
}
