using Newtonsoft.Json;

using System;
using System.Collections.Generic;

using ServerModManager.PackageType;
using ServerModManager.Util;

namespace ServerModManager.Commands
{
    class Packager
    {
        public static void PackagePlugin()
        {
            string name = Dialog.Prompt("Enter package name: ");
            string author = Dialog.Prompt("Enter package author(s): ");
            string version = Dialog.Prompt("Enter package version: ");
            List<string> dependencies = Dialog.MultiPrompt("Enter package dependencies, seperated by spaces: ");
            List<string> incompatibilities = Dialog.MultiPrompt("Enter package incompatibilities, seperated by spaces: ");
            string downloadLink = Dialog.Prompt("Enter download link of package DLL: ");
            string downloadLocation = Dialog.Prompt("Enter download location, relative to sm_plugins/: ");
            Console.WriteLine(JsonConvert.SerializeObject(new Package(name, author, version, dependencies, incompatibilities, downloadLink, downloadLocation)));
            Console.WriteLine("Send the text above to me at MajestiX#7652 on discord and I'll get it added!");
        }
    }
}
