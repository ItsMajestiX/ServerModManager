using Newtonsoft.Json;
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
        private async Task GetPackages()
        {
            using (HttpClient client = new HttpClient())
            {
                var json = client.GetStringAsync("http://127.0.0.1:8000/packages.json");
                string data = await json;
                packages = JsonConvert.DeserializeObject<PackageOverview>(data).packages;
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
        public void GenPackages()
        {
            GetPackages().Wait();
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
