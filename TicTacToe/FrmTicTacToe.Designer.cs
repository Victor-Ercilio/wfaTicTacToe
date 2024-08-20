namespace TicTacToe
{
    partial class FrmTicTacToe
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlScores = new System.Windows.Forms.Panel();
            this.tblGame = new System.Windows.Forms.TableLayoutPanel();
            this.lblAreaNW = new System.Windows.Forms.Label();
            this.lblAreaN = new System.Windows.Forms.Label();
            this.lblAreaNE = new System.Windows.Forms.Label();
            this.lblAreaW = new System.Windows.Forms.Label();
            this.lblAreaO = new System.Windows.Forms.Label();
            this.lblAreaE = new System.Windows.Forms.Label();
            this.lblAreaSW = new System.Windows.Forms.Label();
            this.lblAreaS = new System.Windows.Forms.Label();
            this.lblAreaSE = new System.Windows.Forms.Label();
            this.lblPlayer1 = new System.Windows.Forms.Label();
            this.txtScorePlayer1 = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblResult = new System.Windows.Forms.Label();
            this.lblPlayer2 = new System.Windows.Forms.Label();
            this.txtScorePlayer2 = new System.Windows.Forms.TextBox();
            this.lblVs = new System.Windows.Forms.Label();
            this.pnlScores.SuspendLayout();
            this.tblGame.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlScores
            // 
            this.pnlScores.Controls.Add(this.btnStart);
            this.pnlScores.Controls.Add(this.txtScorePlayer2);
            this.pnlScores.Controls.Add(this.txtScorePlayer1);
            this.pnlScores.Controls.Add(this.lblVs);
            this.pnlScores.Controls.Add(this.lblResult);
            this.pnlScores.Controls.Add(this.lblPlayer2);
            this.pnlScores.Controls.Add(this.lblPlayer1);
            this.pnlScores.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlScores.Location = new System.Drawing.Point(10, 10);
            this.pnlScores.Name = "pnlScores";
            this.pnlScores.Size = new System.Drawing.Size(361, 100);
            this.pnlScores.TabIndex = 0;
            // 
            // tblGame
            // 
            this.tblGame.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tblGame.ColumnCount = 3;
            this.tblGame.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblGame.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tblGame.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblGame.Controls.Add(this.lblAreaNW, 0, 0);
            this.tblGame.Controls.Add(this.lblAreaN, 1, 0);
            this.tblGame.Controls.Add(this.lblAreaNE, 2, 0);
            this.tblGame.Controls.Add(this.lblAreaW, 0, 1);
            this.tblGame.Controls.Add(this.lblAreaO, 1, 1);
            this.tblGame.Controls.Add(this.lblAreaE, 2, 1);
            this.tblGame.Controls.Add(this.lblAreaSW, 0, 2);
            this.tblGame.Controls.Add(this.lblAreaS, 1, 2);
            this.tblGame.Controls.Add(this.lblAreaSE, 2, 2);
            this.tblGame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblGame.Location = new System.Drawing.Point(10, 110);
            this.tblGame.Name = "tblGame";
            this.tblGame.RowCount = 3;
            this.tblGame.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblGame.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblGame.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblGame.Size = new System.Drawing.Size(361, 259);
            this.tblGame.TabIndex = 2;
            // 
            // lblAreaNW
            // 
            this.lblAreaNW.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAreaNW.AutoSize = true;
            this.lblAreaNW.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAreaNW.Location = new System.Drawing.Point(4, 1);
            this.lblAreaNW.Name = "lblAreaNW";
            this.lblAreaNW.Size = new System.Drawing.Size(113, 85);
            this.lblAreaNW.TabIndex = 0;
            this.lblAreaNW.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAreaNW.Click += new System.EventHandler(this.Label_Click);
            // 
            // lblAreaN
            // 
            this.lblAreaN.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAreaN.AutoSize = true;
            this.lblAreaN.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAreaN.Location = new System.Drawing.Point(124, 1);
            this.lblAreaN.Name = "lblAreaN";
            this.lblAreaN.Size = new System.Drawing.Size(113, 85);
            this.lblAreaN.TabIndex = 0;
            this.lblAreaN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAreaN.Click += new System.EventHandler(this.Label_Click);
            // 
            // lblAreaNE
            // 
            this.lblAreaNE.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAreaNE.AutoSize = true;
            this.lblAreaNE.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAreaNE.Location = new System.Drawing.Point(244, 1);
            this.lblAreaNE.Name = "lblAreaNE";
            this.lblAreaNE.Size = new System.Drawing.Size(113, 85);
            this.lblAreaNE.TabIndex = 0;
            this.lblAreaNE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAreaNE.Click += new System.EventHandler(this.Label_Click);
            // 
            // lblAreaW
            // 
            this.lblAreaW.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAreaW.AutoSize = true;
            this.lblAreaW.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAreaW.Location = new System.Drawing.Point(4, 87);
            this.lblAreaW.Name = "lblAreaW";
            this.lblAreaW.Size = new System.Drawing.Size(113, 85);
            this.lblAreaW.TabIndex = 0;
            this.lblAreaW.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAreaW.Click += new System.EventHandler(this.Label_Click);
            // 
            // lblAreaO
            // 
            this.lblAreaO.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAreaO.AutoSize = true;
            this.lblAreaO.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAreaO.Location = new System.Drawing.Point(124, 87);
            this.lblAreaO.Name = "lblAreaO";
            this.lblAreaO.Size = new System.Drawing.Size(113, 85);
            this.lblAreaO.TabIndex = 0;
            this.lblAreaO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAreaO.Click += new System.EventHandler(this.Label_Click);
            // 
            // lblAreaE
            // 
            this.lblAreaE.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAreaE.AutoSize = true;
            this.lblAreaE.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAreaE.Location = new System.Drawing.Point(244, 87);
            this.lblAreaE.Name = "lblAreaE";
            this.lblAreaE.Size = new System.Drawing.Size(113, 85);
            this.lblAreaE.TabIndex = 0;
            this.lblAreaE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAreaE.Click += new System.EventHandler(this.Label_Click);
            // 
            // lblAreaSW
            // 
            this.lblAreaSW.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAreaSW.AutoSize = true;
            this.lblAreaSW.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAreaSW.Location = new System.Drawing.Point(4, 173);
            this.lblAreaSW.Name = "lblAreaSW";
            this.lblAreaSW.Size = new System.Drawing.Size(113, 85);
            this.lblAreaSW.TabIndex = 0;
            this.lblAreaSW.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAreaSW.Click += new System.EventHandler(this.Label_Click);
            // 
            // lblAreaS
            // 
            this.lblAreaS.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAreaS.AutoSize = true;
            this.lblAreaS.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAreaS.Location = new System.Drawing.Point(124, 173);
            this.lblAreaS.Name = "lblAreaS";
            this.lblAreaS.Size = new System.Drawing.Size(113, 85);
            this.lblAreaS.TabIndex = 0;
            this.lblAreaS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAreaS.Click += new System.EventHandler(this.Label_Click);
            // 
            // lblAreaSE
            // 
            this.lblAreaSE.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAreaSE.AutoSize = true;
            this.lblAreaSE.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAreaSE.Location = new System.Drawing.Point(244, 173);
            this.lblAreaSE.Name = "lblAreaSE";
            this.lblAreaSE.Size = new System.Drawing.Size(113, 85);
            this.lblAreaSE.TabIndex = 0;
            this.lblAreaSE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAreaSE.Click += new System.EventHandler(this.Label_Click);
            // 
            // lblPlayer1
            // 
            this.lblPlayer1.AutoSize = true;
            this.lblPlayer1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayer1.Location = new System.Drawing.Point(9, 12);
            this.lblPlayer1.Name = "lblPlayer1";
            this.lblPlayer1.Size = new System.Drawing.Size(65, 20);
            this.lblPlayer1.TabIndex = 0;
            this.lblPlayer1.Text = "Player1:";
            // 
            // txtScorePlayer1
            // 
            this.txtScorePlayer1.Enabled = false;
            this.txtScorePlayer1.Location = new System.Drawing.Point(126, 12);
            this.txtScorePlayer1.Name = "txtScorePlayer1";
            this.txtScorePlayer1.Size = new System.Drawing.Size(43, 20);
            this.txtScorePlayer1.TabIndex = 1;
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(153, 41);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(74, 28);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblResult
            // 
            this.lblResult.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResult.Location = new System.Drawing.Point(0, 73);
            this.lblResult.Margin = new System.Windows.Forms.Padding(5);
            this.lblResult.Name = "lblResult";
            this.lblResult.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.lblResult.Size = new System.Drawing.Size(361, 27);
            this.lblResult.TabIndex = 0;
            this.lblResult.Text = "Result";
            this.lblResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPlayer2
            // 
            this.lblPlayer2.AutoSize = true;
            this.lblPlayer2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayer2.Location = new System.Drawing.Point(261, 12);
            this.lblPlayer2.Name = "lblPlayer2";
            this.lblPlayer2.Size = new System.Drawing.Size(65, 20);
            this.lblPlayer2.TabIndex = 0;
            this.lblPlayer2.Text = "Player2:";
            // 
            // txtScorePlayer2
            // 
            this.txtScorePlayer2.Enabled = false;
            this.txtScorePlayer2.Location = new System.Drawing.Point(212, 12);
            this.txtScorePlayer2.Name = "txtScorePlayer2";
            this.txtScorePlayer2.Size = new System.Drawing.Size(43, 20);
            this.txtScorePlayer2.TabIndex = 1;
            // 
            // lblVs
            // 
            this.lblVs.AutoSize = true;
            this.lblVs.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVs.Location = new System.Drawing.Point(175, 12);
            this.lblVs.Name = "lblVs";
            this.lblVs.Size = new System.Drawing.Size(31, 20);
            this.lblVs.TabIndex = 0;
            this.lblVs.Text = "VS";
            // 
            // FrmTicTacToe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(381, 379);
            this.Controls.Add(this.tblGame);
            this.Controls.Add(this.pnlScores);
            this.Name = "FrmTicTacToe";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "TIC TAC TOE";
            this.pnlScores.ResumeLayout(false);
            this.pnlScores.PerformLayout();
            this.tblGame.ResumeLayout(false);
            this.tblGame.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlScores;
        private System.Windows.Forms.TableLayoutPanel tblGame;
        private System.Windows.Forms.Label lblAreaNW;
        private System.Windows.Forms.Label lblAreaN;
        private System.Windows.Forms.Label lblAreaNE;
        private System.Windows.Forms.Label lblAreaW;
        private System.Windows.Forms.Label lblAreaO;
        private System.Windows.Forms.Label lblAreaE;
        private System.Windows.Forms.Label lblAreaSW;
        private System.Windows.Forms.Label lblAreaS;
        private System.Windows.Forms.Label lblAreaSE;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox txtScorePlayer1;
        private System.Windows.Forms.Label lblPlayer1;
        private System.Windows.Forms.TextBox txtScorePlayer2;
        private System.Windows.Forms.Label lblVs;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label lblPlayer2;
    }
}

