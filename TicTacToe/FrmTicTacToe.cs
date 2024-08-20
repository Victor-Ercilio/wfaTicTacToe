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
        private Player playerX = new Player("The Boss", "X");
        private Player playerO = new Player("Batman", "O");
        private Match match = null;

        public FrmTicTacToe()
        {
            InitializeComponent();
        }

        private void ClearTable()
        {
            foreach(var control in tblGame.Controls)
            {
                ((Label)control).Text = "";
            }
        }

        private void UpdateScore()
        {
            if(match.HasEnded)
            {
                if (match.HasWinner)
                    lblResult.Text = $"You Win! {match.PlayerTurn.Name}";
                else
                    lblResult.Text = "No winners this time!";

                txtScorePlayer1.Text = playerX.Score.ToString();
                txtScorePlayer2.Text = playerO.Score.ToString();
            }
            else
            {
                lblResult.Text = $"Your turn: {match.PlayerTurn.Name}";
            }
        }

        private void Label_Click(object sender, EventArgs e)
        {
            Label actual = (Label) sender;
            int index = tblGame.Controls.IndexOfKey(actual.Name);
            Control control = tblGame.Controls[index];

            if (string.IsNullOrEmpty(actual.Text) && match != null)
            {
                if (!match.HasEnded)
                {
                    int x = tblGame.GetColumn(control);
                    int y = tblGame.GetRow(control);

                    actual.Text = match.PlayerTurn.Mark;
                    match.PlayerTurn.ExecuteMoveTo(x, y);
                }
                UpdateScore();
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                ClearTable();

                lblPlayer1.Text = $"{playerX.Name} - {playerX.Mark}";
                lblPlayer2.Text = $"{playerO.Name} - {playerO.Mark}";

                txtScorePlayer1.Text = playerX.Score.ToString();
                txtScorePlayer2.Text = playerO.Score.ToString();

                match = new Match(playerX, playerO);
                match.Start();
                UpdateScore();
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
