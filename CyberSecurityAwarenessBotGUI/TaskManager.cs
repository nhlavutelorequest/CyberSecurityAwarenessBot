using System;
using System.Collections.Generic;
using CyberSecurityAwarenessBotGUI.Data;
using CyberSecurityAwarenessBotGUI.Models;

namespace CyberSecurityAwarenessBotGUI
{
    /// <summary>
    /// Business logic layer for task operations.
    /// Coordinates between the database and the activity log.
    /// </summary>
    public static class TaskManager
    {
        public static string AddTask(string title, string description, DateTime? reminderDate)
        {
            if (string.IsNullOrWhiteSpace(title))
                return "Please provide a task title.";

            DatabaseManager.AddTask(title, description, reminderDate);

            string logMessage = "Task added: '" + title + "'";
            if (reminderDate.HasValue)
                logMessage += " (Reminder: " + reminderDate.Value.ToString("dd MMM yyyy") + ")";

            ActivityLogger.Log(logMessage);

            return "Task added: \"" + title + "\"\n" +
                   (reminderDate.HasValue
                       ? "Reminder set for " + reminderDate.Value.ToString("dd MMM yyyy") + "."
                       : "No reminder set.");
        }

        public static List<CyberTask> GetAllTasks() => DatabaseManager.GetAllTasks();

        public static void MarkCompleted(int taskId, string title)
        {
            DatabaseManager.MarkCompleted(taskId);
            ActivityLogger.Log("Task completed: '" + title + "'");
        }

        public static void DeleteTask(int taskId, string title)
        {
            DatabaseManager.DeleteTask(taskId);
            ActivityLogger.Log("Task deleted: '" + title + "'");
        }
    }
}