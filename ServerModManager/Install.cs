using System;
using System.Net;
using System.Threading.Tasks;

namespace ServerModManager
{
    class Installer
    {
        //The main piece
        static async Task GetFile(Package package, PackageOverview overview, Validator val)
        {
            Console.WriteLine("Downloading " + val.packageName);
            //Download dependencies first
            foreach (string i in package.dependencies)
            {
                await GetFile(overview.GetPackageWithName(i), overview, val);
            }
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

        internal static void install(Validator val, PackageOverview overview)
        {
            //Makes it look nice
            Package info = overview.GetPackageWithName(val.packageName);
            if (info != null)
            {
                GetFile(info, overview, val).Wait();
            }
            else
            {
                Console.WriteLine("ERROR: No package with name " + val.packageName);
            }
        }

        public Installer() { }
    }
}
