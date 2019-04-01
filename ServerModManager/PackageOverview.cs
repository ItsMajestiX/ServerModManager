using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace ServerModManager
{
    class PackageOverview
    {
        public List<Package> packages;

        //Download from server
        private async Task<bool> GetPackages()
        {
            using (WebClient client = new WebClient())
            {
                //Get the loading bar ready
                client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(LoadingBar.DownloadProgressCallback);
                Task<string> json;
                //Get repository from appropriate place
                #if (DEBUG)
                    json = client.DownloadStringTaskAsync("http://127.0.0.1:8000/packages.json");
                #else
                    json = client.DownloadStringTaskAsync("https://raw.githubusercontent.com/ItsMajestiX/ServerModManager/master/packages.json");
                #endif
                //Serialize to object
                string data = await json;
                packages = JsonConvert.DeserializeObject<PackageOverview>(data).packages;
                return true;
            }
        }

        //Helper function
        public Package GetPackageWithName(string name)
        {
            foreach (Package i in packages)
            {
                if (i.name == name)
                {
                    return i;
                }
            }
            return null;
        }
        //So the main method doesn't have to use async
        public bool GenPackages()
        {
            //Catch common exceptions
            try
            {
                return GetPackages().Result;
            }
            catch (AggregateException e)
            {
                if (e.InnerExceptions[0] is HttpRequestException)
                {
                    Console.WriteLine("ERROR: Error getting the packages from the server. Check your internet connection.");
                    return false;
                }
                else
                {
                    throw e;
                }
            }
        }

        //Testing constructor
        public PackageOverview(List<Package> packages1)
        {
            packages = packages1;
        }

        //Default Constructor
        public PackageOverview() {}
    }
}
