using System;

namespace CyberSecurityAwarenessBotGUI
{
    class SentimentResponse
    {
        public static string GetSentiment(string input)
        {
            input = input.ToLower();

            // HAPPY / POSITIVE
            if (input.Contains("happy") ||
                input.Contains("good") ||
                input.Contains("great") ||
                input.Contains("awesome") ||
                input.Contains("thanks") ||
                input.Contains("thank you"))
            {
                return "😊 I'm glad to hear that! Staying positive while learning about cybersecurity is important.";
            }

            // SAD / WORRIED
            if (input.Contains("sad") ||
                input.Contains("worried") ||
                input.Contains("scared") ||
                input.Contains("afraid") ||
                input.Contains("nervous"))
            {
                return "😟 Don't worry. Cybersecurity threats can be avoided by learning safe online habits and staying alert.";
            }

            // ANGRY / FRUSTRATED
            if (input.Contains("angry") ||
                input.Contains("frustrated") ||
                input.Contains("annoyed"))
            {
                return "😐 I understand your frustration. Cyber threats and scams can be stressful, but learning cybersecurity helps you stay protected.";
            }

            // CONFUSED
            if (input.Contains("confused") ||
                input.Contains("don't understand") ||
                input.Contains("lost"))
            {
                return "🤔 That's okay. Cybersecurity can be confusing at first, but I will try to explain it in a simple way.";
            }

            // DEFAULT
            return "";
        }
    }
}