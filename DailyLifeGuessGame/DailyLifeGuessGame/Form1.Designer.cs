using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using System;
using System.Drawing;
using System.Windows.Forms;
namespace DailyLifeGuessGame
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTitle;
        private Label lblGuess;
        private TextBox txtGuess;
        private Button btnGuess;
        private Button btnNewGame;
        private Label lblScore;
        private Label lblAttempts;
        private Label lblHint;
        private Label lblTime;
        private Label lblLeaderboard;
        private ListBox lstLeaderboard;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblGuess = new Label();
            txtGuess = new TextBox();
            btnGuess = new Button();
            btnNewGame = new Button();
            lblScore = new Label();
            lblAttempts = new Label();
            lblHint = new Label();
            lblTime = new Label();
            lblLeaderboard = new Label();
            lstLeaderboard = new ListBox();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.Location = new Point(180, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(423, 41);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "🎮 Daily Life Guessing Game";
            // 
            // lblGuess
            // 
            lblGuess.AutoSize = true;
            lblGuess.Location = new Point(40, 90);
            lblGuess.Name = "lblGuess";
            lblGuess.Size = new Size(117, 20);
            lblGuess.TabIndex = 1;
            lblGuess.Text = "Enter your guess";
            // 
            // txtGuess
            // 
            txtGuess.Location = new Point(40, 120);
            txtGuess.Name = "txtGuess";
            txtGuess.Size = new Size(250, 27);
            txtGuess.TabIndex = 2;
            // 
            // btnGuess
            // 
            btnGuess.Location = new Point(320, 118);
            btnGuess.Name = "btnGuess";
            btnGuess.Size = new Size(120, 30);
            btnGuess.TabIndex = 3;
            btnGuess.Text = "Guess";
            btnGuess.Click += btnGuess_Click;
            // 
            // btnNewGame
            // 
            btnNewGame.Location = new Point(460, 118);
            btnNewGame.Name = "btnNewGame";
            btnNewGame.Size = new Size(120, 30);
            btnNewGame.TabIndex = 4;
            btnNewGame.Text = "New Game";
            btnNewGame.Click += btnNewGame_Click;
            // 
            // lblScore
            // 
            lblScore.AutoSize = true;
            lblScore.Location = new Point(40, 180);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(61, 20);
            lblScore.TabIndex = 5;
            lblScore.Text = "Score: 0";
            // 
            // lblAttempts
            // 
            lblAttempts.AutoSize = true;
            lblAttempts.Location = new Point(40, 210);
            lblAttempts.Name = "lblAttempts";
            lblAttempts.Size = new Size(114, 20);
            lblAttempts.TabIndex = 6;
            lblAttempts.Text = "Attempts Left: 5";
            // 
            // lblHint
            // 
            lblHint.AutoSize = true;
            lblHint.Location = new Point(40, 240);
            lblHint.Name = "lblHint";
            lblHint.Size = new Size(50, 20);
            lblHint.TabIndex = 7;
            lblHint.Text = "Hint: -";
            // 
            // lblTime
            // 
            lblTime.AutoSize = true;
            lblTime.Location = new Point(40, 270);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(82, 20);
            lblTime.TabIndex = 8;
            lblTime.Text = "Time: 0 sec";
            // 
            // lblLeaderboard
            // 
            lblLeaderboard.AutoSize = true;
            lblLeaderboard.Font = new System.Drawing.Font("Segoe UI", 10F, FontStyle.Bold);
            lblLeaderboard.Location = new Point(430, 180);
            lblLeaderboard.Name = "lblLeaderboard";
            lblLeaderboard.Size = new Size(141, 23);
            lblLeaderboard.TabIndex = 9;
            lblLeaderboard.Text = "🏆 Leaderboard";
            // 
            // lstLeaderboard
            // 
            lstLeaderboard.Location = new Point(430, 210);
            lstLeaderboard.Name = "lstLeaderboard";
            lstLeaderboard.Size = new Size(200, 104);
            lstLeaderboard.TabIndex = 10;
            lstLeaderboard.SelectedIndexChanged += lstLeaderboard_SelectedIndexChanged;
            // 
            // Form1
            // 
            ClientSize = new Size(700, 450);
            Controls.Add(lblTitle);
            Controls.Add(lblGuess);
            Controls.Add(txtGuess);
            Controls.Add(btnGuess);
            Controls.Add(btnNewGame);
            Controls.Add(lblScore);
            Controls.Add(lblAttempts);
            Controls.Add(lblHint);
            Controls.Add(lblTime);
            Controls.Add(lblLeaderboard);
            Controls.Add(lstLeaderboard);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Daily Life Guessing Game";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}