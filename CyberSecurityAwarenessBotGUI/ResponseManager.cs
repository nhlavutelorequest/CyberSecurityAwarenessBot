using System;

namespace CyberSecurityAwarenessBotGUI
{
    class ResponseManager
    {
        static Random rand = new Random();

        public static string GetResponse(string input)
        {
            input = input.ToLower();

            // PASSWORDS
            if (input.Contains("password"))
            {
                string[] responses =
                {
                    "Strong passwords should contain uppercase letters, lowercase letters, numbers, and symbols. Avoid using personal information.",

                    "Using the same password for multiple accounts is dangerous because if one account is hacked, others may also be compromised.",

                    "A secure password example is: T!ger#2025$. Weak passwords like 123456 are easy to crack."
                };

                return responses[rand.Next(responses.Length)];
            }

            // PHISHING
            if (input.Contains("phishing"))
            {
                string[] responses =
                {
                    "Phishing is a cyberattack where criminals pretend to be trusted organisations to steal personal information.",

                    "Never click suspicious email links asking for banking details or passwords.",

                    "Always verify the sender's email address before responding to messages."
                };

                return responses[rand.Next(responses.Length)];
            }

            // MALWARE
            if (input.Contains("malware") || input.Contains("virus"))
            {
                return "Malware is harmful software designed to damage devices or steal information. Install antivirus software and avoid suspicious downloads.";
            }

            // SCAMS
            if (input.Contains("scam"))
            {
                return "Online scams trick users into sending money or sharing personal information. Never trust offers that seem too good to be true.";
            }

            // GREETING
            if (input.Contains("hello") || input.Contains("hi"))
            {
                return "Hello 👋 I'm your Cybersecurity Awareness Assistant. Ask me about phishing, passwords, scams, or malware.";
            }

            // HELP
            if (input.Contains("help"))
            {
                return "You can ask me about:\n• Passwords\n• Phishing\n• Malware\n• Scams";
            }

            // DEFAULT
            return "I did not understand that. Try asking about passwords, phishing, malware, or scams.";
        }
    }
}
