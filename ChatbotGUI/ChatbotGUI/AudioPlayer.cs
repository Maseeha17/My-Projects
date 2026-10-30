using System.Media;

namespace ChatBot
{
    public class AudioPlayer
    {
        public void PlaySound()
        {
            try
            {
                SoundPlayer sound = new SoundPlayer("greeting.wav");
                sound.Load();
                sound.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Audio failed: " + ex.Message);
            }
        }
    }
}