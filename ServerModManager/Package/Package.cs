using System.Collections.Generic;

namespace ServerModManager
{
    class Package
    {
        //Properties will be carried over to json
        public string name;
        public string author;
        public string version;
        public List<string> dependencies;
        //Soon, but not yet
        //public List<string> incompatibilities;
        public string downloadLink;
        public string downloadLocation;

        //Testing constructor
        public Package(string name, string author, string version, List<string> dependencies, string downloadLink, string downloadLocation)
        {
            this.name = name;
            this.author = author;
            this.version = version;
            this.dependencies = dependencies;
            this.downloadLink = downloadLink;
            this.downloadLocation = downloadLocation;
            //Soon
            //this.incompatibilities = incompatibilities;
        }
    }
}
