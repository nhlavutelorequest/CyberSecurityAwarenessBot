using System;

namespace CyberSecurityAwarenessBot
{
    class Chatbot
    {
        public void Start()
        {
            VoiceGreeting.PlayGreeting();

            UIHelper.DisplayLogo();

            string name = AskUserName();

            UIHelper.TypeText($"\nHello {name}! I am your Cybersecurity Awareness Assistant.");
            UIHelper.TypeText("You can ask me about cybersecurity topics like phishing, passwords, scams, and safe browsing.");
            UIHelper.TypeText("Type 'exit' anytime to quit.\n");

            ChatLoop(name);
        }

        private string AskUserName()
        {
            Console.Write("\nEnter your name: ");
            string name = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(name))
            {
                Console.Write("Please enter a valid name: ");
                name = Console.ReadLine();
            }

            return name;
        }

        private void ChatLoop(string name)
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\nYou: ");
                Console.ResetColor();

                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Bot: Please type something.");
                    continue;
                }

                if (input.ToLower() == "exit")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    UIHelper.TypeText($"Bot: Goodbye {name}! Stay safe online.");
                    Console.ResetColor();
                    break;
                }

                string response = ResponseManager.GetResponse(input);

                Console.ForegroundColor = ConsoleColor.Green;

                //  PERSONALIZED RESPONSE
                UIHelper.TypeText($"Bot: {name}, {response}");

                Console.ResetColor();
            }
        }
    }
}