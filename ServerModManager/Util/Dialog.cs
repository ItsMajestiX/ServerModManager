using System;

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
                    Console.WriteLine("Invalid response.");
                }
            }
        }
    }
}
