using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ServerModManager
{
    class Remover
    {
        public static void remove(Package package, Validator val)
        {
            //Remove it if it exists
            if (package != null)
            {
                if (File.Exists("../sm_plugins/" + package.downloadLocation))
                {
                    Console.WriteLine("Removing package " + package.name);
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
                Console.WriteLine("WARNING: No package with name " + package.name + ", skipping");
            }
        }
        public static void removePackages(Validator val, PackageOverview overview)
        {
            foreach (string i in val.packageNames)
            {
                Package current = overview.GetPackageWithName(i);
                remove(current, val);
            }
        }
    }
}
