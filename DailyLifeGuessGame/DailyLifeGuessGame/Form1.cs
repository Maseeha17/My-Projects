using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;

namespace DailyLifeGuessGame
{
    public partial class Form1 : Form
    {
        Random random = new Random();

        string[] words =
        {
            "phone",
            "wallet",
            "umbrella",
            "mirror",
            "laptop",
            "backpack",
            "television",
            "clock",
            "toothbrush",
            "fridge"
        };

        string[] hints =
        {
            "Used to make calls and send messages.",
            "Keeps your money and cards.",
            "Used when it rains.",
            "Shows your reflection.",
            "Used for work or studying.",
            "Used to carry books and belongings.",
            "Used to watch movies and TV.",
            "Tells the time.",
            "Used to clean your teeth.",
            "Keeps food and drinks cold."
        };

        string secretWord = "";
        string secretHint = "";

        int score = 0;
        int attempts = 0;
        const int maxAttempts = 5;

        DateTime startTime;

        List<int> leaderboard = new List<int>();

        public Form1()
        {
            InitializeComponent();
            StartNewGame();
        }

        private void StartNewGame()
        {
            int index = random.Next(words.Length);

            secretWord = words[index];
            secretHint = hints[index];

            attempts = 0;
            score = 0;

            startTime = DateTime.Now;

            lblScore.Text = "Score: 0";
            lblAttempts.Text = "Attempts Left: " + maxAttempts;
            lblHint.Text = "Hint: -";
            lblTime.Text = "Time: 0 sec";

            txtGuess.Clear();
            txtGuess.Focus();
        }

        private void btnGuess_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtGuess.Text))
            {
                MessageBox.Show("Please enter your guess.");
                return;
            }

            attempts++;

            string guess = txtGuess.Text.Trim().ToLower();

            if (guess == secretWord)
            {
                score += 10;

                TimeSpan duration = DateTime.Now - startTime;

                lblScore.Text = "Score: " + score;
                lblTime.Text = "Time: " + duration.Seconds + " sec";

                MessageBox.Show("🎉 Correct!\nYou guessed the word!");

                leaderboard.Add(score);

                leaderboard = leaderboard
                    .OrderByDescending(x => x)
                    .Take(5)
                    .ToList();

                UpdateLeaderboard();

                StartNewGame();

                return;
            }

            score--;

            lblScore.Text = "Score: " + score;
            lblAttempts.Text = "Attempts Left: " + (maxAttempts - attempts);
            lblHint.Text = "Hint: " + secretHint;

            txtGuess.Clear();
            txtGuess.Focus();

            if (attempts >= maxAttempts)
            {
                TimeSpan duration = DateTime.Now - startTime;

                lblTime.Text = "Time: " + duration.Seconds + " sec";

                MessageBox.Show(
                    "Game Over!\n\nThe correct answer was: "
                    + secretWord);

                leaderboard.Add(score);

                leaderboard = leaderboard
                    .OrderByDescending(x => x)
                    .Take(5)
                    .ToList();

                UpdateLeaderboard();

                StartNewGame();
            }
        }

        private void UpdateLeaderboard()
        {
            lstLeaderboard.Items.Clear();

            for (int i = 0; i < leaderboard.Count; i++)
            {
                lstLeaderboard.Items.Add($"{i + 1}. {leaderboard[i]} points");
            }
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            StartNewGame();
        }

        private void lstLeaderboard_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}