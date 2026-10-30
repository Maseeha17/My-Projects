namespace ChatBot
{
    partial class QuizForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblQuestion;
        private System.Windows.Forms.RadioButton rbOption1;
        private System.Windows.Forms.RadioButton rbOption2;
        private System.Windows.Forms.RadioButton rbOption3;
        private System.Windows.Forms.RadioButton rbOption4;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label lblFeedback;
        private System.Windows.Forms.Label lblScore;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblQuestion = new Label();
            rbOption1 = new RadioButton();
            rbOption2 = new RadioButton();
            rbOption3 = new RadioButton();
            rbOption4 = new RadioButton();
            btnSubmit = new Button();
            lblFeedback = new Label();
            lblScore = new Label();
            SuspendLayout();
            // 
            // lblQuestion
            // 
            lblQuestion.BackColor = Color.LightSteelBlue;
            lblQuestion.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblQuestion.Location = new Point(14, 12);
            lblQuestion.Name = "lblQuestion";
            lblQuestion.Size = new Size(640, 80);
            lblQuestion.TabIndex = 0;
            lblQuestion.Text = "Question";
            // 
            // rbOption1
            // 
            rbOption1.BackColor = Color.Lavender;
            rbOption1.Location = new Point(23, 107);
            rbOption1.Margin = new Padding(3, 4, 3, 4);
            rbOption1.Name = "rbOption1";
            rbOption1.Size = new Size(571, 27);
            rbOption1.TabIndex = 1;
            rbOption1.TabStop = true;
            rbOption1.Text = "Option 1";
            rbOption1.UseVisualStyleBackColor = false;
            // 
            // rbOption2
            // 
            rbOption2.BackColor = Color.Lavender;
            rbOption2.Location = new Point(23, 147);
            rbOption2.Margin = new Padding(3, 4, 3, 4);
            rbOption2.Name = "rbOption2";
            rbOption2.Size = new Size(571, 27);
            rbOption2.TabIndex = 2;
            rbOption2.TabStop = true;
            rbOption2.Text = "Option 2";
            rbOption2.UseVisualStyleBackColor = false;
            // 
            // rbOption3
            // 
            rbOption3.BackColor = Color.Lavender;
            rbOption3.Location = new Point(23, 187);
            rbOption3.Margin = new Padding(3, 4, 3, 4);
            rbOption3.Name = "rbOption3";
            rbOption3.Size = new Size(571, 27);
            rbOption3.TabIndex = 3;
            rbOption3.TabStop = true;
            rbOption3.Text = "Option 3";
            rbOption3.UseVisualStyleBackColor = false;
            // 
            // rbOption4
            // 
            rbOption4.BackColor = Color.Lavender;
            rbOption4.Location = new Point(23, 227);
            rbOption4.Margin = new Padding(3, 4, 3, 4);
            rbOption4.Name = "rbOption4";
            rbOption4.Size = new Size(571, 27);
            rbOption4.TabIndex = 4;
            rbOption4.TabStop = true;
            rbOption4.Text = "Option 4";
            rbOption4.UseVisualStyleBackColor = false;
            // 
            // btnSubmit
            // 
            btnSubmit.BackColor = SystemColors.ActiveCaption;
            btnSubmit.Location = new Point(23, 280);
            btnSubmit.Margin = new Padding(3, 4, 3, 4);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(114, 40);
            btnSubmit.TabIndex = 5;
            btnSubmit.Text = "Submit";
            btnSubmit.UseVisualStyleBackColor = false;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // lblFeedback
            // 
            lblFeedback.Font = new Font("Segoe UI", 10F);
            lblFeedback.Location = new Point(23, 333);
            lblFeedback.Name = "lblFeedback";
            lblFeedback.Size = new Size(617, 53);
            lblFeedback.TabIndex = 6;
            // 
            // lblScore
            // 
            lblScore.BackColor = Color.LightBlue;
            lblScore.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblScore.Location = new Point(526, 293);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(137, 31);
            lblScore.TabIndex = 7;
            lblScore.Text = "Score: 0 / 10";
            // 
            // QuizForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Azure;
            ClientSize = new Size(667, 400);
            Controls.Add(lblScore);
            Controls.Add(lblFeedback);
            Controls.Add(btnSubmit);
            Controls.Add(rbOption4);
            Controls.Add(rbOption3);
            Controls.Add(rbOption2);
            Controls.Add(rbOption1);
            Controls.Add(lblQuestion);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "QuizForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cybersecurity Quiz";
            ResumeLayout(false);
        }
    }
}
