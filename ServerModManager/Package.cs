using System.Collections.Generic;

namespace ServerModManager
{
    class Package
    {
        //Properties will be carried over to json
        public string name;
        public string version;
        public List<string> dependencies;
        public string downloadLink;
        public string filename;
        public bool isDependency;

        //Testing constructor
        public Package(string name1, string version1, List<string> dependencies1, string downloadLink1)
        {
            name = name1;
            version = version1;
            dependencies = dependencies1;
            downloadLink = downloadLink1;
        }
    }
}
