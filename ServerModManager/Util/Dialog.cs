using System;
using System.Collections.Generic;
using Pastel;

namespace ServerModManager.Util
{
    class Dialog
    {
        public static bool YNDialog(string msg)
        {
            while (true)
            {
                Console.Write(msg);
                ConsoleKeyInfo res = Console.ReadKey();
                Console.WriteLine();
                if (res.KeyChar == 'Y' || res.KeyChar == 'y')
                {
                    return true;
                }
                else if (res.KeyChar == 'N' || res.KeyChar == 'n')
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Invalid response.".Pastel("ff0000"));
                }
            }
        }

        public static string Prompt(string msg)
        {
            Console.Write(msg);
            string answer = Console.ReadLine();
            Console.WriteLine();
            return answer;
        }

        public static List<string> MultiPrompt(string msg)
        {
            Console.Write(msg);
            string answer = Console.ReadLine();
            Console.WriteLine();
            return new List<string>(answer.Split(" "));
        }
    }
}
