using System;
using System.IO;
using System.Media;
using System.Windows.Forms;

namespace CyberSecurityAwarenessBotGUI
{
    class VoiceGreeting
    {
        private static SoundPlayer player;

        public static void PlayGreeting()
        {
            try
            {
                string path = Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    "Assets",
                    "greeting.wav"
                );

                if (File.Exists(path))
                {
                    player = new SoundPlayer(path);
                    player.Load();
                    player.Play();
                }
                else
                {
                    MessageBox.Show("greeting.wav not found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}