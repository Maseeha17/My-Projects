using System;
using System.Collections.Generic;
using System.IO;
using NAudio.Wave;

namespace QAGameWithSound
{
    class Program
    {
        static void Main(string[] args)
        {
            //set up paths to sound files
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string soundFolder = Path.Combine(basePath, "sound");
            string correctSound = Path.Combine(soundFolder, "correct.wav"); 
            string wrongSound = Path.Combine(soundFolder, "wrong.wav");

            // 1. Questions and answers dictionary (new set)
            Dictionary<string, string> questions = new Dictionary<string, string>()
            {
                {"Which language is primarily used for Android app development?", "java"},
                {"Which programming language is known for its snake logo?", "python"},
                {"What is the chemical symbol for water?", "h2o"},
                {"Which animal is known as the King of the Jungle?", "lion"},
                {"What is the square root of 64?", "8"},
                {"Who painted the Mona Lisa?", "da vinci"},
                {"What is the capital city of Japan?", "tokyo"},
                {"Which country is famous for pizza and pasta?", "italy"},
                {"What color is the sky on a clear day?", "blue"},
                {"What is the name of the longest river in the world?", "nile"}
            };

            int score = 0;

            // 2. Welcome the user
            Console.WriteLine("🎮 Welcome to the Q&A Game with Sound!");
            Console.WriteLine("-------------------------------------");

            // 3. Explain the game
            Console.WriteLine("You will be asked 10 questions.");
            Console.WriteLine("Type your answer and press Enter.\n");

            // 4. Loop through the questions
            foreach (var q in questions)
            {
                Console.WriteLine(q.Key);
                Console.Write("Your answer: ");
                string answer = Console.ReadLine()?.ToLower().Trim();

                if (answer == q.Value.ToLower())
                {
                    PlaySound("correct.wav");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("✅ Correct!\n");
                    Console.ResetColor();
                    score++;
                }
                else
                {
                    PlaySound("wrong.wav");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("❌ Incorrect!");
                    Console.WriteLine($"✅ Correct answer: {q.Value}\n");
                    Console.ResetColor();
                }
            }

            // 5. End of game
            Console.WriteLine("🏁 End of Game!");
            Console.WriteLine($"Your final score: {score}/{questions.Count}");
        }

        static void PlaySound(string filePath)
        {
            try
            {
                string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filePath);
                using (AudioFileReader audioFile = new AudioFileReader(fullPath))
                using (WaveOutEvent outputDevice = new WaveOutEvent())
                {
                    outputDevice.Init(audioFile);
                    outputDevice.Play();

                    while (outputDevice.PlaybackState == PlaybackState.Playing)
                    {
                        System.Threading.Thread.Sleep(100);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"⚠️ Error playing sound: {ex.Message}");
            }
        }
    }
}