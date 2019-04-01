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
        public string downloadLink;
        public string filename;
        public bool isDependency;

        //Testing constructor
        public Package(string name, string author, string version, List<string> dependencies, string downloadLink, string filename, bool isDependency)
        {
            this.name = name;
            this.author = author;
            this.version = version;
            this.dependencies = dependencies;
            this.downloadLink = downloadLink;
            this.filename = filename;
            this.isDependency = isDependency;
        }
    }
}
