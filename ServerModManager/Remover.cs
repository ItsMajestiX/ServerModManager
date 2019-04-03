using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ServerModManager
{
    class Remover
    {
        internal static void remove(Validator val, PackageOverview overview)
        {
            //Find package to remove
            Package package = overview.GetPackageWithName(val.packageName);
            //Remove it if it exists
            if (package != null)
            {
                if (File.Exists("../sm_plugins/" + package.downloadLocation))
                {
                    Console.WriteLine("Removing package " + val.packageName);
                    //Remove
                    if (val.pluginsExist && val.dependenciesExist)
                    {
                        File.Delete("../sm_plugins/" + package.downloadLocation);
                    }
                    else
                    {
                        Console.WriteLine("ERROR: sm_plugins and/or dependencies could not be found. Did you unzip all the app files into a folder at the same level as sm_plugins?");
                    }
                }
                else
                {
                    Console.WriteLine("ERROR: You have not installed that package!");
                }
            }
            else
            {
                Console.WriteLine("ERROR: No package with name " + val.packageName);
            }
        }
    }
}
