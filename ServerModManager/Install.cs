using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace ServerModManager
{
    class Installer
    {
        //The main piece
        static async Task GetFile(Package package, PackageOverview overview, Validator val)
        {
            Console.WriteLine("Downloading " + package.name);
            //Download dependencies first
            foreach (string i in package.dependencies)
            {
                await GetFile(overview.GetPackageWithName(i), overview, val);
            }
            if (!File.Exists("../sm_plugins/" + package.downloadLocation)) 
            {
                using (WebClient client = new WebClient())
                {
                    //Setup loading bar
                    client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(LoadingBar.DownloadProgressCallback);
                    //Download file to directory after checking if the folders exist
                    if (val.pluginsExist && val.dependenciesExist)
                    {
                        await client.DownloadFileTaskAsync(package.downloadLink, "../sm_plugins/" + package.downloadLocation);
                    }
                    else
                    {
                        Console.WriteLine("ERROR: sm_plugins and/or dependencies could not be found. Did you unzip all the app files into a folder at the same level as sm_plugins?");
                    }
                }
            }
            else
            {
                Console.WriteLine("WARNING: Plugin " + package.name + " is already installed, skipping.");
            }
        }

        internal static void install(Validator val, PackageOverview overview)
        {
            foreach (string i in val.packageNames)
            {
                //Makes it look nice
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

        public Installer() { }
    }
}
