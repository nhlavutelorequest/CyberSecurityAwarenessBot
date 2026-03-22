using System;

namespace CyberSecurityAwarenessBot
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
                    "Password safety means creating strong passwords using letters, numbers, and symbols.",
                    "Always use a unique password for each account and avoid personal information.",
                    "A strong password should be long, complex, and never shared with anyone."
                };
                return responses[rand.Next(responses.Length)];
            }

            // PHISHING
            if (input.Contains("phishing") || input.Contains("email scam"))
            {
                string[] responses =
                {
                    "Phishing is when attackers pretend to be trusted organisations to steal your information.",
                    "Be careful of emails asking for personal details, they may be phishing attacks.",
                    "Always verify the sender before clicking links in emails."
                };
                return responses[rand.Next(responses.Length)];
            }

            // SAFE BROWSING
            if (input.Contains("browsing") || input.Contains("safe browsing") || input.Contains("internet safety"))
            {
                string[] responses =
                {
                    "Safe browsing means using trusted websites and avoiding suspicious downloads.",
                    "Always check if a website uses HTTPS before entering personal information.",
                    "Avoid clicking pop-ups or unknown links while browsing."
                };
                return responses[rand.Next(responses.Length)];
            }

            // MALWARE
            if (input.Contains("malware") || input.Contains("virus"))
            {
                string[] responses =
                {
                    "Malware is harmful software that can damage your system or steal data.",
                    "Avoid downloading unknown files to protect yourself from malware.",
                    "Use antivirus software to protect your device from viruses and spyware."
                };
                return responses[rand.Next(responses.Length)];
            }

            // SCAMS
            if (input.Contains("scam") || input.Contains("fraud"))
            {
                string[] responses =
                {
                    "Online scams try to trick you into giving money or personal information.",
                    "Be cautious of offers that seem too good to be true.",
                    "Always verify before sending money or sharing personal details online."
                };
                return responses[rand.Next(responses.Length)];
            }

            // VPN
            if (input.Contains("vpn"))
            {
                string[] responses =
                {
                    "A VPN protects your internet connection and keeps your data private.",
                    "Using a VPN is important when connecting to public WiFi.",
                    "VPNs encrypt your data and improve online privacy."
                };
                return responses[rand.Next(responses.Length)];
            }

            // SUSPICIOUS LINKS
            if (input.Contains("link") || input.Contains("url"))
            {
                string[] responses =
                {
                    "Suspicious links may lead to fake websites or malware.",
                    "Always check a URL before clicking it.",
                    "Avoid clicking links from unknown senders."
                };
                return responses[rand.Next(responses.Length)];
            }

            // GREETING
            if (input.Contains("hello") || input.Contains("hi"))
            {
                string[] greetings =
                {
                    "Hello! I'm here to help you stay safe online 😊",
                    "Hi there! Ask me anything about cybersecurity.",
                    "Hello! Let's protect you from online threats."
                };
                return greetings[rand.Next(greetings.Length)];
            }

            // PURPOSE
            if (input.Contains("purpose") || input.Contains("what do you do"))
            {
                return "My purpose is to educate South African citizens about cybersecurity and help them stay safe online.";
            }

            // HELP
            if (input.Contains("help") || input.Contains("what can i ask"))
            {
                return "You can ask me about passwords, phishing, malware, scams, VPNs, and safe browsing.";
            }

            // THANK YOU RESPONSE (NEW )
            if (input.Contains("thank"))
            {
                return "You're welcome! Stay safe online.";
            }

            // EMPTY INPUT
            if (string.IsNullOrWhiteSpace(input))
            {
                return "Please type something so I can assist you.";
            }

            // DEFAULT RESPONSE
            return "I did not understand that. Please ask about cybersecurity topics like phishing, passwords, or safe browsing.";
        }
    }
}