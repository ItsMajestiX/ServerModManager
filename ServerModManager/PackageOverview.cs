using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
            using (HttpClient client = new HttpClient())
            {
                Task<string> json;
                try
                {
                    #if (DEBUG)
                        json = client.GetStringAsync("http://127.0.0.1:8000/packages.json");
                    #else
                        json = client.GetStringAsync("https://raw.githubusercontent.com/ItsMajestiX/ServerModManager/master/packages.json");
                    #endif
                }
                catch (Exception)
                {
                    Console.WriteLine("Error getting the packages from the server. Check your internet connection.");
                    return false;
                }
                string data = await json;
                try
                {
                    packages = JsonConvert.DeserializeObject<PackageOverview>(data).packages;
                    return true;
                }
                catch (Exception)
                {
                    Console.WriteLine("ERROR: JSON Serialization Failed. You most likely need to update the program at https://github.com/ItsMajestiX/ServerModManager/releases");
                    return false;
                }
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
            return GetPackages().Result;
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
