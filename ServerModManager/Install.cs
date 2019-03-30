using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace ServerModManager
{
    class Installer
    {
        //Exit code
        public int exit;

        private PackageOverview overview;

        //The main piece
        private async Task GetFile(Package package)
        {
            //Download dependencies first
            foreach (string i in package.dependencies)
            {
                await GetFile(overview.GetPackageWithName(i));
            }
            using (WebClient client = new WebClient())
            {
                //Download file to appropriate directory
                if (package.isDependency)
                {
                    await client.DownloadFileTaskAsync(package.downloadLink, "../sm_plugins/dependencies/" + package.filename);
                }
                else
                {
                    await client.DownloadFileTaskAsync(package.downloadLink, "../sm_plugins/" + package.filename);
                }
            }
        }

        public Installer(Validator val, PackageOverview overview)
        {
            //Makes it look nice
            this.overview = overview;
            Package info = overview.GetPackageWithName(val.packageName);
            if (info == null)
            {
                Console.WriteLine("ERROR: no package with name " + val.packageName);
            }
            else
            {
                Console.WriteLine("Downloading " + val.packageName);
                GetFile(info).Wait();
            }
        }
    }
}
