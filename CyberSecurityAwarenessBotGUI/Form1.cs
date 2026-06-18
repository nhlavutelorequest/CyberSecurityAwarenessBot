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
        // SEND BUTTON
        // =========================================
        private void btnSend_Click(object sender, EventArgs e)
        {
            string userInput = txtUserInput.Text.Trim();

            // Count messages
            MemoryManager.IncrementQuestion();

            // =========================================
            // EMPTY INPUT CHECK
            // =========================================
            if (string.IsNullOrWhiteSpace(userInput))
            {
                MessageBox.Show("Please enter a message.");
                return;
            }

            // =========================================
            // DISPLAY USER MESSAGE
            // =========================================
            rtbChat.AppendText(
                "You: " + userInput +
                Environment.NewLine);

            // =========================================
            // SENTIMENT DETECTION
            // =========================================
            string sentimentResponse =
                SentimentResponse.GetSentiment(userInput);

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
            // GET CHATBOT RESPONSE
            // =========================================
            string botResponse =
                ResponseManager.GetResponse(userInput);

            // =========================================
            // DISPLAY CHATBOT RESPONSE
            // =========================================
            rtbChat.AppendText(
                "CyberBot: " + botResponse +
                Environment.NewLine + Environment.NewLine);

            // Clear textbox
            txtUserInput.Clear();
        }

        // =========================================
        // CLEAR BUTTON
        // =========================================
        private void btnClear_Click(object sender, EventArgs e)
        {
            // Clear chat
            rtbChat.Clear();

            // Clear memory system
            MemoryManager.ClearMemory();

            // Display clear message
            rtbChat.AppendText(
                "==================================================" + Environment.NewLine +
                "Chat and memory cleared successfully." +
                Environment.NewLine +
                "==================================================" +
                Environment.NewLine + Environment.NewLine);

            txtUserInput.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSend_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
