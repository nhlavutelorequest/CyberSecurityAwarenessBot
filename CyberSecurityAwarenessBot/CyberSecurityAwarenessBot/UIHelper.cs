using System;
using System.Threading;

namespace CyberSecurityAwarenessBot
{
    class UIHelper
    {
        // Displays the ASCII logo at the start of the program
        public static void DisplayLogo()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine(@"
   _____       _               _____  ______ ____  
  / ____|     | |             |  __ \|  ____/ __ \ 
 | |     _   _| |__   ___ _ __| |__) | |__ | |  | |
 | |    | | | | '_ \ / _ \ '__|  _  /|  __|| |  | |
 | |____| |_| | |_) |  __/ |  | | \ \| |___| |__| |
  \_____|\__, |_.__/ \___|_|  |_|  \_\______\___\_\
          __/ |                                   
         |___/                                    

                CYBERSECURITY AWARENESS CHATBOT
");

            Console.ResetColor();
        }

        // Types text character by character for a typing effect
        public static void TypeText(string message)
        {
            foreach (char c in message)
            {
                Console.Write(c);
                Thread.Sleep(25);
            }

            Console.WriteLine();
        }
    }
}