using System.Collections.Generic;

namespace ServerModManager.PackageType
{
    class Package
    {
        //Properties will be carried over to json
        public string name;
        public string author;
        public string version;
        public List<string> dependencies;
        public List<string> incompatibilities;
        public string downloadLink;
        public string downloadLocation;


        //Testing constructor
        public Package(string name, string author, string version, List<string> dependencies, List<string> incompatibilities, string downloadLink, string downloadLocation)
        {
            this.name = name;
            this.author = author;
            this.version = version;
            this.dependencies = dependencies;
            this.downloadLink = downloadLink;
            this.downloadLocation = downloadLocation;
            this.incompatibilities = incompatibilities;
        }
    }
}
