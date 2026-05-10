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

            // Play voice greeting when GUI opens
            VoiceGreeting.PlayGreeting();

            // Welcome message with ASCII style
            rtbChat.AppendText(
                "======================================" + Environment.NewLine +
                "   CYBER REQ AWARENESS CHATBOT   " + Environment.NewLine +
                "======================================" + Environment.NewLine +
                "Hello! I am your cybersecurity assistant." + Environment.NewLine +
                "You can ask me about:" + Environment.NewLine +
                "- Passwords" + Environment.NewLine +
                "- Phishing" + Environment.NewLine +
                "- Malware" + Environment.NewLine +
                "- VPNs" + Environment.NewLine +
                "- Scams" + Environment.NewLine +
                "- Safe Browsing" + Environment.NewLine +
                "- Suspicious Links" + Environment.NewLine +
                Environment.NewLine
            );
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string userInput = txtUserInput.Text.Trim();

            // Check empty input
            if (string.IsNullOrWhiteSpace(userInput))
            {
                MessageBox.Show("Please enter a message.");
                return;
            }

            // Display user message
            rtbChat.AppendText(
                "You: " + userInput +
                Environment.NewLine);

            // =========================
            // SENTIMENT DETECTION
            // =========================

            string sentimentResponse =
                SentimentResponse.GetSentiment(userInput);

            if (!string.IsNullOrEmpty(sentimentResponse))
            {
                rtbChat.AppendText(
                    "Bot: " + sentimentResponse +
                    Environment.NewLine + Environment.NewLine);
            }

            // =========================
            // MEMORY STORAGE
            // =========================

            if (userInput.ToLower().Contains("password"))
            {
                MemoryManager.SaveInterest("Passwords");
            }

            if (userInput.ToLower().Contains("phishing"))
            {
                MemoryManager.SaveInterest("Phishing");
            }

            if (userInput.ToLower().Contains("malware"))
            {
                MemoryManager.SaveInterest("Malware");
            }

            if (userInput.ToLower().Contains("vpn"))
            {
                MemoryManager.SaveInterest("VPN");
            }

            if (userInput.ToLower().Contains("scam"))
            {
                MemoryManager.SaveInterest("Scams");
            }

            if (userInput.ToLower().Contains("safe browsing"))
            {
                MemoryManager.SaveInterest("Safe Browsing");
            }

            // =========================
            // MEMORY RECALL
            // =========================

            if (userInput.ToLower().Contains("remember"))
            {
                rtbChat.AppendText(
                    "Bot: " +
                    MemoryManager.GetInterests() +
                    Environment.NewLine + Environment.NewLine);

                txtUserInput.Clear();
                return;
            }

            // =========================
            // GET CHATBOT RESPONSE
            // =========================

            string botResponse =
                ResponseManager.GetResponse(userInput);

            // Display chatbot response
            rtbChat.AppendText(
                "Bot: " + botResponse +
                Environment.NewLine + Environment.NewLine);

            // Clear textbox
            txtUserInput.Clear();
        }

        // CLEAR BUTTON
        private void btnClear_Click(object sender, EventArgs e)
        {
            rtbChat.Clear();

            rtbChat.AppendText(
                "======================================" + Environment.NewLine +
                "Chat cleared successfully." +
                Environment.NewLine +
                "======================================" +
                Environment.NewLine + Environment.NewLine);

            txtUserInput.Clear();
        }
    }
}


