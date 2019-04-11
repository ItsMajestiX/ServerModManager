using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ServerModManager
{
    class Remover
    {
        private static void Remove(Package package, Validator val)
        {
            //Check if it exists.
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
                Console.WriteLine("WARNING: You have not installed " + package.name + ", skipping.");
            }
        }
        //Design standard
        public static void RemovePackages(Validator val, PackageOverview overview)
        {
            foreach (string i in val.packageNames)
            {
                Package current = overview.GetPackageWithName(i);
                if (current != null)
                {
                    Remove(current, val);
                }
                else
                {
                    Console.WriteLine("WARNING: No package with name " + i + ".");
                }
            }
        }
    }
}
