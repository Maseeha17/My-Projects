using System;
using System.Collections.Generic;
using System.Linq;

namespace ChatBot
{
    public static class TaskItemManager
    {
        private static List<TaskItem> tasks = new List<TaskItem>();

        public static void AddTask(string title, string description = "", DateTime? reminder = null)
        {
            tasks.Add(new TaskItem
            {
                Title = title,
                Description = description,
                ReminderDate = reminder,
                IsCompleted = false
            });
        }

        public static bool CompleteTask(string title)
        {
            var task = tasks.FirstOrDefault(t => t.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
            if (task != null)
            {
                task.IsCompleted = true;
                return true;
            }
            return false;
        }

        public static bool DeleteTask(string title)
        {
            var task = tasks.FirstOrDefault(t => t.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
            if (task != null)
            {
                tasks.Remove(task);
                return true;
            }
            return false;
        }
        //
        //OpenAI (2024) *ChatGPT* [Computer program]. Available at: https://chat.openai.com (Accessed: 26 June 2025).
        //

        public static string GetSummary()
        {
            if (!tasks.Any()) return "No tasks or reminders yet.";

            var incompleteTasks = tasks.Where(t => !t.IsCompleted).ToList();
            if (!incompleteTasks.Any()) return "All tasks are completed!";

            string result = "";
            int count = 1;
            foreach (var task in incompleteTasks)
            {
                result += $"{count++}. {task.Title}";
                if (task.ReminderDate.HasValue)
                    result += $" (Reminder: {task.ReminderDate.Value.ToShortDateString()})";
                result += "\n";
            }
            return result;
        }

        public static List<TaskItem> GetAllTasks() => tasks;
    }
}
