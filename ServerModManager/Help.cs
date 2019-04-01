using System;
using System.Collections.Generic;
using System.Text;

namespace ServerModManager
{
    class Help
    {
        public static void MainHelp()
        {
            Console.WriteLine("USAGE:\n" +
                "scpman help: Displays this message\n" +
                "scpman install: Installs packages\n" +
                "scpman remove: Removes packages");
        }

        public static void InstallHelp()
        {
            Console.WriteLine("USAGE: \n" +
                "scpman install packagename: Installs package packagename");
        }

        public static void RemoveHelp()
        {
            Console.WriteLine("USAGE: \n" +
                "scpman remove packagename: Removes package packagename");
        }
    }
}
