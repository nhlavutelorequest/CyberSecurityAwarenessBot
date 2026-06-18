using System;

namespace CyberSecurityAwarenessBotGUI
{
    /// <summary>
    /// Detects the user's intent from natural language input.
    /// Uses keyword detection and phrase matching to classify input
    /// into known intents even when phrasing varies.
    /// </summary>
    public static class NlpEngine
    {
        public enum Intent
        {
            None,
            AddTask,
            SetReminder,
            ViewTasks,
            StartQuiz,
            ShowLog,
            MemoryRecall,
            Greeting,
            Help
        }

        /// <summary>
        /// Analyses the user's input and returns the most likely intent.
        /// Returns Intent.None if no intent is recognised — the existing
        /// ResponseManager will then handle the input.
        /// </summary>
        public static Intent DetectIntent(string input)
        {
            string s = input.ToLowerInvariant().Trim();

            // --- Activity Log ---
            if (ContainsAny(s, "show log", "activity log", "what have you done",
                               "recent actions", "show history", "view log"))
                return Intent.ShowLog;

            // --- Quiz ---
            if (ContainsAny(s, "start quiz", "play quiz", "quiz me", "test me",
                               "cybersecurity quiz", "begin quiz", "open quiz", "quiz"))
                return Intent.StartQuiz;

            // --- View Tasks ---
            if (ContainsAny(s, "show tasks", "view tasks", "my tasks",
                               "list tasks", "show my tasks", "see tasks"))
                return Intent.ViewTasks;

            // --- Add Task (many ways users might say this) ---
            if ((Contains(s, "add") && ContainsAny(s, "task", "to-do", "todo", "reminder")) ||
                (Contains(s, "create") && ContainsAny(s, "task", "reminder")) ||
                (Contains(s, "new task")) ||
                (Contains(s, "remind me to")) ||
                (Contains(s, "set reminder")) ||
                (Contains(s, "schedule")) ||
                (Contains(s, "don't forget") || Contains(s, "dont forget")))
                return Intent.AddTask;

            // --- Reminder (if add task didn't match but reminder intent is clear) ---
            if (ContainsAny(s, "set a reminder", "add reminder", "remind me in"))
                return Intent.SetReminder;

            // --- Memory Recall ---
            if (ContainsAny(s, "remember", "who am i", "my information",
                               "what do you know about me", "my name"))
                return Intent.MemoryRecall;

            // --- Greeting ---
            if (ContainsAny(s, "hello", "hi", "hey", "good morning", "good afternoon"))
                return Intent.Greeting;

            // --- Help ---
            if (ContainsAny(s, "help", "what can you do", "commands", "options"))
                return Intent.Help;

            return Intent.None;
        }

        private static bool Contains(string text, string keyword)
            => text.Contains(keyword);

        private static bool ContainsAny(string text, params string[] keywords)
        {
            foreach (var kw in keywords)
                if (text.Contains(kw)) return true;
            return false;
        }
    }
}
