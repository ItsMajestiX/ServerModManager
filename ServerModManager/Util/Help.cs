using System;
using System.Collections.Generic;
using System.Text;

namespace ServerModManager
{
    class Help
    {
        //Show help statements
        public static void MainHelp()
        {
            Console.WriteLine("USAGE:\n" +
                "scpman help: Displays this message.\n" +
                "scpman install: Installs packages.\n" +
                "scpman remove: Removes packages. \n" +
                "scpman update: Updates packages.");
        }

        public static void InstallHelp()
        {
            Console.WriteLine("USAGE: \n" +
                "scpman install packagename [packagename2 packagename3]: Installs packages packagename and optionally others listed.");
        }

        public static void RemoveHelp()
        {
            Console.WriteLine("USAGE: \n" + 
                "scpman remove packagename [packagename2 packagename3]: Removes package packagename and optionally others listed.");
        }

        public static void UpdateHelp()
        {
            Console.WriteLine("USAGE: \n" +
                "scpman update *: Updates all installed packages.\n" +
                "scpman update package [package2 package3]: Updates packages listed.");
        }
    }
}
