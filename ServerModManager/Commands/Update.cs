using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace ServerModManager
{
    class Update
    {
        public static void update(Validator val, PackageOverview overview)
        {
            List<Package> pkgToUpdate = new List<Package> { };
            if (val.updateAll)
            {
                foreach (Package i in overview.packages)
                {
                    if (File.Exists("../sm_plugins/" + i.downloadLocation)) {
                        pkgToUpdate.Add(i);
                    }
                }
            }
            else
            {
                foreach (string i in val.packageNames)
                {
                    pkgToUpdate.Add(overview.GetPackageWithName(i));
                }
            }
            using (TmpDir dir = new TmpDir("."))
            using (WebClient client = new WebClient())
            {
                foreach (Package i in pkgToUpdate)
                {
                    if (File.Exists("../sm_plugins/" + i.downloadLocation))
                    {
                        string filename = Path.GetFileName(i.downloadLocation);
                        Console.WriteLine("Getting newest version of package " + i.name);
                        //Setup loading bar
                        client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(LoadingBar.DownloadProgressCallback);
                        //Get latest version
                        client.DownloadFileTaskAsync(i.downloadLink, dir.dirName + filename).Wait();
                        if (CompareFiles.compareFiles(dir.dirName + filename, "../sm_plugins/" + i.downloadLocation) && !val.forceUpdate)
                        {
                            Console.WriteLine(i.name + " is up to date.");
                        }
                        else
                        {
                            File.Move(dir.dirName + filename, "../sm_plugins/" + i.downloadLocation, true);
                            Console.WriteLine(i.name + " was updated.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("WARNING: Package " + i.name + " is not installed. Skipping.");
                    }
                }
            }
        }
    }
}
