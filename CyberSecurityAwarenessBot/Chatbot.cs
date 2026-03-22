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

            UIHelper.TypeText($"Hello {name}! I am your Cybersecurity Awareness Assistant.");

            ChatLoop();
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

        private void ChatLoop()
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
                    Console.WriteLine("Bot: Goodbye! Stay safe online.");
                    break;
                }

                string response = ResponseManager.GetResponse(input);

                Console.ForegroundColor = ConsoleColor.Green;
                UIHelper.TypeText("Bot: " + response);
                Console.ResetColor();
            }
        }
    }
}