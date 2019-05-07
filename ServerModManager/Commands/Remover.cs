using System;
using System.IO;

using Pastel;

using ServerModManager.PackageType;
using ServerModManager.Util;
using ServerModManager.Validation;

namespace ServerModManager.Commands
{
    class Remover
    {
        private static void Remove(Package package, Validator val, PackageOverview overview)
        {
            //Check if it exists.
            if (PackageUtil.DoesPackageExist(package))
            {
                Console.WriteLine("Removing package " + package.name);
                //Remove
                if (PackageUtil.DoesDirectoryExist(package))
                {
                    File.Delete("../sm_plugins/" + package.downloadLocation);
                }
                else
                {
                    Console.WriteLine("ERROR: sm_plugins and/or dependencies could not be found. Did you unzip all the app files into a folder at the same level as sm_plugins?".Pastel("ff0000"));
                }
            }
            else
            {
                Console.WriteLine(("WARNING: You have not installed " + package.name + ", skipping.").Pastel("ffff00"));
            }
        }
        //Design standard
        public static void RemovePackages(Validator val, PackageOverview overview)
        {
            if (val.removeAll)
            {
                foreach (Package i in overview.packages)
                {
                    //It's redundant, but prevents spamming errors.
                    if (PackageUtil.DoesPackageExist(i))
                    {
                        Remove(i, val, overview);
                    }
                }
            }
            else
            {
                foreach (string i in val.packageNames)
                {
                    Package current = overview.GetPackageWithName(i);
                    if (current != null)
                    {
                        Remove(current, val, overview);
                    }
                    else
                    {
                        Console.WriteLine(("WARNING: No package with name " + i + ".").Pastel("ffff00"));
                    }
                }
            }
        }
    }
}
