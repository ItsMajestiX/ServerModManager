using System;
using System.IO;
using System.IO.Compression;

using ServerModManager.Validation;
using ServerModManager.Util;
using System.Net;

namespace ServerModManager.Commands
{
    class Server
    {
        public async static void CreateServerWin(Validator val)
        {
            if (!File.Exists("../steamcmd/steamcmd.exe"))
            {
                if (!Directory.Exists("../steamcmd/"))
                {
                    Directory.CreateDirectory("../steamcmd");
                }
                else
                {
                    TmpDir.CleanDirRecursive("../steamcmd/");
                }
                Console.WriteLine("Downloading steamcmd");
                using (TmpDir dir = new TmpDir("."))
                {
                    using (WebClient client = new WebClient())
                    {
                        client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(LoadingBar.DownloadProgressCallback);
                        await client.DownloadFileTaskAsync("https://steamcdn-a.akamaihd.net/client/installer/steamcmd.zip", dir.dirName + "steamcmd.zip");
                    }
                    ZipFile.ExtractToDirectory(dir.dirName + "steamcmd.zip", "../steamcmd/");
                }
            }
        }
        public static void CreateServer(Validator val)
        {
            if (val.os == Validator.OS_TYPE.WINDOWS)
            {

            }
        }
    }
}
