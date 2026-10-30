using System;
using System.Windows.Forms;

namespace ChatBot
{
    public partial class ReminderPromptForm : Form
    {
        public DateTime? SelectedReminderTime { get; private set; }

        public ReminderPromptForm()
        {
            InitializeComponent();
            //
            //OpenAI (2024) *ChatGPT* [Computer program]. Available at: https://chat.openai.com (Accessed: 26 June 2025).
            //
            // Initialize DateTimePicker defaults
            dateTimePickerReminder.Format = DateTimePickerFormat.Custom;
            dateTimePickerReminder.CustomFormat = "dd MMM yyyy - HH:mm";
            dateTimePickerReminder.MinDate = DateTime.Now.AddMinutes(1); // can't set reminder in the past
            dateTimePickerReminder.Value = DateTime.Now.AddMinutes(10); // default reminder 10 minutes from now
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            SelectedReminderTime = dateTimePickerReminder.Value;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SelectedReminderTime = null;
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}



