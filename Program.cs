using System;

namespace CyberSecurityAwarenessBot
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of the Chatbot class
            Chatbot bot = new Chatbot();

            // Start the chatbot application ( runs the chat logic)
            bot.Start();

            // Keeps the console window open until a key is pressed
            // This prevents the program from closing immediately after execution
            Console.ReadKey();
        }
    }
}