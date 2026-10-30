using System;

namespace ChatBot
{
    public static class NlpProcessor
    {
        public static string ProcessInput(string input, out string actionSummary)
        {
            actionSummary = "";
            if (string.IsNullOrWhiteSpace(input))
                return null;

            string lowerInput = input.ToLower();

            if (lowerInput.Contains("quiz"))
            {
                actionSummary = "Launching quiz...";
                return actionSummary;
            }

            if (lowerInput.Contains("remind") || lowerInput.Contains("reminder"))
            {
                string task = ExtractActionPhrase(lowerInput);
                DateTime reminderDate = DateTime.Now.AddDays(1); // Default reminder in 1 day
                TaskItemManager.AddTask(task,reminder: reminderDate);
                actionSummary = $"Reminder set for: '{task}' on {reminderDate.ToShortDateString()}";
                return actionSummary;
            }

            if (lowerInput.Contains("add task") || lowerInput.Contains("set task") || lowerInput.Contains("create task"))
            {
                string task = ExtractActionPhrase(lowerInput);
                TaskItemManager.AddTask(task);
                actionSummary = $"Task added: '{task}'. Would you like to set a reminder for this task?";
                return actionSummary;
            }

            if (lowerInput.Contains("what have you done") || lowerInput.Contains("summary") || lowerInput.Contains("history"))
            {
                actionSummary = "Here’s a summary of recent actions:\n" + TaskItemManager.GetSummary();
                return actionSummary;
            }

            // If no NLP action matched, return null
            return null;
        }
        //
        //OpenAI (2024) *ChatGPT* [Computer program]. Available at: https://chat.openai.com (Accessed: 26 June 2025).
        //
        private static string ExtractActionPhrase(string input)
        {
            // Simple extraction logic for phrases after key trigger words
            int idx;

            // After "to "
            idx = input.IndexOf("to ");
            if (idx >= 0 && idx + 3 < input.Length)
            {
                return input.Substring(idx + 3).TrimEnd('.', ' ');
            }

            // After "remind me"
            idx = input.IndexOf("remind me");
            if (idx >= 0 && idx + 9 < input.Length)
            {
                return input.Substring(idx + 9).Trim(' ', '.');
            }

            // After "add task"
            idx = input.IndexOf("add task");
            if (idx >= 0 && idx + 8 < input.Length)
            {
                return input.Substring(idx + 8).Trim(' ', '.');
            }

            // Fallback: return whole input (trimmed)
            return input.Trim();
        }
    }
}
