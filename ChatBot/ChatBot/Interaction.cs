using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBot
{
    public static class Interaction
    {
        public static void StartInteraction()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("╔═══════════════════════════════════════════╗");
            Console.WriteLine("║            Ask Me Anything!               ║");
            Console.WriteLine("╚═══════════════════════════════════════════╝");
            Console.ResetColor();

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\nYou: ");
                string question = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(question))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("CYBOT: Please enter a valid question.");
                    Console.ResetColor();
                    continue;
                }

                // Optional exit directly from here (in case handler doesn't catch)
                string lowerQuestion = question.ToLower();
                if (lowerQuestion.Contains("exit") || lowerQuestion.Contains("bye"))
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("CYBOT: Goodbye! Stay safe online.");
                    Console.ResetColor();
                    break; // OR use Environment.Exit(0);
                }

                ResponseHandler.RespondToUser(question);
            }
        }
    }
}