using CyberSecurityAwarenessBotGUI.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace CyberSecurityAwarenessBotGUI.Data
{
    public static class DatabaseManager
    {
        // FIX: MySql.Data 9.7.0 renamed the SslMode enum members.
        // "None" no longer exists - use "Disabled" instead (or drop SslMode
        // entirely for localhost connections, since SSL isn't needed there).
        //
        // FIX 2: MySQL 8+ default auth plugin is "caching_sha2_password",
        // which needs RSA key exchange. With SSL disabled, the connector
        // blocks this unless AllowPublicKeyRetrieval=True is explicitly set.
        private const string ConnectionString =
            "Server=localhost;" +
            "Database=CyberBotDB;" +
            "Uid=root;" +
            "Pwd=Request@16$;" +
            "SslMode=Disabled;" +
            "AllowPublicKeyRetrieval=True;";

        // =========================================
        // TEST CONNECTION
        // =========================================
        public static bool TestConnection()
        {
            try
            {
                using (var conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        // =========================================
        // GET ALL TASKS (SAFE VERSION)
        // =========================================
        public static List<CyberTask> GetAllTasks()
        {
            var tasks = new List<CyberTask>();

            using (var conn = new MySqlConnection(ConnectionString))
            {
                conn.Open();

                string sql =
                    "SELECT TaskId, Title, Description, ReminderDate, IsCompleted, CreatedAt " +
                    "FROM Tasks ORDER BY CreatedAt DESC;";

                using (var cmd = new MySqlCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tasks.Add(new CyberTask
                        {
                            TaskId = reader.IsDBNull(reader.GetOrdinal("TaskId"))
                                ? 0
                                : reader.GetInt32("TaskId"),

                            Title = reader.IsDBNull(reader.GetOrdinal("Title"))
                                ? ""
                                : reader.GetString("Title"),

                            Description = reader.IsDBNull(reader.GetOrdinal("Description"))
                                ? ""
                                : reader.GetString("Description"),

                            ReminderDate = reader.IsDBNull(reader.GetOrdinal("ReminderDate"))
                                ? (DateTime?)null
                                : reader.GetDateTime("ReminderDate"),

                            IsCompleted = reader.IsDBNull(reader.GetOrdinal("IsCompleted"))
                                ? false
                                : reader.GetBoolean("IsCompleted"),

                            CreatedAt = reader.IsDBNull(reader.GetOrdinal("CreatedAt"))
                                ? DateTime.Now
                                : reader.GetDateTime("CreatedAt")
                        });
                    }
                }
            }

            return tasks;
        }

        // =========================================
        // ADD TASK
        // =========================================
        public static int AddTask(string title, string description, DateTime? reminderDate)
        {
            using (var conn = new MySqlConnection(ConnectionString))
            {
                conn.Open();

                string sql =
                    "INSERT INTO Tasks (Title, Description, ReminderDate) " +
                    "VALUES (@title, @desc, @reminder); " +
                    "SELECT LAST_INSERT_ID();";

                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@title", title);
                    cmd.Parameters.AddWithValue("@desc", description);
                    cmd.Parameters.AddWithValue("@reminder",
                        reminderDate.HasValue ? (object)reminderDate.Value : DBNull.Value);

                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        // =========================================
        // MARK TASK AS COMPLETED
        // =========================================
        public static void MarkCompleted(int taskId)
        {
            using (var conn = new MySqlConnection(ConnectionString))
            {
                conn.Open();

                string sql = "UPDATE Tasks SET IsCompleted = 1 WHERE TaskId = @id;";

                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", taskId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // =========================================
        // DELETE TASK
        // =========================================
        public static void DeleteTask(int taskId)
        {
            using (var conn = new MySqlConnection(ConnectionString))
            {
                conn.Open();

                string sql = "DELETE FROM Tasks WHERE TaskId = @id;";

                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", taskId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}