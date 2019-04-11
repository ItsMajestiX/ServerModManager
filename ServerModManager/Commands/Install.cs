using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace ServerModManager
{
    class Installer
    {
        private static async Task GetFile(Package package, PackageOverview overview, Validator val)
        {
            Console.WriteLine("Downloading " + package.name);
            //Download dependencies first
            foreach (string i in package.dependencies)
            {
                await GetFile(overview.GetPackageWithName(i), overview, val);
            }
            //Check if file already exists
            if (!File.Exists("../sm_plugins/" + package.downloadLocation)) 
            {
                using (WebClient client = new WebClient())
                {
                    //Setup loading bar
                    client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(LoadingBar.DownloadProgressCallback);
                    //Download file to directory after checking if the folders exist
                    if (Directory.Exists(Path.GetDirectoryName("../sm_plugins/" + package.downloadLocation)))
                    {
                        await client.DownloadFileTaskAsync(package.downloadLink, "../sm_plugins/" + package.downloadLocation);
                    }
                    else
                    {
                        Console.WriteLine("ERROR: The folder to install to does not exist. Did you unzip all the app files into a folder at the same level as sm_plugins?");
                    }
                }
            }
            else
            {
                Console.WriteLine("WARNING: Plugin " + package.name + " is already installed, skipping.");
            }
        }

        //This is the way commands should be set up. 1st func loops over packages and triggers 2nd for each. 1st is public, 2nd is private.
        public static void InstallPackages(Validator val, PackageOverview overview)
        {
            foreach (string i in val.packageNames)
            {
                //If it exists, install
                Package info = overview.GetPackageWithName(i);
                if (info != null)
                {
                    GetFile(info, overview, val).Wait();
                }
                else
                {
                    Console.WriteLine("ERROR: No package with name " + i);
                }
            }
        }
    }
}
