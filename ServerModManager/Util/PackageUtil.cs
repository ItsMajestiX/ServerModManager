using System.IO;

using ServerModManager.PackageType;
namespace ServerModManager.Util
{
    class PackageUtil
    {
        public static bool DoesPackageExist(Package package) => File.Exists("../sm_plugins/" + package.downloadLocation);
        public static bool DoesDirectoryExist(Package package) => Directory.Exists(Path.GetDirectoryName("../sm_plugins/" + package.downloadLocation));
    }
}
