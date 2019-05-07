using System;
using System.IO;
using System.Net;

using Pastel;

using ServerModManager.PackageType;
using ServerModManager.Util;
using ServerModManager.Validation;

namespace ServerModManager.Commands
{
    class Updater
    {
        public static void Update(Package package, Validator val, PackageOverview overview)
        {
            //Create tmp dir so files are gone after execution.
            using (TmpDir dir = new TmpDir("."))
            using (WebClient client = new WebClient())
            {
                //Check if it exists
                if (PackageUtil.DoesPackageExist(package))
                {
                    string filename = Path.GetFileName(package.downloadLocation);
                    Console.WriteLine("Getting newest version of package " + package.name);
                    //Setup loading bar
                    client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(LoadingBar.DownloadProgressCallback);
                    //Get latest version
                    client.DownloadFileTaskAsync(package.downloadLink, dir.dirName + filename).Wait();
                    //Compare. The && ! will make it so that it will always go to 2nd case if val.forceUpdate is ture.
                    if (FileCompare.CompareFiles(dir.dirName + filename, "../sm_plugins/" + package.downloadLocation) && !val.forceUpdate)
                    {
                        Console.WriteLine(package.name + " is up to date.");
                    }
                    else
                    {
                        File.Move(dir.dirName + filename, "../sm_plugins/" + package.downloadLocation, true);
                        Console.WriteLine(package.name + " was updated.");
                    }
                }
                else
                {
                    Console.WriteLine(("WARNING: Package " + package.name + " is not installed. Skipping.").Pastel("ffff00"));
                }
            }
        }
        //Design standard
        public static void UpdatePackages(Validator val, PackageOverview overview)
        {
            //If we update all with wildcard *. This method doesn't require a list of previous packages.
            if (val.updateAll)
            {
                foreach (Package i in overview.packages)
                {
                    if (PackageUtil.DoesPackageExist(i))
                    {
                        Update(i, val, overview);
                    }
                }
            }
            //If we list packages
            else
            {
                foreach (string i in val.packageNames)
                {
                    if (overview.GetPackageWithName(i) != null)
                    {
                        Update(overview.GetPackageWithName(i), val, overview);
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
