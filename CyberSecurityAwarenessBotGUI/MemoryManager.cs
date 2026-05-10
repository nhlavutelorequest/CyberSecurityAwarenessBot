using System.Collections.Generic;

namespace CyberSecurityAwarenessBotGUI
{
    class MemoryManager
    {
        // =========================================
        // LIST USED TO STORE USER INTERESTS
        // Example:
        // Passwords, Phishing, Malware
        // =========================================

        public static List<string> UserInterests = new List<string>();


        // =========================================
        // METHOD: SAVE USER INTEREST
        // This method stores topics the user asks about
        // =========================================

        public static void SaveInterest(string topic)
        {
            // Prevent duplicate topics
            if (!UserInterests.Contains(topic))
            {
                UserInterests.Add(topic);
            }
        }


        // =========================================
        // METHOD: RETURN ALL REMEMBERED TOPICS
        // =========================================

        public static string GetInterests()
        {
            // Check if nothing has been stored
            if (UserInterests.Count == 0)
            {
                return "I do not remember any cybersecurity interests yet.";
            }

            // Return remembered topics
            return "I remember that you previously asked about: " +
                   string.Join(", ", UserInterests) +
                   ".";
        }


        // =========================================
        // METHOD: CLEAR MEMORY
        // Allows chatbot memory reset
        // =========================================

        public static void ClearMemory()
        {
            UserInterests.Clear();
        }


        // =========================================
        // METHOD: CHECK IF TOPIC EXISTS
        // Returns true or false
        // =========================================

        public static bool HasInterest(string topic)
        {
            return UserInterests.Contains(topic);
        }


        // =========================================
        // METHOD: COUNT SAVED TOPICS
        // =========================================

        public static int TotalInterests()
        {
            return UserInterests.Count;
        }
    }
}