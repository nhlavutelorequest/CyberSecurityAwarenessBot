using System;
using System.IO;
using System.Media;

namespace CyberSecurityAwarenessBot
{
    class VoiceGreeting
    {
        // Keeps the audio player in memory while sound is playing
        private static SoundPlayer? _player;

        public static void PlayGreeting()
        {
            try
            {
                // Build the file path to the greeting audio
                string path = Path.Combine(AppContext.BaseDirectory, "Assets", "greeting.wav");

                // Check if the audio file exists
                if (!File.Exists(path))
                {
                    Console.WriteLine($"Voice greeting file not found: {path}");
                    return;
                }

                // Load and play the greeting sound
                _player ??= new SoundPlayer(path);
                _player.Load();
                _player.Play();
            }
            catch (Exception ex)
            {
                // Handle errors if the audio cannot be played
                Console.WriteLine($"Voice greeting could not be played. {ex.Message}");
            }
        }
    }
}
