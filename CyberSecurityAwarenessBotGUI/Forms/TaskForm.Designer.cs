using System.Drawing;
using System.Windows.Forms;

namespace CyberSecurityAwarenessBotGUI.Forms
{
    public partial class TaskForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private Label lblTaskTitle;
        private TextBox txtTaskTitle;

        private Label lblTaskDescription;
        private TextBox txtTaskDescription;

        private CheckBox chkSetReminder;
        private DateTimePicker dtpReminder;

        private Button btnAddTask;

        private DataGridView dgvTasks;

        private Button btnMarkComplete;
        private Button btnDeleteTask;
        private Button btnRefresh;

        private void InitializeComponent()
        {
            this.lblTaskTitle = new System.Windows.Forms.Label();
            this.txtTaskTitle = new System.Windows.Forms.TextBox();
            this.lblTaskDescription = new System.Windows.Forms.Label();
            this.txtTaskDescription = new System.Windows.Forms.TextBox();
            this.chkSetReminder = new System.Windows.Forms.CheckBox();
            this.dtpReminder = new System.Windows.Forms.DateTimePicker();
            this.btnAddTask = new System.Windows.Forms.Button();
            this.dgvTasks = new System.Windows.Forms.DataGridView();
            this.btnMarkComplete = new System.Windows.Forms.Button();
            this.btnDeleteTask = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTasks)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTaskTitle
            // 
            this.lblTaskTitle.Location = new System.Drawing.Point(20, 18);
            this.lblTaskTitle.Name = "lblTaskTitle";
            this.lblTaskTitle.Size = new System.Drawing.Size(90, 20);
            this.lblTaskTitle.TabIndex = 0;
            this.lblTaskTitle.Text = "Task Title:";
            // 
            // txtTaskTitle
            // 
            this.txtTaskTitle.Location = new System.Drawing.Point(120, 15);
            this.txtTaskTitle.Name = "txtTaskTitle";
            this.txtTaskTitle.Size = new System.Drawing.Size(300, 20);
            this.txtTaskTitle.TabIndex = 1;
            // 
            // lblTaskDescription
            // 
            this.lblTaskDescription.Location = new System.Drawing.Point(20, 50);
            this.lblTaskDescription.Name = "lblTaskDescription";
            this.lblTaskDescription.Size = new System.Drawing.Size(90, 20);
            this.lblTaskDescription.TabIndex = 2;
            this.lblTaskDescription.Text = "Description:";
            // 
            // txtTaskDescription
            // 
            this.txtTaskDescription.Location = new System.Drawing.Point(120, 47);
            this.txtTaskDescription.Multiline = true;
            this.txtTaskDescription.Name = "txtTaskDescription";
            this.txtTaskDescription.Size = new System.Drawing.Size(300, 60);
            this.txtTaskDescription.TabIndex = 3;
            // 
            // chkSetReminder
            // 
            this.chkSetReminder.Location = new System.Drawing.Point(20, 120);
            this.chkSetReminder.Name = "chkSetReminder";
            this.chkSetReminder.Size = new System.Drawing.Size(110, 24);
            this.chkSetReminder.TabIndex = 4;
            this.chkSetReminder.Text = "Set Reminder";
            // 
            // dtpReminder
            // 
            this.dtpReminder.Location = new System.Drawing.Point(140, 118);
            this.dtpReminder.Name = "dtpReminder";
            this.dtpReminder.Size = new System.Drawing.Size(200, 20);
            this.dtpReminder.TabIndex = 5;
            // 
            // btnAddTask
            // 
            this.btnAddTask.Location = new System.Drawing.Point(450, 12);
            this.btnAddTask.Name = "btnAddTask";
            this.btnAddTask.Size = new System.Drawing.Size(100, 35);
            this.btnAddTask.TabIndex = 6;
            this.btnAddTask.Text = "Add Task";
            this.btnAddTask.Click += new System.EventHandler(this.btnAddTask_Click);         // FIX: was missing
            // 
            // dgvTasks
            // 
            this.dgvTasks.AllowUserToAddRows = false;
            this.dgvTasks.Location = new System.Drawing.Point(20, 155);
            this.dgvTasks.Name = "dgvTasks";
            this.dgvTasks.ReadOnly = true;
            this.dgvTasks.Size = new System.Drawing.Size(540, 130);
            this.dgvTasks.TabIndex = 7;
            // 
            // btnMarkComplete
            // 
            this.btnMarkComplete.Location = new System.Drawing.Point(20, 295);
            this.btnMarkComplete.Name = "btnMarkComplete";
            this.btnMarkComplete.Size = new System.Drawing.Size(130, 30);
            this.btnMarkComplete.TabIndex = 8;
            this.btnMarkComplete.Text = "Mark Complete";
            this.btnMarkComplete.Click += new System.EventHandler(this.btnMarkComplete_Click); // FIX: was missing
            // 
            // btnDeleteTask
            // 
            this.btnDeleteTask.Location = new System.Drawing.Point(160, 295);
            this.btnDeleteTask.Name = "btnDeleteTask";
            this.btnDeleteTask.Size = new System.Drawing.Size(110, 30);
            this.btnDeleteTask.TabIndex = 9;
            this.btnDeleteTask.Text = "Delete Task";
            this.btnDeleteTask.Click += new System.EventHandler(this.btnDeleteTask_Click);     // FIX: was missing
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(280, 295);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 30);
            this.btnRefresh.TabIndex = 10;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);           // FIX: was missing
            // 
            // TaskForm
            // 
            this.ClientSize = new System.Drawing.Size(600, 345);
            this.Controls.Add(this.lblTaskTitle);
            this.Controls.Add(this.txtTaskTitle);
            this.Controls.Add(this.lblTaskDescription);
            this.Controls.Add(this.txtTaskDescription);
            this.Controls.Add(this.chkSetReminder);
            this.Controls.Add(this.dtpReminder);
            this.Controls.Add(this.btnAddTask);
            this.Controls.Add(this.dgvTasks);
            this.Controls.Add(this.btnMarkComplete);
            this.Controls.Add(this.btnDeleteTask);
            this.Controls.Add(this.btnRefresh);
            this.Name = "TaskForm";
            this.Text = "Task Assistant";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTasks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}