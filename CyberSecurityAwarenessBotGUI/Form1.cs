using System;
using System.Windows.Forms;
using System.Media;

namespace CyberSecurityAwarenessBotGUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // =========================================
            // PLAY VOICE GREETING
            // =========================================
            VoiceGreeting.PlayGreeting();

            // =========================================
            // ASK USER NAME
            // =========================================
            string userName = Prompt.ShowDialog(
                "Welcome to the CyberREQ-Chatbot!Enter your Name to Proceed\n\nPlease enter your name:",
                "User Identification");

            // Prevent empty name
            if (string.IsNullOrWhiteSpace(userName))
            {
                userName = "Guest";
            }

            // Save name into memory
            MemoryManager.SaveName(userName);

            // =========================================
            // WELCOME MESSAGE
            // =========================================
            rtbChat.AppendText(
                "==================================================" + Environment.NewLine +
                "        CYBERSECURITY AWARENESS CHATBOT" + Environment.NewLine +
                "==================================================" + Environment.NewLine +
                Environment.NewLine +

                "Hello " + userName + "!" + Environment.NewLine +
                "I am your Cybersecurity Awareness Assistant." +
                Environment.NewLine + Environment.NewLine +

                "I can help you understand:" + Environment.NewLine +
                "- Password Security" + Environment.NewLine +
                "- Phishing Attacks" + Environment.NewLine +
                "- Malware & Viruses" + Environment.NewLine +
                "- VPN Security" + Environment.NewLine +
                "- Online Scams" + Environment.NewLine +
                "- Safe Browsing" + Environment.NewLine +
                "- Suspicious Links" + Environment.NewLine +
                Environment.NewLine +

                "Type your cybersecurity question below." +
                Environment.NewLine + Environment.NewLine
            );
        }

        // =========================================
        // SEND BUTTON  (merged handler — NLP + sentiment + response)
        // =========================================
        private void btnSend_Click(object sender, EventArgs e)
        {
            string userInput = txtUserInput.Text.Trim();

            // =========================================
            // EMPTY INPUT CHECK
            // =========================================
            if (string.IsNullOrWhiteSpace(userInput))
            {
                MessageBox.Show("Please enter a message.");
                return;
            }

            // Count messages
            MemoryManager.IncrementQuestion();

            // =========================================
            // DISPLAY USER MESSAGE
            // =========================================
            rtbChat.AppendText("You: " + userInput + Environment.NewLine);

            // =========================================
            // NLP INTENT ROUTING
            // =========================================
            var intent = NlpEngine.DetectIntent(userInput);

            switch (intent)
            {
                case NlpEngine.Intent.ShowLog:
                    rtbChat.AppendText("CyberBot: " + ActivityLogger.GetFormattedLog()
                        + Environment.NewLine + Environment.NewLine);
                    ActivityLogger.Log("User requested activity log.");
                    txtUserInput.Clear();
                    return;

                case NlpEngine.Intent.StartQuiz:
                    ActivityLogger.Log("NLP: Detected quiz intent — opening quiz.");
                    rtbChat.AppendText("CyberBot: Opening the cybersecurity quiz for you!"
                        + Environment.NewLine + Environment.NewLine);
                    using (var quiz = new Forms.QuizForm())
                        quiz.ShowDialog();
                    txtUserInput.Clear();
                    return;

                case NlpEngine.Intent.AddTask:
                case NlpEngine.Intent.SetReminder:
                    ActivityLogger.Log("NLP: Detected task/reminder intent — opening Task Manager.");
                    rtbChat.AppendText(
                        "CyberBot: I noticed you want to add a task or set a reminder. " +
                        "Opening the Task Manager for you!" +
                        Environment.NewLine + Environment.NewLine);
                    using (var tasks = new Forms.TaskForm())
                        tasks.ShowDialog();
                    txtUserInput.Clear();
                    return;

                case NlpEngine.Intent.ViewTasks:
                    ActivityLogger.Log("NLP: Detected view tasks intent — opening Task Manager.");
                    using (var taskView = new Forms.TaskForm())
                        taskView.ShowDialog();
                    txtUserInput.Clear();
                    return;

                case NlpEngine.Intent.MemoryRecall:
                    rtbChat.AppendText("CyberBot: " + MemoryManager.GetInterests()
                        + Environment.NewLine + Environment.NewLine);
                    txtUserInput.Clear();
                    return;
            }

            // =========================================
            // SENTIMENT DETECTION
            // =========================================
            string sentimentResponse = SentimentResponse.GetSentiment(userInput);

            if (!string.IsNullOrEmpty(sentimentResponse))
            {
                rtbChat.AppendText(
                    "CyberBot: " + sentimentResponse +
                    Environment.NewLine + Environment.NewLine);
            }

            // =========================================
            // MEMORY STORAGE
            // =========================================
            if (userInput.ToLower().Contains("password"))
                MemoryManager.SaveInterest("Passwords");

            if (userInput.ToLower().Contains("phishing"))
                MemoryManager.SaveInterest("Phishing");

            if (userInput.ToLower().Contains("malware"))
                MemoryManager.SaveInterest("Malware");

            if (userInput.ToLower().Contains("vpn"))
                MemoryManager.SaveInterest("VPN");

            if (userInput.ToLower().Contains("scam"))
                MemoryManager.SaveInterest("Scams");

            if (userInput.ToLower().Contains("safe browsing"))
                MemoryManager.SaveInterest("Safe Browsing");

            // =========================================
            // MEMORY RECALL
            // =========================================
            if (userInput.ToLower().Contains("remember") ||
                userInput.ToLower().Contains("who am i") ||
                userInput.ToLower().Contains("my information"))
            {
                rtbChat.AppendText(
                    "CyberBot: " +
                    MemoryManager.GetInterests() +
                    Environment.NewLine + Environment.NewLine);

                txtUserInput.Clear();
                return;
            }

            // =========================================
            // GET & DISPLAY CHATBOT RESPONSE
            // =========================================
            string botResponse = ResponseManager.GetResponse(userInput);

            rtbChat.AppendText(
                "CyberBot: " + botResponse +
                Environment.NewLine + Environment.NewLine);

            txtUserInput.Clear();
        }

        // =========================================
        // CLEAR BUTTON
        // =========================================
        private void btnClear_Click(object sender, EventArgs e)
        {
            rtbChat.Clear();
            MemoryManager.ClearMemory();

            rtbChat.AppendText(
                "==================================================" + Environment.NewLine +
                "Chat and memory cleared successfully." +
                Environment.NewLine +
                "==================================================" +
                Environment.NewLine + Environment.NewLine);

            txtUserInput.Clear();
        }

        // =========================================
        // TASK TAB — Open Task Manager button
        // =========================================
        private void button1_Click(object sender, EventArgs e)
        {
            ActivityLogger.Log("User opened Task Manager via Tasks tab.");
            using (var form = new Forms.TaskForm())
                form.ShowDialog();
        }

        // =========================================
        // QUIZ TAB — Start Quiz button
        // =========================================
        private void btnStartQuiz_Click(object sender, EventArgs e)
        {
            ActivityLogger.Log("User started quiz via Quiz tab.");
            using (var form = new Forms.QuizForm())
                form.ShowDialog();
        }

        // =========================================
        // ACTIVITY LOG TAB — Refresh Log button
        // =========================================
        private void btnRefreshLog_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            var entries = ActivityLogger.GetAllEntries();
            int start = Math.Max(0, entries.Count - 10);
            for (int i = start; i < entries.Count; i++)
                listBox1.Items.Add(entries[i]);

            ActivityLogger.Log("User refreshed activity log.");
        }

        // =========================================
        // FORM LOAD
        // =========================================
        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}