using ChatBot;

namespace ChatBot
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblGreeting;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Button btnStartChat;
        private System.Windows.Forms.TextBox txtUserInput;
        private System.Windows.Forms.Button btnAsk;
        private System.Windows.Forms.RichTextBox rtbChatLog;
        private System.Windows.Forms.Button btnQuiz;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblGreeting = new Label();
            txtUserName = new TextBox();
            btnStartChat = new Button();
            txtUserInput = new TextBox();
            btnAsk = new Button();
            rtbChatLog = new RichTextBox();
            btnQuiz = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.BackColor = Color.GhostWhite;
            lblTitle.Font = new Font("Stencil", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(14, 12);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(887, 53);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Cybersecurity Awareness Chatbot";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblGreeting
            // 
            lblGreeting.BackColor = Color.GhostWhite;
            lblGreeting.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblGreeting.Location = new Point(14, 65);
            lblGreeting.Name = "lblGreeting";
            lblGreeting.Size = new Size(887, 67);
            lblGreeting.TabIndex = 1;
            lblGreeting.Text = "Welcome! I'm CYBOT ";
            lblGreeting.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtUserName
            // 
            txtUserName.BackColor = SystemColors.Menu;
            txtUserName.ForeColor = SystemColors.WindowText;
            txtUserName.Location = new Point(14, 136);
            txtUserName.Margin = new Padding(3, 4, 3, 4);
            txtUserName.Name = "txtUserName";
            txtUserName.PlaceholderText = "Enter your name";
            txtUserName.Size = new Size(228, 27);
            txtUserName.TabIndex = 2;
            txtUserName.KeyDown += txtUserName_KeyDown;
            // 
            // btnStartChat
            // 
            btnStartChat.BackColor = SystemColors.ActiveCaption;
            btnStartChat.Location = new Point(249, 135);
            btnStartChat.Margin = new Padding(3, 4, 3, 4);
            btnStartChat.Name = "btnStartChat";
            btnStartChat.Size = new Size(114, 33);
            btnStartChat.TabIndex = 3;
            btnStartChat.Text = "Start Chat";
            btnStartChat.UseVisualStyleBackColor = false;
            btnStartChat.Click += btnStartChat_Click;
            // 
            // txtUserInput
            // 
            txtUserInput.BackColor = SystemColors.Menu;
            txtUserInput.Location = new Point(14, 536);
            txtUserInput.Margin = new Padding(3, 4, 3, 4);
            txtUserInput.Name = "txtUserInput";
            txtUserInput.PlaceholderText = "Ask me anything...";
            txtUserInput.Size = new Size(662, 27);
            txtUserInput.TabIndex = 4;
            txtUserInput.KeyDown += txtUserInput_KeyDown;
            // 
            // btnAsk
            // 
            btnAsk.BackColor = SystemColors.ActiveCaption;
            btnAsk.Location = new Point(683, 536);
            btnAsk.Margin = new Padding(3, 4, 3, 4);
            btnAsk.Name = "btnAsk";
            btnAsk.Size = new Size(86, 31);
            btnAsk.TabIndex = 5;
            btnAsk.Text = "Ask";
            btnAsk.UseVisualStyleBackColor = false;
            btnAsk.Click += btnAsk_Click;
            // 
            // rtbChatLog
            // 
            rtbChatLog.BackColor = Color.Snow;
            rtbChatLog.Location = new Point(14, 175);
            rtbChatLog.Margin = new Padding(3, 4, 3, 4);
            rtbChatLog.Name = "rtbChatLog";
            rtbChatLog.ReadOnly = true;
            rtbChatLog.Size = new Size(886, 353);
            rtbChatLog.TabIndex = 6;
            rtbChatLog.Text = "";
            // 
            // btnQuiz
            // 
            btnQuiz.BackColor = SystemColors.ActiveCaption;
            btnQuiz.ForeColor = SystemColors.InfoText;
            btnQuiz.Location = new Point(789, 536);
            btnQuiz.Margin = new Padding(3, 4, 3, 4);
            btnQuiz.Name = "btnQuiz";
            btnQuiz.Size = new Size(112, 31);
            btnQuiz.TabIndex = 7;
            btnQuiz.Text = "Start Quiz";
            btnQuiz.UseVisualStyleBackColor = false;
            btnQuiz.Click += btnQuiz_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSteelBlue;
            ClientSize = new Size(988, 713);
            Controls.Add(lblTitle);
            Controls.Add(lblGreeting);
            Controls.Add(txtUserName);
            Controls.Add(btnStartChat);
            Controls.Add(txtUserInput);
            Controls.Add(btnAsk);
            Controls.Add(rtbChatLog);
            Controls.Add(btnQuiz);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Cybersecurity Awareness Chatbot";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
