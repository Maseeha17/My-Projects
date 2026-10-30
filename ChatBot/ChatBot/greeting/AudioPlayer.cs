using NAudio.Wave;
using System;
using System.Threading;
using System.Media;

namespace ChatBot
{
    public class AudioPlayer
    {

        
        //public static void PlayGreeting(string filePath)
        //{
        //    string greetingAudioPath = Path.Combine( "greeting.mp3");
        //    Console.WriteLine( greetingAudioPath);

        //    if (File.Exists(greetingAudioPath))
        //    {
        //        PlaySound(greetingAudioPath);
        //    }
        //    else
        //    {
        //        Console.WriteLine("[Greeting audio file not found]");
        //    }
        
        //    try
        //    {
        //        using (var audioFileReader = new AudioFileReader(filePath))
        //        using (var outputDevice = new WaveOutEvent())
        //        {
        //            outputDevice.Init(audioFileReader);
        //            outputDevice.Play();
        //            while (outputDevice.PlaybackState == PlaybackState.Playing)
        //            {
        //                Thread.Sleep(100);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.ForegroundColor = ConsoleColor.Red;
        //        Console.WriteLine("Audio error: " + ex.Message);
        //        Console.ResetColor();
        //    }
        //}

        public void PlaySound()
        {
            SoundPlayer sound = new SoundPlayer("greeting.wav");
            sound.Play();
        }
    }
}
