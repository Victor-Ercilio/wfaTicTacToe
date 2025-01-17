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
        private Player playerX = new Player("The Boss", 'X');
        private Player playerO = new Player("Batman", 'O');
        private Game game = null;

        public FrmTicTacToe()
        {
            InitializeComponent();
            game = new Game(playerX, playerO);
            game.WaitingPlayerMove += UpdateGameResult;
            game.WaitingPlayerMove += UpdateBoard;
            game.End += UpdateGameResult;
            game.End += UpdateScore;
            game.End += UpdateBoard;
        }

        #region Methods
        private void ClearTable()
        {
            foreach(var control in tblGame.Controls)
            {
                ((Label)control).Text = "";
            }
        }

        private void UpdateBoard(object sender, EventArgs e)
        {
            lblAreaNW.Text = game.Board[0,0].ToString();
            lblAreaN.Text = game.Board[0,1].ToString();
            lblAreaNE.Text = game.Board[0,2].ToString();

            lblAreaW.Text = game.Board[1,0].ToString();
            lblAreaO.Text = game.Board[1,1].ToString();
            lblAreaE.Text = game.Board[1,2].ToString();

            lblAreaSW.Text = game.Board[2, 0].ToString();
            lblAreaS.Text = game.Board[2, 1].ToString();
            lblAreaSE.Text = game.Board[2, 2].ToString();
        }


        private void UpdateScore(object sender, EventArgs e)
        {
            txtScorePlayer1.Text = playerX.Score.ToString();
            txtScorePlayer2.Text = playerO.Score.ToString();
        }

        private void UpdateGameResult(object sender, EventArgs e)
        {
            if (game.HasEnded)
            {
                if (game.HasWinner)
                    lblResult.Text = $"You Win! {game.PlayerTurn.Name}";
                else
                    lblResult.Text = "No winners this time!";
            }
            else
            {
                lblResult.Text = $"Your turn: {game.PlayerTurn.Name}";
            }
        }

        private void GetControlPosition(Label actual, out int x, out int y)
        {
            int index = tblGame.Controls.IndexOfKey(actual.Name);
            Control control = tblGame.Controls[index];
            x = tblGame.GetRow(control);
            y = tblGame.GetColumn(control);
        }

        //private void OnPlayerMove(object sender, EventArgs e)
        //{
        //    CancelEventArgs move = new CancelEventArgs();
        //    PlayerMoveValidating(sender, move);
           
        //    if (!move.Cancel)
        //    {
        //        PlayerMoveValidated(sender, e);
        //    }
        //}

        #endregion

        private void Label_Click(object sender, EventArgs e)
        {
            //OnPlayerMove(sender, e);
            GetControlPosition(((Label)sender), out int x, out int y);
            if (x == 0 && y == 0)
                game.OnMove(BoardPosition.UpperLeft);
            else if (x == 0 && y == 1)
                game.OnMove(BoardPosition.UpperCenter);
            else if (x == 0 && y == 2)
                game.OnMove(BoardPosition.UpperRight);
            else if (x == 1 && y == 0)
                game.OnMove(BoardPosition.CenterLeft);
            else if (x == 1 && y == 1)
                game.OnMove(BoardPosition.Center);
            else if (x == 1 && y == 2)
                game.OnMove(BoardPosition.CenterRight);
            else if (x == 2 && y == 0)
                game.OnMove(BoardPosition.BottomLeft);
            else if (x == 2 && y == 1)
                game.OnMove(BoardPosition.BottomCenter);
            else if (x == 2 && y == 2)
                game.OnMove(BoardPosition.BottomRight);
        }

        //private void PlayerMove_Validating(object sender, CancelEventArgs e)
        //{
        //    if (!string.IsNullOrEmpty(((Label)sender).Text) || match == null)
        //        e.Cancel = true;
        //}

        //private void PlayerMove_Validated(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        Label actual = (Label)sender;
        //        GetControlPosition(actual, out int x, out int y);
        //        if (!match.HasEnded)
        //        {
        //            actual.Text = match.PlayerTurn.Mark;
        //            match.PlayerTurn.ExecuteMoveTo(x, y);
        //        }
        //        UpdateScore();
        //        UpdateGameResult();
        //    }
        //    catch (NullReferenceException)
        //    {
        //        MessageBox.Show("Start the game first!", "TIC TAC TOE");
        //    }
        //}

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                ClearTable();

                lblPlayer1.Text = $"{playerX.Name} - {playerX.Mark}";
                lblPlayer2.Text = $"{playerO.Name} - {playerO.Mark}";

                game.Start(sender, e);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK);
            }
        }
    }
}
