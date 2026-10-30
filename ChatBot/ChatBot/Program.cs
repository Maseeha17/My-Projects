using ChatBot;
using System;
using System.Threading;

namespace Chatbot
{
    class Program
    {
        public static void Main(string[] args)
        {
            // Play greeting audio using your AudioPlayer class
            //AudioPlayer.PlayGreeting("greeting.wav");
            
            // Display ASCII title screen
            TitleScreen.DisplayTitleScreen();

            // Show text-based greeting
            Greeting.GreetUser();

            // Start interaction
            Thread.Sleep(500);
            Interaction.StartInteraction();
        }

    }
}


