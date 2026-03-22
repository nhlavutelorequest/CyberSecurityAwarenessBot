namespace CyberSecurityAwarenessBot
{
    class ResponseManager
    {
        public static string GetResponse(string input)
        {
            input = input.ToLower();

            if (input.Contains("password"))
            {
                return CyberSecurityTips.PasswordTip();
            }

            if (input.Contains("phishing"))
            {
                return CyberSecurityTips.PhishingTip();
            }

            if (input.Contains("browsing") || input.Contains("safe browsing"))
            {
                return CyberSecurityTips.SafeBrowsingTip();
            }

            if (input.Contains("purpose"))
            {
                return "My purpose is to help South Africans understand cybersecurity threats.";
            }

            return "I didn't understand that. Try asking about passwords, phishing or safe browsing.";
        }
    }
}