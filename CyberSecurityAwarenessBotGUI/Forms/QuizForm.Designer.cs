using System.Drawing;
using System.Windows.Forms;

namespace CyberSecurityAwarenessBotGUI.Forms
{
    public partial class QuizForm
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

        private Label lblQuestionNumber;
        private Label lblQuestion;

        private RadioButton rbOption0;
        private RadioButton rbOption1;
        private RadioButton rbOption2;
        private RadioButton rbOption3;

        private Button btnSubmit;

        private Label lblFeedback;
        private Label lblScore;

        private ProgressBar progressBar;

        private void InitializeComponent()
        {
            this.lblQuestionNumber = new System.Windows.Forms.Label();
            this.lblQuestion = new System.Windows.Forms.Label();
            this.rbOption0 = new System.Windows.Forms.RadioButton();
            this.rbOption1 = new System.Windows.Forms.RadioButton();
            this.rbOption2 = new System.Windows.Forms.RadioButton();
            this.rbOption3 = new System.Windows.Forms.RadioButton();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.lblFeedback = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // lblQuestionNumber
            // 
            this.lblQuestionNumber.Location = new System.Drawing.Point(20, 15);
            this.lblQuestionNumber.Name = "lblQuestionNumber";
            this.lblQuestionNumber.Size = new System.Drawing.Size(250, 30);
            this.lblQuestionNumber.TabIndex = 0;
            // 
            // lblQuestion
            // 
            this.lblQuestion.Location = new System.Drawing.Point(20, 45);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(640, 60);
            this.lblQuestion.TabIndex = 1;
            // 
            // rbOption0
            // 
            this.rbOption0.AutoSize = true;
            this.rbOption0.Location = new System.Drawing.Point(40, 120);
            this.rbOption0.Name = "rbOption0";
            this.rbOption0.Size = new System.Drawing.Size(14, 13);
            this.rbOption0.TabIndex = 2;
            // 
            // rbOption1
            // 
            this.rbOption1.AutoSize = true;
            this.rbOption1.Location = new System.Drawing.Point(40, 150);
            this.rbOption1.Name = "rbOption1";
            this.rbOption1.Size = new System.Drawing.Size(14, 13);
            this.rbOption1.TabIndex = 3;
            // 
            // rbOption2
            // 
            this.rbOption2.AutoSize = true;
            this.rbOption2.Location = new System.Drawing.Point(40, 180);
            this.rbOption2.Name = "rbOption2";
            this.rbOption2.Size = new System.Drawing.Size(14, 13);
            this.rbOption2.TabIndex = 4;
            // 
            // rbOption3
            // 
            this.rbOption3.AutoSize = true;
            this.rbOption3.Location = new System.Drawing.Point(40, 210);
            this.rbOption3.Name = "rbOption3";
            this.rbOption3.Size = new System.Drawing.Size(14, 13);
            this.rbOption3.TabIndex = 5;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(40, 250);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(150, 35);
            this.btnSubmit.TabIndex = 6;
            this.btnSubmit.Text = "Submit Answer";
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click); // FIX: was missing
            // 
            // lblFeedback
            // 
            this.lblFeedback.Location = new System.Drawing.Point(240, 120);
            this.lblFeedback.Name = "lblFeedback";
            this.lblFeedback.Size = new System.Drawing.Size(420, 130);
            this.lblFeedback.TabIndex = 7;
            // 
            // lblScore
            // 
            this.lblScore.Location = new System.Drawing.Point(520, 15);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(150, 30);
            this.lblScore.TabIndex = 8;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(20, 300);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(640, 38);
            this.progressBar.TabIndex = 9;
            // 
            // QuizForm
            // 
            this.ClientSize = new System.Drawing.Size(792, 350);
            this.Controls.Add(this.lblQuestionNumber);
            this.Controls.Add(this.lblQuestion);
            this.Controls.Add(this.rbOption0);
            this.Controls.Add(this.rbOption1);
            this.Controls.Add(this.rbOption2);
            this.Controls.Add(this.rbOption3);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.lblFeedback);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.progressBar);
            this.Name = "QuizForm";
            this.Text = "Cybersecurity Quiz";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}