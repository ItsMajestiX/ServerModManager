﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

using Pastel;
using Newtonsoft.Json;

using ServerModManager.Util;

namespace ServerModManager.PackageType
{
    class PackageOverview
    {
        public List<Package> packages;

        //Download from server
        private async Task<bool> GetPackages(string ver)
        {
            using (WebClient client = new WebClient())
            {
                //Get the loading bar ready
                client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(LoadingBar.DownloadProgressCallback);
                Task<string> location;
                //Get repository from appropriate place
                #if (DEBUG)
                    location = client.DownloadStringTaskAsync("http://127.0.0.1:8000/versions.json");
                    await location;
                    Console.Write("\n\r");
                #else
                    location = client.DownloadStringTaskAsync("https://raw.githubusercontent.com/ItsMajestiX/ServerModManager/master/versions.json");
                    await location;
                    Console.Write("\n\r");
                #endif
                //Serialize to object
                Dictionary<string, string> locationDict = JsonConvert.DeserializeObject<Dictionary<string, string>>(await location);
                string fileLocation = locationDict[ver];
                Task<string> json;
                //Get repository from appropriate place
                #if (DEBUG)
                    json = client.DownloadStringTaskAsync("http://127.0.0.1:8000/" + fileLocation);
                    await json;
                    Console.Write("\n\r");
                #else
                    json = client.DownloadStringTaskAsync("https://raw.githubusercontent.com/ItsMajestiX/ServerModManager/master/" + fileLocation);
                    await json;
                    Console.Write("\n\r");
                #endif
                //Serialize to object
                packages = JsonConvert.DeserializeObject<PackageOverview>(await json).packages;
                return true;
            }
        }

        //Helper functions
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

        //So the main method doesn't have to use async and to catch errors.
        public bool GenPackages(string ver)
        {
            //Catch common exceptions
            try
            {
                Console.WriteLine("Downloading package list.");
                return GetPackages(ver).Result;
            }
            catch (AggregateException e)
            {
                if (e.InnerExceptions[0] is WebException)
                {
                    Console.WriteLine("ERROR: Error getting the packages from the server. Check your internet connection.".Pastel("ff0000"));
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
