using System;
using System.Windows.Forms;

namespace CyberSecurityAwarenessBotGUI.Forms
{
    public partial class QuizForm : Form
    {
        private int _currentIndex = 0;
        private int _score = 0;
        private bool _answered = false;

        public QuizForm()
        {
            InitializeComponent();
            ActivityLogger.Log("Quiz started.");
            LoadQuestion();
        }

        private void LoadQuestion()
        {
            if (_currentIndex >= QuizManager.TotalQuestions)
            {
                ShowFinalScore();
                return;
            }

            _answered = false;
            lblFeedback.Text = "";
            btnSubmit.Text = "Submit Answer";

            var q = QuizManager.GetQuestion(_currentIndex);

            lblQuestionNumber.Text = "Question " + (_currentIndex + 1) +
                                     " of " + QuizManager.TotalQuestions;
            lblQuestion.Text = q.Question;
            lblScore.Text = "Score: " + _score + " / " + _currentIndex;

            progressBar.Maximum = QuizManager.TotalQuestions;
            progressBar.Value = _currentIndex;

            var rbs = new[] { rbOption0, rbOption1, rbOption2, rbOption3 };
            for (int i = 0; i < rbs.Length; i++)
            {
                if (i < q.Options.Length)
                {
                    rbs[i].Text = q.Options[i];
                    rbs[i].Visible = true;
                    rbs[i].Checked = false;
                }
                else
                {
                    rbs[i].Visible = false;
                }
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (_answered)
            {
                _currentIndex++;
                LoadQuestion();
                return;
            }

            var rbs = new[] { rbOption0, rbOption1, rbOption2, rbOption3 };
            int selected = -1;
            for (int i = 0; i < rbs.Length; i++)
                if (rbs[i].Checked) { selected = i; break; }

            if (selected == -1)
            {
                MessageBox.Show("Please select an answer before submitting.");
                return;
            }

            var q = QuizManager.GetQuestion(_currentIndex);
            _answered = true;

            if (selected == q.CorrectIndex)
            {
                _score++;
                lblFeedback.ForeColor = System.Drawing.Color.Green;
                lblFeedback.Text = "Correct!\n\n" + q.Explanation;
            }
            else
            {
                lblFeedback.ForeColor = System.Drawing.Color.Red;
                lblFeedback.Text = "Incorrect. The correct answer was: " +
                                        q.Options[q.CorrectIndex] +
                                        "\n\n" + q.Explanation;
            }

            btnSubmit.Text = "Next Question";
            lblScore.Text = "Score: " + _score + " / " + (_currentIndex + 1);
        }

        private void ShowFinalScore()
        {
            progressBar.Value = QuizManager.TotalQuestions;

            string feedback = QuizManager.GetFinalFeedback(_score, QuizManager.TotalQuestions);
            lblQuestion.Text = "Quiz Complete!\n\nFinal Score: " + _score +
                               " / " + QuizManager.TotalQuestions +
                               "\n\n" + feedback;

            lblFeedback.Text = "";
            rbOption0.Visible = rbOption1.Visible =
            rbOption2.Visible = rbOption3.Visible = false;

            btnSubmit.Text = "Close";
            btnSubmit.Click -= btnSubmit_Click;
            btnSubmit.Click += (s, ev) => this.Close();

            ActivityLogger.Log("Quiz completed. Score: " + _score +
                               " / " + QuizManager.TotalQuestions);
        }
    }
}