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

        // =========================================
        // ADD TASK
        // =========================================
        private void btnAddTask_Click(object sender, EventArgs e)
        {
            DateTime? reminder = chkSetReminder.Checked
                ? dtpReminder.Value
                : (DateTime?)null;

            DatabaseManager.AddTask(
                txtTaskTitle.Text.Trim(),
                txtTaskDescription.Text.Trim(),
                reminder
            );

            MessageBox.Show("Task added successfully!");

            txtTaskTitle.Clear();
            txtTaskDescription.Clear();

            LoadTasks();
        }

        // =========================================
        // MARK COMPLETE
        // =========================================
        private void btnMarkComplete_Click(object sender, EventArgs e)
        {
            if (dgvTasks.CurrentRow == null) return;

            var task = dgvTasks.CurrentRow.DataBoundItem as CyberTask;
            if (task == null) return;

            DatabaseManager.MarkCompleted(task.TaskId);

            LoadTasks();
        }

        // =========================================
        // DELETE TASK
        // =========================================
        private void btnDeleteTask_Click(object sender, EventArgs e)
        {
            if (dgvTasks.CurrentRow == null) return;

            var task = dgvTasks.CurrentRow.DataBoundItem as CyberTask;
            if (task == null) return;

            var confirm = MessageBox.Show(
                "Delete task: \"" + task.Title + "\"?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                DatabaseManager.DeleteTask(task.TaskId);
                LoadTasks();
            }
        }

        // =========================================
        // REFRESH BUTTON
        // =========================================
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadTasks();
        }
    }
}