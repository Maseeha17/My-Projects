using ChatBot;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ChatBot
{
    public partial class Form1 : Form
    {
        private AudioPlayer audioPlayer = new AudioPlayer();
        private List<string> activityLog = new List<string>();
        private const int MaxLogEntries = 10;

        private string lastTopic = "";

        public Form1()
        {
            InitializeComponent();
            DisplayTitleScreen();
        }

        private void DisplayTitleScreen()
        {
            try { audioPlayer.PlaySound(); } catch { }

            lblTitle.Text = "CYBERSECURITY AWARENESS CHATBOT";
            lblGreeting.Text = "Welcome! I'm CYBOT \nYour Cybersecurity Awareness Assistant";
            lblGreeting.Font = new Font("Segoe UI Emoji", 12);

            AddToActivityLog("Chatbot started and greeted the user.");
        }

        private void AddToActivityLog(string actionDescription)
        {
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string entry = $"{timestamp} - {actionDescription}";
            activityLog.Add(entry);
            if (activityLog.Count > MaxLogEntries)
                activityLog.RemoveAt(0);
        }

        private void btnStartChat_Click(object sender, EventArgs e)
        {
            string name = txtUserName.Text.Trim();
            rtbChatLog.SelectionColor = Color.CadetBlue;

            if (!string.IsNullOrWhiteSpace(name))
            {
                rtbChatLog.AppendText($"\nCYBOT: Hello {name}! I'm here to help you stay safe online.\n");
                AddToActivityLog($"Greeted user with name: {name}");
            }
            else
            {
                rtbChatLog.AppendText("\nCYBOT: Hello Friend! Let's learn about cybersecurity.\n");
                AddToActivityLog("Greeted user as Friend.");
            }

            rtbChatLog.ScrollToCaret();
        }

        private void txtUserInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnAsk.PerformClick();
            }
        }

        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnStartChat.PerformClick();
            }
        }

        private void btnAsk_Click(object sender, EventArgs e)
        {
            string userInput = txtUserInput.Text.Trim();
            string lowerInput = userInput.ToLower();

            if (string.IsNullOrWhiteSpace(userInput))
            {
                rtbChatLog.SelectionColor = Color.Red;
                rtbChatLog.AppendText("\nCYBOT: Please enter a valid question.\n");
                rtbChatLog.ScrollToCaret();
                return;
            }

            rtbChatLog.SelectionColor = Color.Orange;
            rtbChatLog.AppendText($"\nYou: {userInput}\n");
            rtbChatLog.ScrollToCaret();

            // Sentiment detection
            if (lowerInput.Contains("worried"))
            {
                rtbChatLog.SelectionColor = Color.DeepSkyBlue;
                rtbChatLog.AppendText("CYBOT: It's okay to feel worried. I'm here to help you navigate safely online.\n");
                AddToActivityLog("Detected user sentiment: worried");
                rtbChatLog.ScrollToCaret();
                txtUserInput.Clear();
                return;
            }
            if (lowerInput.Contains("frustrated"))
            {
                rtbChatLog.SelectionColor = Color.DeepSkyBlue;
                rtbChatLog.AppendText("CYBOT: I understand your frustration. Let’s take it one step at a time.\n");
                AddToActivityLog("Detected user sentiment: frustrated");
                rtbChatLog.ScrollToCaret();
                txtUserInput.Clear();
                return;
            }
            if (lowerInput.Contains("curious"))
            {
                rtbChatLog.SelectionColor = Color.DeepSkyBlue;
                rtbChatLog.AppendText("CYBOT: Curiosity is great! Let's explore some cybersecurity tips.\n");
                AddToActivityLog("Detected user sentiment: curious");
                rtbChatLog.ScrollToCaret();
                txtUserInput.Clear();
                return;
            }

            if (lowerInput.Contains("don't understand") || lowerInput.Contains("confused"))
            {
                rtbChatLog.SelectionColor = Color.MediumPurple;
                if (!string.IsNullOrEmpty(lastTopic))
                {
                    string help = ResponseHandler.GetResponse("help " + lastTopic);
                    rtbChatLog.AppendText("CYBOT: Let me explain again: " + help + "\n");
                }
                else
                {
                    rtbChatLog.AppendText("CYBOT: No worries — feel free to ask another question.\n");
                }
                AddToActivityLog("Detected confusion");
                rtbChatLog.ScrollToCaret();
                txtUserInput.Clear();
                return;
            }

            // Show activity log
            if (lowerInput.Contains("show activity log") || lowerInput.Contains("what have you done"))
            {
                rtbChatLog.SelectionColor = Color.Purple;
                if (activityLog.Count == 0)
                {
                    rtbChatLog.AppendText("CYBOT: No activity recorded yet.\n");
                }
                else
                {
                    rtbChatLog.AppendText("CYBOT: Here’s a summary of recent actions:\n");
                    int count = 1;
                    foreach (var entry in activityLog)
                    {
                        rtbChatLog.AppendText($"{count}. {entry}\n");
                        count++;
                    }
                }
                rtbChatLog.ScrollToCaret();
                txtUserInput.Clear();
                return;
            }

            // Quiz
            if (lowerInput.Contains("quiz"))
            {
                rtbChatLog.SelectionColor = Color.Green;
                rtbChatLog.AppendText("CYBOT: Launching the cybersecurity quiz...\n");
                AddToActivityLog("Quiz started.");
                rtbChatLog.ScrollToCaret();

                QuizForm quiz = new QuizForm();
                quiz.ShowDialog();

                AddToActivityLog("Quiz completed.");
                txtUserInput.Clear();
                return;
            }

            // Exit
            if (lowerInput.Contains("exit") || lowerInput.Contains("bye"))
            {
                string farewell = ResponseHandler.GetResponse(userInput);
                rtbChatLog.SelectionColor = Color.Magenta;
                rtbChatLog.AppendText($"CYBOT: {farewell}\n");
                AddToActivityLog("User exited the chatbot.");
                rtbChatLog.ScrollToCaret();

                Application.Exit();
                return;
            }

            // Default response
            string response = ResponseHandler.GetResponse(userInput);
            rtbChatLog.SelectionColor = Color.Green;
            rtbChatLog.AppendText($"CYBOT: {response}\n");
            rtbChatLog.ScrollToCaret();
            txtUserInput.Clear();
        }

        private void btnQuiz_Click(object sender, EventArgs e)
        {
            rtbChatLog.SelectionColor = Color.Green;
            rtbChatLog.AppendText("CYBOT: Launching the cybersecurity quiz...\n");
            rtbChatLog.ScrollToCaret();

            AddToActivityLog("Quiz started.");

            QuizForm quiz = new QuizForm();
            quiz.ShowDialog();

            AddToActivityLog("Quiz completed.");
        }
    }
}
