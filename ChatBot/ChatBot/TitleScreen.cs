using System;
using Figgle;

namespace ChatBot
{
    public static class TitleScreen
    {
        public static void DisplayTitleScreen()
        {
            Console.ForegroundColor = ConsoleColor.Blue;

            AudioPlayer audioPlayer = new AudioPlayer();

            audioPlayer.PlaySound();

            Console.WriteLine(FiggleFonts.Standard.Render("Cybersecurity"));
            Console.WriteLine(FiggleFonts.Standard.Render(" Awareness Chatbot"));
            Console.ResetColor();

            // Welcome message
            Console.WriteLine("\n************************************************************");
            Console.WriteLine("*                                                          *");
            Console.WriteLine("*              WELCOME! I'M CYBOT 🤖                       *");
            Console.WriteLine("*        Your Cybersecurity Awareness Assistant            *");
            Console.WriteLine("*                                                          *");
            Console.WriteLine("************************************************************");

            Console.ResetColor();
        }
    }
}
