using System;

namespace ServerModManager.Util
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
                "scpman install [-d] packagename [packagename2 packagename3]: Installs packages packagename and optionally others listed.\n" +
                "FLAGS:\n" +
                "-f: Creates missing directories.");
        }

        public static void RemoveHelp()
        {
            Console.WriteLine("USAGE: \n" + 
                "scpman remove packagename [packagename2 packagename3]: Removes package packagename and optionally others listed.\n" +
                "scpman remove *: Removes all packages installed.");
        }

        public static void UpdateHelp()
        {
            Console.WriteLine("USAGE: \n" +
                "scpman update [-f] *: Updates all installed packages.\n" +
                "scpman update [-f] package [package2 package3]: Updates packages listed.\n" +
                "FLAGS: \n" +
                "f: Overwrites the old file with the new one even if they are the same.");
        }
    }
}
