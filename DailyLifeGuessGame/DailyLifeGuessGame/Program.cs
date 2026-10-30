namespace DailyLifeGuessGame
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Configure high DPI settings, default font, etc.
            ApplicationConfiguration.Initialize();

            // Start the main form
            Application.Run(new Form1());
        }
    }
}