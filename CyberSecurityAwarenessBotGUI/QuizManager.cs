using System.Collections.Generic;

namespace CyberSecurityAwarenessBotGUI
{
    public class QuizQuestion
    {
        public string Question { get; set; }
        public string[] Options { get; set; }  // A, B, C, D or True/False
        public int CorrectIndex { get; set; }  // 0-based index of the correct option
        public string Explanation { get; set; }
    }

    public static class QuizManager
    {
        private static readonly List<QuizQuestion> _questions = new List<QuizQuestion>
        {
            new QuizQuestion
            {
                Question     = "What should you do if you receive an email asking for your password?",
                Options      = new[] { "Reply with your password", "Delete the email",
                                       "Report it as phishing", "Ignore it" },
                CorrectIndex = 2,
                Explanation  = "Reporting phishing emails helps email providers block the sender " +
                               "and prevents others from being targeted."
            },
            new QuizQuestion
            {
                Question     = "True or False: Using the same password for all accounts is safe " +
                               "as long as the password is strong.",
                Options      = new[] { "True", "False" },
                CorrectIndex = 1,
                Explanation  = "If one account is breached, attackers will try that same password " +
                               "on every other account — a technique called credential stuffing."
            },
            new QuizQuestion
            {
                Question     = "What does 'HTTPS' in a website address tell you?",
                Options      = new[] { "The website is popular", "The connection is encrypted",
                                       "The website is owned by a government", "The page loads faster" },
                CorrectIndex = 1,
                Explanation  = "HTTPS uses TLS encryption to protect data transmitted between " +
                               "your browser and the server."
            },
            new QuizQuestion
            {
                Question     = "Which of the following is a sign of a phishing email?",
                Options      = new[] { "Sent from a company you recognise",
                                       "Contains urgent language and a suspicious link",
                                       "Has no attachments",
                                       "Uses your full name in the greeting" },
                CorrectIndex = 1,
                Explanation  = "Phishing emails often create urgency ('Your account will be " +
                               "suspended!') to pressure you into clicking without thinking."
            },
            new QuizQuestion
            {
                Question     = "What is two-factor authentication (2FA)?",
                Options      = new[] { "Having two different passwords",
                                       "Using two email addresses",
                                       "Verifying your identity with a second step (e.g. a code on your phone)",
                                       "Logging in twice" },
                CorrectIndex = 2,
                Explanation  = "2FA adds a second verification step so that even if your password " +
                               "is stolen, an attacker cannot log in without your physical device."
            },
            new QuizQuestion
            {
                Question     = "True or False: A VPN hides your real IP address from websites you visit.",
                Options      = new[] { "True", "False" },
                CorrectIndex = 0,
                Explanation  = "A VPN routes your traffic through a server elsewhere, so websites " +
                               "see the VPN server's IP address, not yours."
            },
            new QuizQuestion
            {
                Question     = "Which type of malware encrypts your files and demands payment?",
                Options      = new[] { "Spyware", "Adware", "Ransomware", "Trojan" },
                CorrectIndex = 2,
                Explanation  = "Ransomware locks or encrypts your files and demands a ransom, " +
                               "often in cryptocurrency, to restore access."
            },
            new QuizQuestion
            {
                Question     = "What is social engineering in cybersecurity?",
                Options      = new[] { "Hacking using software vulnerabilities",
                                       "Manipulating people into revealing confidential information",
                                       "A type of firewall",
                                       "Writing malicious code" },
                CorrectIndex = 1,
                Explanation  = "Social engineering exploits human psychology rather than technical " +
                               "weaknesses — for example, pretending to be IT support."
            },
            new QuizQuestion
            {
                Question     = "How long should a strong password be at minimum?",
                Options      = new[] { "At least 4 characters", "At least 6 characters",
                                       "At least 8 characters", "At least 12 characters" },
                CorrectIndex = 3,
                Explanation  = "Security experts recommend a minimum of 12 characters, mixing " +
                               "uppercase, lowercase, numbers, and symbols."
            },
            new QuizQuestion
            {
                Question     = "True or False: Public Wi-Fi networks are always safe to use for banking.",
                Options      = new[] { "True", "False" },
                CorrectIndex = 1,
                Explanation  = "Public Wi-Fi is unsecured. Attackers can intercept traffic on the " +
                               "same network. Use a VPN or avoid sensitive activities on public Wi-Fi."
            },
            new QuizQuestion
            {
                Question     = "What should you do FIRST if you think your account has been hacked?",
                Options      = new[] { "Tell your friends",
                                       "Wait and see what happens",
                                       "Change your password immediately and enable 2FA",
                                       "Delete the account" },
                CorrectIndex = 2,
                Explanation  = "Changing your password immediately locks out the attacker. " +
                               "Enabling 2FA prevents them regaining access even if they learn the new password."
            }
        };

        public static int TotalQuestions => _questions.Count;

        public static QuizQuestion GetQuestion(int index) => _questions[index];

        public static string GetFinalFeedback(int score, int total)
        {
            double percentage = (double)score / total * 100;

            if (percentage == 100) return "Perfect score! You are a true cybersecurity expert!";
            if (percentage >= 80) return "Great job! You have strong cybersecurity awareness.";
            if (percentage >= 60) return "Good effort! Review the topics you missed to strengthen your knowledge.";
            if (percentage >= 40) return "Keep learning — cybersecurity knowledge is essential to staying safe online.";

            return "Don't be discouraged! Everyone starts somewhere. " +
                   "Keep exploring cybersecurity topics with this chatbot.";
        }
    }
}
