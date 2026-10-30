using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatBot
{
    public partial class QuizForm : Form
    {
        private class QuizQuestion
        {
            public string QuestionText { get; set; }
            public List<string> Options { get; set; }
            public int CorrectOptionIndex { get; set; }
            public string Explanation { get; set; }
        }

        private List<QuizQuestion> questions;
        private int currentQuestionIndex = 0;
        private int score = 0;

        public QuizForm()
        {
            InitializeComponent();
            InitializeQuestions();
            LoadQuestion();
        }

        private void InitializeQuestions()
        {
            questions = new List<QuizQuestion>
            {
                new QuizQuestion
                {
                    QuestionText = "What should you do if you receive an email asking for your password?",
                    Options = new List<string>{ "Reply with your password", "Delete the email", "Report the email as phishing", "Ignore it" },
                    CorrectOptionIndex = 2,
                    Explanation = "Correct! Reporting phishing emails helps prevent scams."
                },
                new QuizQuestion
                {
                    QuestionText = "True or False: Using the same password for multiple accounts is safe.",
                    Options = new List<string>{ "True", "False" },
                    CorrectOptionIndex = 1,
                    Explanation = "False! Reusing passwords increases risk if one account is compromised."
                },
                new QuizQuestion
                {
                    QuestionText = "What does 'phishing' typically involve?",
                    Options = new List<string>{ "Fishing in a lake", "Sending fraudulent emails to steal info", "Encrypting your files", "Backing up data" },
                    CorrectOptionIndex = 1,
                    Explanation = "Phishing involves fraudulent attempts to steal sensitive information."
                },
                new QuizQuestion
                {
                    QuestionText = "Which is the strongest password?",
                    Options = new List<string>{ "password123", "Qwerty!", "MyBirthday", "S!7&hP$9@zL" },
                    CorrectOptionIndex = 3,
                    Explanation = "Strong passwords use a mix of characters and symbols."
                },
                new QuizQuestion
                {
                    QuestionText = "Safe browsing means:",
                    Options = new List<string>{ "Clicking every link you see", "Avoiding suspicious websites", "Sharing passwords", "Ignoring updates" },
                    CorrectOptionIndex = 1,
                    Explanation = "Avoiding suspicious websites helps protect against malware."
                },
                new QuizQuestion
                {
                    QuestionText = "Multi-factor authentication (MFA) improves security by:",
                    Options = new List<string>{ "Using multiple passwords", "Adding extra verification steps", "Removing passwords", "Using only biometrics" },
                    CorrectOptionIndex = 1,
                    Explanation = "MFA requires multiple ways to verify identity."
                },
                new QuizQuestion
                {
                    QuestionText = "What is social engineering?",
                    Options = new List<string>{ "Engineering buildings", "Manipulating people to give info", "A type of firewall", "Encrypting data" },
                    CorrectOptionIndex = 1,
                    Explanation = "Social engineering tricks people into giving sensitive info."
                },
                new QuizQuestion
                {
                    QuestionText = "You should update your software because:",
                    Options = new List<string>{ "Updates fix security vulnerabilities", "They slow down your computer", "They delete files", "They are unnecessary" },
                    CorrectOptionIndex = 0,
                    Explanation = "Updates often fix security holes that attackers exploit."
                },
                new QuizQuestion
                {
                    QuestionText = "Which is a sign of a secure website?",
                    Options = new List<string>{ "http://", "https://", "No URL shown", "Pop-up ads" },
                    CorrectOptionIndex = 1,
                    Explanation = "HTTPS sites encrypt your data to keep it safe."
                },
                new QuizQuestion
                {
                    QuestionText = "If you suspect a device is infected with malware, you should:",
                    Options = new List<string>{ "Ignore it", "Run antivirus scan", "Share files", "Turn it off and keep using" },
                    CorrectOptionIndex = 1,
                    Explanation = "Running antivirus helps detect and remove malware."
                },
            };
        }

        private void LoadQuestion()
        {
            if (currentQuestionIndex >= questions.Count)
            {
                ShowFinalScore();
                return;
            }

            var q = questions[currentQuestionIndex];
            lblQuestion.Text = q.QuestionText;

            rbOption1.Text = q.Options[0];
            rbOption1.Visible = true;
            rbOption1.Checked = false;

            rbOption2.Text = q.Options[1];
            rbOption2.Visible = true;
            rbOption2.Checked = false;

            if (q.Options.Count > 2)
            {
                rbOption3.Text = q.Options[2];
                rbOption3.Visible = true;
                rbOption3.Checked = false;
            }
            else
            {
                rbOption3.Visible = false;
            }

            if (q.Options.Count > 3)
            {
                rbOption4.Text = q.Options[3];
                rbOption4.Visible = true;
                rbOption4.Checked = false;
            }
            else
            {
                rbOption4.Visible = false;
            }

            lblFeedback.Text = "";
            btnSubmit.Enabled = true;
            lblScore.Text = $"Score: {score} / {questions.Count}";
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            int selectedIndex = -1;
            if (rbOption1.Checked) selectedIndex = 0;
            else if (rbOption2.Checked) selectedIndex = 1;
            else if (rbOption3.Checked) selectedIndex = 2;
            else if (rbOption4.Checked) selectedIndex = 3;

            if (selectedIndex == -1)
            {
                MessageBox.Show("Please select an answer.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnSubmit.Enabled = false;

            var q = questions[currentQuestionIndex];
            if (selectedIndex == q.CorrectOptionIndex)
            {
                score++;
                lblFeedback.ForeColor = Color.Green;
                lblFeedback.Text = "Correct! " + q.Explanation;
            }
            else
            {
                lblFeedback.ForeColor = Color.Red;
                lblFeedback.Text = $"Incorrect. {q.Explanation}";
            }

            lblScore.Text = $"Score: {score} / {questions.Count}";
            currentQuestionIndex++;

            await Task.Delay(2500);

            if (!this.IsDisposed)
                LoadQuestion();
        }
        //
        //OpenAI (2024) *ChatGPT* [Computer program]. Available at: https://chat.openai.com (Accessed: 26 June 2025).
        //
        private void ShowFinalScore()
        {
            string finalMessage = score >= questions.Count * 0.7
                ? "Great job! You’re a cybersecurity pro!"
                : "Keep learning to stay safe online!";

            MessageBox.Show($"Quiz Finished!\nYour final score: {score}/{questions.Count}\n{finalMessage}", "Quiz Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
