using System;

namespace CyberSecurityAwarenessBotGUI.Models
{
    /// <summary>
    /// Represents a single cybersecurity task stored in the database.
    /// </summary>
    public class CyberTask
    {
        public int TaskId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? ReminderDate { get; set; }   // nullable: null = no reminder set
        public bool IsCompleted { get; set; }
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Formats ReminderDate for display in the DataGridView.
        /// </summary>
        public string ReminderDisplay =>
            ReminderDate.HasValue
                ? ReminderDate.Value.ToString("dd MMM yyyy")
                : "None";
    }
}