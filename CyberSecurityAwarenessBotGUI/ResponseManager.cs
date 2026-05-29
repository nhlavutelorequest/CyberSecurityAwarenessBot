using System;
using System.Linq;

namespace CyberSecurityAwarenessBotGUI
{
    /// <summary>
    /// Professional Cybersecurity Response Engine
    /// </summary>
    public static class ResponseManager
    {
        private static readonly Random Rand = new Random();

        // ==========================================
        // MAIN CHATBOT RESPONSE METHOD
        // ==========================================
        public static string GetResponse(string userInput)
        {
            string input =
                userInput.ToLowerInvariant().Trim();

            // Get user name from memory
            string userName =
                MemoryManager.GetNamePrefix();

            string prefix = "";

            if (!string.IsNullOrWhiteSpace(userName))
            {
                prefix = userName + ", ";
            }

            // ==========================================
            // PASSWORDS
            // ==========================================
            if (ContainsAny(input,
                "password",
                "passwords",
                "credentials"))
            {
                string[] responses =
                {
                    "A strong password is one of the most important ways to protect your online accounts and personal information.\n\n" +

                    "A secure password should contain uppercase letters, lowercase letters, numbers, and special symbols. It should also be at least 12 characters long.\n\n" +

                    "Example:\n" +
                    "Weak Password: 123456\n" +
                    "Strong Password: T!ger#2025Secure\n\n" +

                    "Cybercriminals use automated tools to crack weak passwords within seconds.\n\n" +

                    "How to protect yourself:\n" +
                    "- Never reuse passwords\n" +
                    "- Avoid personal information\n" +
                    "- Use a password manager\n" +
                    "- Enable Two-Factor Authentication (2FA)\n\n" +

                    "Fact: Over 80% of hacking-related breaches happen because of weak or stolen passwords.",

                    "Passwords act as the first line of defense against cyberattacks.\n\n" +

                    "If attackers gain access to your password, they may steal your money, personal files, or online identity.\n\n" +

                    "Good password practices include creating unique passwords for every account and changing compromised passwords immediately.\n\n" +

                    "Example:\n" +
                    "Instead of using 'john123', use something stronger like 'J0hn!Secure#2025'.\n\n" +

                    "Always keep your passwords private and never share them online."
                };

                return AddCloser(prefix + responses[Rand.Next(responses.Length)]);
            }

            // ==========================================
            // PHISHING
            // ==========================================
            if (ContainsAny(input,
                "phishing",
                "email scam",
                "phish"))
            {
                string[] responses =
                {
                    "Phishing is a cyberattack where criminals pretend to be trusted organisations such as banks, universities, or online services to steal personal information.\n\n" +

                    "Phishing attacks usually happen through fake emails, SMS messages, or websites that appear legitimate.\n\n" +

                    "Example:\n" +
                    "You may receive an email saying:\n" +
                    "'Your bank account has been suspended. Click here immediately to verify your account.'\n\n" +

                    "Once you click the link, you may be redirected to a fake website designed to steal your username and password.\n\n" +

                    "How to protect yourself:\n" +
                    "- Never click suspicious links\n" +
                    "- Verify email senders carefully\n" +
                    "- Check if websites use HTTPS\n" +
                    "- Never share OTPs or passwords\n" +
                    "- Report suspicious emails immediately\n\n" +

                    "Fact: Millions of phishing attacks happen every year worldwide.",

                    "Phishing scams are designed to create panic or urgency so users act without thinking.\n\n" +

                    "Attackers often pretend to be banks, SARS, delivery companies, or government institutions.\n\n" +

                    "Example:\n" +
                    "'Your parcel is delayed. Pay R20 now.'\n\n" +

                    "These messages often lead to fake payment websites.\n\n" +

                    "Always verify messages directly through official websites or phone numbers."
                };

                return AddCloser(prefix + responses[Rand.Next(responses.Length)]);
            }

            // ==========================================
            // MALWARE
            // ==========================================
            if (ContainsAny(input,
                "malware",
                "virus",
                "trojan",
                "ransomware"))
            {
                string[] responses =
                {
                    "Malware is harmful software created to damage systems, steal data, or spy on users.\n\n" +

                    "Common types of malware include:\n" +
                    "- Viruses\n" +
                    "- Worms\n" +
                    "- Spyware\n" +
                    "- Trojans\n" +
                    "- Ransomware\n\n" +

                    "Example:\n" +
                    "Ransomware can lock all your files and demand payment before restoring access.\n\n" +

                    "How malware spreads:\n" +
                    "- Unsafe downloads\n" +
                    "- Fake software\n" +
                    "- Suspicious email attachments\n" +
                    "- Infected USB devices\n\n" +

                    "How to protect yourself:\n" +
                    "- Install antivirus software\n" +
                    "- Keep software updated\n" +
                    "- Avoid unknown downloads\n" +
                    "- Scan USB devices before opening files.",

                    "Malware attacks are increasing every year and can affect both individuals and businesses.\n\n" +

                    "Some malware secretly records passwords and banking details without the victim noticing.\n\n" +

                    "Always download software from trusted websites only."
                };

                return AddCloser(prefix + responses[Rand.Next(responses.Length)]);
            }

            // ==========================================
            // SCAMS
            // ==========================================
            if (ContainsAny(input,
                "scam",
                "fraud",
                "social engineering"))
            {
                string[] responses =
                {
                    "Online scams are fraudulent activities designed to trick people into giving away money or sensitive information.\n\n" +

                    "Scammers often pretend to be trusted people or organisations.\n\n" +

                    "Common scams include:\n" +
                    "- Fake lottery winnings\n" +
                    "- Investment scams\n" +
                    "- Romance scams\n" +
                    "- Banking scams\n" +
                    "- Fake job offers\n\n" +

                    "Example:\n" +
                    "'Congratulations! You won R50,000. Pay R500 to claim your prize.'\n\n" +

                    "This is a common scam technique.\n\n" +

                    "How to protect yourself:\n" +
                    "- Never send money to strangers\n" +
                    "- Verify information carefully\n" +
                    "- Ignore deals that seem too good to be true\n" +
                    "- Never share banking PINs or passwords.",

                    "Social engineering scams manipulate human emotions such as fear, excitement, or urgency.\n\n" +

                    "Scammers may pressure victims into acting quickly before thinking carefully.\n\n" +

                    "Always remain calm and verify information independently."
                };

                return AddCloser(prefix + responses[Rand.Next(responses.Length)]);
            }

            // ==========================================
            // GREETING
            // ==========================================
            if (ContainsAny(input,
                "hello",
                "hi",
                "hey"))
            {
                return prefix +
                       "Hello! I am your Cybersecurity Awareness Assistant.\n\n" +

                       "I can help you learn about:\n" +
                       "- Password Security\n" +
                       "- Phishing Attacks\n" +
                       "- Malware\n" +
                       "- Online Scams\n" +
                       "- VPN Security\n" +
                       "- Safe Browsing\n\n" +

                       "How can I assist you today?";
            }

            // ==========================================
            // HELP
            // ==========================================
            if (ContainsAny(input,
                "help",
                "what can you do"))
            {
                return prefix +
                       "You can ask me questions such as:\n\n" +

                       "- What is phishing?\n" +
                       "- Explain malware\n" +
                       "- How do I create a strong password?\n" +
                       "- What are online scams?\n" +
                       "- How does a VPN work?\n" +
                       "- How do I browse safely online?\n\n" +

                       "I will provide detailed cybersecurity explanations and safety tips.";
            }

            // ==========================================
            // THANK YOU
            // ==========================================
            if (ContainsAny(input,
                "thank",
                "thanks"))
            {
                return prefix +
                       "You're welcome! Stay safe online and continue learning about cybersecurity awareness.";
            }

            // ==========================================
            // DEFAULT RESPONSE
            // ==========================================
            return prefix +
                   "I did not fully understand your request.\n\n" +

                   "Please ask me about cybersecurity topics such as:\n" +
                   "- Passwords\n" +
                   "- Phishing\n" +
                   "- Malware\n" +
                   "- Scams\n" +
                   "- VPNs\n" +
                   "- Safe Browsing";
        }

        // ==========================================
        // HELPER METHOD
        // ==========================================
        private static bool ContainsAny(
            string text,
            params string[] keywords)
        {
            return keywords.Any(
                keyword => text.Contains(keyword));
        }

        // ==========================================
        // PROFESSIONAL CLOSER
        // ==========================================
        private static string AddCloser(string response)
        {
            string[] closers =
            {
                "\n\nStay safe online.",
                "\n\nCybersecurity awareness is your first defense.",
                "\n\nAlways protect your personal information online.",
                "\n\nKnowledge is the best protection against cybercrime."
            };

            return response +
                   closers[Rand.Next(closers.Length)];
        }
    }
}