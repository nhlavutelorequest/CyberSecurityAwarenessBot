using System;
using System.Media;

namespace CyberSecurityAwarenessBot
{
    class VoiceGreeting
    {
        public static void PlayGreeting()
        {
            try
            {
                SoundPlayer player = new SoundPlayer("Assets/greeting.wav");
                player.Play();
            }
            catch
            {
                Console.WriteLine("Voice greeting could not be played.");
            }
        }
    }
}