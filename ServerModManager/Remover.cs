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
            Package package = overview.GetPackageWithName(val.packageName);
            if (package != null)
            {
                Console.WriteLine("Removing package " + val.packageName);
                if (!package.isDependency)
                {
                    if (val.pluginsExist)
                    {
                        File.Delete("../sm_plugins/" + package.filename);
                    }
                }
                else
                {
                    if (val.pluginsExist && val.dependenciesExist)
                    {
                        File.Delete("../sm_plugins/dependencies/" + package.filename);
                    }
                }
            }
            else
            {
                Console.WriteLine("ERROR: No package with name " + val.packageName);
            }
        }
    }
}
