using ServerModManager.Validation;
using ServerModManager.Util;

using System;
using System.IO;
using System.IO.Compression;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;

using Pastel;

namespace ServerModManager.Commands
{
    class Server
    {
        public async static Task CreateServerWin()
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
            using (Process process = new Process())
            {
                process.StartInfo.CreateNoWindow = false;
                process.StartInfo.RedirectStandardError = false;
                process.StartInfo.RedirectStandardInput = false;
                process.StartInfo.RedirectStandardOutput = false;
                process.StartInfo.FileName = "../steamcmd/steamcmd.exe";
                process.StartInfo.Arguments = "+login anonymous +force_install_dir \"../\" +app_update 786920 -beta beta validate +quit";
                process.Start();
                process.WaitForExit();
            }
        }

        public static void CreateServer(Validator val)
        {
            //Determine windows or linux, and go from there
            OperatingSystem osInfo = Environment.OSVersion;
            if (osInfo.Platform == PlatformID.Win32NT)
            {
                CreateServerWin().Wait();
            }
            else
            {
                Console.WriteLine("ERROR: Only windows is supported at this time. For install instructions, please see https://github.com/Grover-c13/Smod2/wiki/ServerMod-Installation-(Linux)".Pastel("ff0000"));
            }
        }
    }
}
