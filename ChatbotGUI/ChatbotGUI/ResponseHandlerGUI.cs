using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ChatBot
{
    public static class ResponseHandler
    {
        private static bool awaitingReminder = false;
        private static TaskItem pendingTask = null;
        private static readonly List<TaskItem> taskItems = new();
        private static readonly Random rnd = new();
        private static string lastTopic = "";
        private static readonly Dictionary<string, List<int>> used = new(StringComparer.OrdinalIgnoreCase);

        private static readonly Dictionary<string, List<string>> keywordAnswers = new(StringComparer.OrdinalIgnoreCase)
        {
            //
            //National Cyber Security Centre (NCSC). (2023) *Password guidance*. [Online] 
            // Available at: https://www.ncsc.gov.uk/guidance/password-guidance-simplifying-your-approach 
            //(Accessed: 26 May 2025).
            //
            // Sample cybersecurity tips, add more as needed
            { "password", new() {
                "Use strong, unique passwords with letters, numbers, and symbols.",
                "Avoid using the same password across different sites.",
                "Consider using a password manager.",
                "Change passwords regularly.",
                "Enable Two-Factor Authentication (2FA)."
            }},
            { "phishing", new() {
                "Watch for urgent messages demanding immediate action.",
                "Check the sender’s email address carefully.",
                "Hover over links to verify URLs.",
                "Look for bad grammar or generic greetings.",
                "Contact banks directly if unsure."
            }},
            //
            // Norton. (2023) *What is malware?*. [Online] 
            //Available at: https://us.norton.com/blog/malware/what-is-malware 
            //(Accessed: 26 May 2025).
            //
            { "malware", new List<string> {
                "Malware is software designed to damage your device or steal data.",
                "Avoid downloading attachments from unknown sources.",
                "Install antivirus software and keep it updated.",
                "Be cautious of free software downloads — they may contain hidden malware.",
                "Regularly scan your device for malware and remove any threats."
            }},
            { "public wifi", new List<string> {
                "Avoid logging into banking or sensitive accounts on public Wi-Fi.",
                "Use a VPN when accessing the internet through public networks.",
                "Disable automatic connection to open Wi-Fi networks."
            }},
            //
            //OpenAI (2024) *ChatGPT* [Computer program]. Available at: https://chat.openai.com (Accessed: 26 May 2025).
            //
            { "vpn", new List<string> {
                "A VPN encrypts your traffic and hides your IP address.",
                "VPNs help protect your identity on public networks.",
                "Choose a reputable VPN provider for better security."

            }},
            { "firewall", new List<string> {
                "A firewall helps block unauthorized access to your device.",
                "Keep your firewall enabled to help stop threats before they reach you."
            }},
            { "2fa", new List<string> {
                "Two-Factor Authentication adds an extra layer of security.",
                "Use 2FA wherever possible to protect your accounts."
            }},
            { "update software", new List<string> {
                "Software updates often include security patches — don’t ignore them!",
                "Enable auto-updates to stay protected from the latest threats."
            }},
            { "identity theft", new List<string> {
                "Monitor your financial accounts for strange activity.",
                "Avoid oversharing personal details on social media."
            }},
            { "cyberbullying", new List<string> {
                "Block and report abusive users online.",
                "Talk to someone you trust if you're being bullied digitally."
            }}
        };

        public static string GetResponse(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return "Please type something so I can assist.";

            string lower = input.Trim().ToLower();
            string original = input.Trim();

            // Handle random tip requests
            if (lower == "tip" || lower == "random tip" || lower.Contains("give me a tip"))
            {
                string topic = PickRandomTopic();
                lastTopic = topic;
                return $"Here's a tip for you:\n💡 {GetUnique(topic)}";
            }

            // Handle 'more' tips from last topic
            if (lower == "more" && !string.IsNullOrEmpty(lastTopic))
            {
                return $"Another tip on {lastTopic}:\n💡 {GetUnique(lastTopic)}";
            }
            //
            //OpenAI (2024) *ChatGPT* [Computer program]. Available at: https://chat.openai.com (Accessed: 26 June 2025).
            //

            // Handle help command
            if (lower == "help")
            {
                return "Here’s what I can help you with:\n" +
                       "- Ask questions like 'What is phishing?' or 'Tell me about VPNs'.\n" +
                       "- Type 'Add task - Review privacy settings' to add a task.\n" +
                       "- Say 'Remind me in 3 days' to get reminders.\n" +
                       "- View tasks by typing 'show my tasks'.\n" +
                       "- You can also 'complete [task name]' or 'delete [task name]'.\n" +
                       "- Type 'exit' or 'bye' to end the chat.";
            }

            // Handle awaiting reminder yes/no reply
            if (awaitingReminder && pendingTask != null)
            {
                if (lower == "yes" || lower == "y")
                {
                    awaitingReminder = false;
                    return ShowReminderDialog();
                }
                else if (lower == "no" || lower == "n")
                {
                    awaitingReminder = false;
                    taskItems.Add(pendingTask);
                    pendingTask = null;

                    string topic = PickRandomTopic();
                    string tip = GetUnique(topic);
                    return $"No problem! 😊 Here's a tip while you're here:\n💡 {tip}";
                }
                else
                {
                    return "Please reply 'yes' or 'no' to set a reminder.";
                }
            }

            // Add task command
            if (original.StartsWith("Add task -", StringComparison.OrdinalIgnoreCase))
            {
                string title = original.Substring("Add task -".Length).Trim();

                if (string.IsNullOrEmpty(title))
                    return "Please specify the task after 'Add task -'.";

                if (taskItems.Exists(t => t.Title.Equals(title, StringComparison.OrdinalIgnoreCase)))
                    return $"Task \"{title}\" already exists.";

                pendingTask = new TaskItem
                {
                    Title = title,
                    Description = $"Review {title}.",
                    IsCompleted = false
                };
                awaitingReminder = true; // wait for yes/no reply
                return $"Task \"{title}\" added. Would you like a reminder? (yes / no)";
            }

            // Show tasks command
            if (lower.Contains("show my tasks"))
            {
                if (taskItems.Count == 0)
                    return "You have no saved tasks.";

                string result = "Your tasks:\n";
                foreach (var task in taskItems)
                {
                    result += $"- {task.Title}" +
                              (task.IsCompleted ? " ✅" : "") +
                              (task.ReminderDate.HasValue ? $" (Remind: {task.ReminderDate.Value:g})" : "") + "\n";
                }
                return result;
            }

            // Complete task command
            if (lower.StartsWith("complete "))
            {
                string name = original.Substring("complete ".Length).Trim();
                var task = taskItems.Find(t => t.Title.Equals(name, StringComparison.OrdinalIgnoreCase));
                if (task != null)
                {
                    task.IsCompleted = true;
                    return $"Marked \"{task.Title}\" as completed ✅.";
                }
                return $"I couldn't find a task named \"{name}\".";
            }

            // Delete task command
            if (lower.StartsWith("delete "))
            {
                string name = original.Substring("delete ".Length).Trim();
                var task = taskItems.Find(t => t.Title.Equals(name, StringComparison.OrdinalIgnoreCase));
                if (task != null)
                {
                    taskItems.Remove(task);
                    return $"Deleted task \"{task.Title}\".";
                }
                return $"I couldn't find a task named \"{name}\".";
            }

            // Exit command
            if (lower == "exit" || lower == "bye")
            {
                return "Goodbye! Stay safe online! 👋";
            }

            // Keyword detection
            foreach (var pair in keywordAnswers)
            {
                if (lower.Contains(pair.Key))
                {
                    lastTopic = pair.Key;
                    return $"Here's a tip on {pair.Key}:\n💡 {GetUnique(pair.Key)}";
                }
            }

            // Default fallback
            return "🤔 I'm not sure I understood. You can type 'help' for options.";
        }
        //
        //OpenAI (2024) *ChatGPT* [Computer program]. Available at: https://chat.openai.com (Accessed: 26 June 2025).
        //
        // Show Reminder Dialog helper
        private static string ShowReminderDialog()
        {
            using var dialog = new ReminderPromptForm();
            if (dialog.ShowDialog() == DialogResult.OK && dialog.SelectedReminderTime.HasValue)
            {
                pendingTask.ReminderDate = dialog.SelectedReminderTime.Value;
                taskItems.Add(pendingTask);
                string title = pendingTask.Title;
                pendingTask = null;
                return $"Great! I'll remind you about \"{title}\" on {dialog.SelectedReminderTime.Value:g}.";
            }
            else
            {
                taskItems.Add(pendingTask);
                pendingTask = null;
                return "Okay, no reminder set.";
            }
        }

        // Pick random topic for tips
        private static string PickRandomTopic()
        {
            var topics = new List<string>(keywordAnswers.Keys);
            return topics[rnd.Next(topics.Count)];
        }

        // Get unique tip for a topic
        private static string GetUnique(string topic)
        {
            var list = keywordAnswers[topic];
            if (!used.ContainsKey(topic) || used[topic].Count >= list.Count)
                used[topic] = new();

            var unusedIndexes = new List<int>();
            for (int i = 0; i < list.Count; i++)
            {
                if (!used[topic].Contains(i))
                    unusedIndexes.Add(i);
            }

            if (unusedIndexes.Count == 0) return list[rnd.Next(list.Count)];

            int pick = unusedIndexes[rnd.Next(unusedIndexes.Count)];
            used[topic].Add(pick);
            return list[pick];
        }
    }
}
