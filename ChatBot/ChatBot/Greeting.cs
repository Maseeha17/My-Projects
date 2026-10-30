using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBot
{
    public class Greeting 
    {
        private static string userName = "Friend";
        
        public static void GreetUser()
        {

            Console.Write("\nPlease enter your name: ");
            string input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
                userName = input;

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\nHello {userName}! I'm CYBOT, your cybersecurity buddy.");
            Console.WriteLine("I'm here to help you learn how to stay safe online!");
            Console.ResetColor();
        }
    }
}
