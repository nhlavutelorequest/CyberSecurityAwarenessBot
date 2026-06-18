using System;
using System.Collections.Generic;
using System.Text;

namespace CyberSecurityAwarenessBotGUI
{
    /// <summary>
    /// Records significant chatbot actions during the current session.
    /// Stores up to 50 entries; displays the last 10 to the user.
    /// </summary>
    public static class ActivityLogger
    {
        private static readonly List<string> _log = new List<string>();
        private const int MaxVisible = 10;

        /// <summary>Adds a new entry to the activity log with a timestamp.</summary>
        public static void Log(string action)
        {
            string entry = "[" + DateTime.Now.ToString("HH:mm:ss") + "] " + action;
            _log.Add(entry);

            // Keep the log from growing indefinitely
            if (_log.Count > 50)
                _log.RemoveAt(0);
        }

        /// <summary>
        /// Returns a formatted string of the last 10 log entries for display in chat.
        /// </summary>
        public static string GetFormattedLog()
        {
            if (_log.Count == 0)
                return "No actions have been recorded yet this session.";

            var sb = new StringBuilder();
            sb.AppendLine("Here is a summary of recent actions:");
            sb.AppendLine();

            int start = Math.Max(0, _log.Count - MaxVisible);
            int number = 1;

            for (int i = start; i < _log.Count; i++)
            {
                sb.AppendLine(number + ". " + _log[i]);
                number++;
            }

            return sb.ToString();
        }

        /// <summary>Returns all log entries as a List for binding to a ListBox.</summary>
        public static List<string> GetAllEntries() => new List<string>(_log);

        /// <summary>Returns the total number of logged actions this session.</summary>
        public static int Count => _log.Count;
    }
}