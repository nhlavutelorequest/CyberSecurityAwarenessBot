using System;
using System.Threading;

namespace CyberSecurityAwarenessBot
{
    class UIHelper
    {
        public static void DisplayLogo()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine(@"
   _____           _               _____                 _       
  / ____|         | |             / ____|               | |      
 | |     _   _ ___| |_ ___ _ __  | (___  _   _ _ __ ___ | |__    
 | |    | | | / __| __/ _ \ '__|  \___ \| | | | '_ ` _ \| '_ \   
 | |____| |_| \__ \ ||  __/ |     ____) | |_| | | | | | | |_) |  
  \_____|\__, |___/\__\___|_|    |_____/ \__, |_| |_| |_|_.__/   
          __/ |                          __/ |                   
         |___/                          |___/                    

      CYBERSECURITY AWARENESS CHATBOT
");

            Console.ResetColor();
        }

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