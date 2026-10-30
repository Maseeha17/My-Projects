using System;
using System.Windows.Forms;
using ChatBot; // ?? Make sure this matches Form1's namespace

namespace ChatbotGUI
{
     static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}