using System;
using System.Collections.Generic;

namespace CyberSecurityAwarenessBotGUI
{
    // =====================================================
    // MEMORYMANAGER.CS  — Session Memory & Name Storage
    // Remembers: user's name, topics asked, and question
    // count so the bot can give personalised responses.
    // =====================================================

    class MemoryManager
    {
        // --------------------------------------------------
        // USER NAME  (remembered for the whole session)
        // --------------------------------------------------
        public static string UserName { get; private set; } = null;

        // --------------------------------------------------
        // TOPIC LIST  — stores unique cybersecurity topics
        // --------------------------------------------------
        public static List<string> UserInterests = new List<string>();

        // --------------------------------------------------
        // QUESTION COUNTER
        // --------------------------------------------------
        private static int _questionCount = 0;
        public static int QuestionCount => _questionCount;


        // ==================================================
        // SAVE USER NAME
        // Call this the moment a name is detected in input.
        // ==================================================
        public static void SaveName(string name)
        {
            if (!string.IsNullOrWhiteSpace(name))
                UserName = CapitaliseName(name.Trim());
        }


        // ==================================================
        // SAVE TOPIC INTEREST  (no duplicates)
        // ==================================================
        public static void SaveInterest(string topic)
        {
            if (!UserInterests.Contains(topic))
                UserInterests.Add(topic);
        }


        // ==================================================
        // INCREMENT QUESTION COUNTER
        // ==================================================
        public static void IncrementQuestion()
        {
            _questionCount++;
        }


        // ==================================================
        // GET PERSONALISED GREETING PREFIX
        // Returns "Hey Alex, " or "" if no name known.
        // ==================================================
        public static string GetNamePrefix()
        {
            return string.IsNullOrEmpty(UserName) ? "" : UserName + ", ";
        }


        // ==================================================
        // GET FULL MEMORY RECALL RESPONSE
        // ==================================================
        public static string GetInterests()
        {
            string nameInfo = string.IsNullOrEmpty(UserName)
                ? "I don't know your name yet — tell me by saying \"My name is [name]\"."
                : "I remember your name is " + UserName + ".";

            string topicInfo;
            if (UserInterests.Count == 0)
            {
                topicInfo = "You haven't asked about any specific cybersecurity topics yet this session.";
            }
            else
            {
                topicInfo = "You have asked about the following topic(s) this session: "
                            + string.Join(", ", UserInterests) + ".";
            }

            string countInfo = "You have sent " + _questionCount + " message(s) so far this session.";

            return nameInfo + Environment.NewLine +
                   topicInfo + Environment.NewLine +
                   countInfo;
        }


        // ==================================================
        // CLEAR ALL MEMORY  (used by Clear button)
        // ==================================================
        public static void ClearMemory()
        {
            UserName = null;
            _questionCount = 0;
            UserInterests.Clear();
        }


        // ==================================================
        // HELPERS
        // ==================================================
        public static bool HasInterest(string topic) => UserInterests.Contains(topic);
        public static int TotalInterests() => UserInterests.Count;

        private static string CapitaliseName(string name)
        {
            if (string.IsNullOrEmpty(name)) return name;
            return char.ToUpper(name[0]) + name.Substring(1).ToLower();
        }
    }
}