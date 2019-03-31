using System;
using System.Net;
using System.Threading.Tasks;

namespace ServerModManager
{
    class Installer
    {
        //The main piece
        static async Task getFile(Package package, PackageOverview overview)
        {
            //Download dependencies first
            foreach (string i in package.dependencies)
            {
                await getFile(overview.GetPackageWithName(i), overview);
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

        internal static void install(Validator val, PackageOverview overview)
        {
            //Makes it look nice
            Package info = overview.GetPackageWithName(val.packageName);
            if (info == null)
            {
                Console.WriteLine("ERROR: no package with name " + val.packageName);
            }
            else
            {
                Console.WriteLine("Downloading " + val.packageName);
                getFile(info, overview).Wait();
            }
        }

        public Installer() { }
    }
}
