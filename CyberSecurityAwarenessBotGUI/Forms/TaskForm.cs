using System;
using System.Windows.Forms;
using CyberSecurityAwarenessBotGUI.Models;
using CyberSecurityAwarenessBotGUI.Data;

namespace CyberSecurityAwarenessBotGUI.Forms
{
    public partial class TaskForm : Form
    {
        public TaskForm()
        {
            InitializeComponent();

            dtpReminder.Enabled = false;

            chkSetReminder.CheckedChanged += (s, e) =>
                dtpReminder.Enabled = chkSetReminder.Checked;

            LoadTasks();
        }

        // =========================================
        // LOAD TASKS FROM DATABASE
        // =========================================
        private void LoadTasks()
        {
            try
            {
                var tasks = DatabaseManager.GetAllTasks();

                dgvTasks.DataSource = null;
                dgvTasks.DataSource = tasks;

                if (dgvTasks.Columns["TaskId"] != null)
                    dgvTasks.Columns["TaskId"].Visible = false;

                if (dgvTasks.Columns["ReminderDate"] != null)
                    dgvTasks.Columns["ReminderDate"].Visible = false;

                if (dgvTasks.Columns["Title"] != null)
                    dgvTasks.Columns["Title"].HeaderText = "Task";

                if (dgvTasks.Columns["Description"] != null)
                    dgvTasks.Columns["Description"].HeaderText = "Details";

                if (dgvTasks.Columns["IsCompleted"] != null)
                    dgvTasks.Columns["IsCompleted"].HeaderText = "Done?";

                if (dgvTasks.Columns["CreatedAt"] != null)
                    dgvTasks.Columns["CreatedAt"].HeaderText = "Date Added";

                if (dgvTasks.Columns["ReminderDisplay"] != null)
                    dgvTasks.Columns["ReminderDisplay"].HeaderText = "Reminder";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Could not load tasks from the database.\n\n" +
                    "Make sure MySQL is running and the connection details in DatabaseManager.cs are correct.\n\n" +
                    "Error: " + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================
        // ADD TASK
        // =========================================
        private void btnAddTask_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTaskTitle.Text))
            {
                MessageBox.Show("Please enter a task title.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DateTime? reminder = chkSetReminder.Checked
                    ? dtpReminder.Value
                    : (DateTime?)null;

                // FIX: route through TaskManager (not DatabaseManager directly)
                // so the action gets recorded in the Activity Log.
                string resultMessage = TaskManager.AddTask(
                    txtTaskTitle.Text.Trim(),
                    txtTaskDescription.Text.Trim(),
                    reminder
                );

                MessageBox.Show(resultMessage);

                txtTaskTitle.Clear();
                txtTaskDescription.Clear();
                chkSetReminder.Checked = false;

                LoadTasks();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Failed to add task.\n\nError: " + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================
        // MARK COMPLETE
        // =========================================
        private void btnMarkComplete_Click(object sender, EventArgs e)
        {
            if (dgvTasks.CurrentRow == null)
            {
                MessageBox.Show("Please select a task first.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var task = dgvTasks.CurrentRow.DataBoundItem as CyberTask;
            if (task == null) return;

            try
            {
                // FIX: route through TaskManager so this gets logged.
                TaskManager.MarkCompleted(task.TaskId, task.Title);
                LoadTasks();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Failed to update task.\n\nError: " + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================
        // DELETE TASK
        // =========================================
        private void btnDeleteTask_Click(object sender, EventArgs e)
        {
            if (dgvTasks.CurrentRow == null)
            {
                MessageBox.Show("Please select a task first.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var task = dgvTasks.CurrentRow.DataBoundItem as CyberTask;
            if (task == null) return;

            var confirm = MessageBox.Show(
                "Delete task: \"" + task.Title + "\"?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    // FIX: route through TaskManager so this gets logged.
                    TaskManager.DeleteTask(task.TaskId, task.Title);
                    LoadTasks();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Failed to delete task.\n\nError: " + ex.Message,
                        "Database Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        // =========================================
        // REFRESH BUTTON
        // =========================================
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadTasks();
            ActivityLogger.Log("User refreshed the task list.");
        }
    }
}