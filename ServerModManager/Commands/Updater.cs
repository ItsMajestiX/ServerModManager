using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace ServerModManager
{
    class Updater
    {
        public static void Update(Package package, Validator val)
        {
            using (TmpDir dir = new TmpDir("."))
            using (WebClient client = new WebClient())
            {
                if (File.Exists("../sm_plugins/" + package.downloadLocation))
                {
                    string filename = Path.GetFileName(package.downloadLocation);
                    Console.WriteLine("Getting newest version of package " + package.name);
                    //Setup loading bar
                    client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(LoadingBar.DownloadProgressCallback);
                    //Get latest version
                    client.DownloadFileTaskAsync(package.downloadLink, dir.dirName + filename).Wait();
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
                    Console.WriteLine("WARNING: Package " + package.name + " is not installed. Skipping.");
                }
            }
        }

        public static void UpdatePackages(Validator val, PackageOverview overview)
        {
            if (val.updateAll)
            {
                foreach (Package i in overview.packages)
                {
                    if (File.Exists("../sm_plugins/" + i.downloadLocation))
                    {
                        Update(i, val);
                    }
                }
            }
            else
            {
                foreach (string i in val.packageNames)
                {
                    if (overview.GetPackageWithName(i) != null)
                    {
                        Update(overview.GetPackageWithName(i), val);
                    }
                    else
                    {
                        Console.WriteLine("WARNING: No package with name " + i + ".");
                    }
                }
            }
        }
    }
}
