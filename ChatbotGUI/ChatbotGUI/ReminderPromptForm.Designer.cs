namespace ChatBot
{
    partial class ReminderPromptForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DateTimePicker dateTimePickerReminder;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblPrompt;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dateTimePickerReminder = new DateTimePicker();
            btnOk = new Button();
            btnCancel = new Button();
            lblPrompt = new Label();
            SuspendLayout();
            // 
            // dateTimePickerReminder
            // 
            dateTimePickerReminder.CalendarFont = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dateTimePickerReminder.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            dateTimePickerReminder.Location = new Point(15, 44);
            dateTimePickerReminder.Margin = new Padding(3, 4, 3, 4);
            dateTimePickerReminder.Name = "dateTimePickerReminder";
            dateTimePickerReminder.Size = new Size(250, 28);
            dateTimePickerReminder.TabIndex = 0;
            // 
            // btnOk
            // 
            btnOk.BackColor = Color.Silver;
            btnOk.Location = new Point(40, 94);
            btnOk.Margin = new Padding(3, 4, 3, 4);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(80, 38);
            btnOk.TabIndex = 1;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = false;
            btnOk.Click += btnOk_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.Silver;
            btnCancel.Location = new Point(150, 94);
            btnCancel.Margin = new Padding(3, 4, 3, 4);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(80, 38);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // lblPrompt
            // 
            lblPrompt.AutoSize = true;
            lblPrompt.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPrompt.Location = new Point(12, 12);
            lblPrompt.Name = "lblPrompt";
            lblPrompt.Size = new Size(308, 20);
            lblPrompt.TabIndex = 3;
            lblPrompt.Text = "Please select a date and time for reminder:";
            // 
            // ReminderPromptForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FloralWhite;
            ClientSize = new Size(332, 150);
            Controls.Add(lblPrompt);
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            Controls.Add(dateTimePickerReminder);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ReminderPromptForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Set Reminder";
            ResumeLayout(false);
            PerformLayout();

        }
    }
}

