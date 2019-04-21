using System;
using System.Net;

namespace ServerModManager.Util
{
    class LoadingBar
    {
        public LoadingBar() { }

        //Copied straight from the .NET docs: https://docs.microsoft.com/en-us/dotnet/api/system.net.webclient.downloadprogresschanged
        public static void DownloadProgressCallback(object sender, DownloadProgressChangedEventArgs e)
        {
            // Displays the operation identifier, and the transfer progress.
            Console.Write("\rDownloaded {0} of {1} bytes. {2} % complete... ",
                e.BytesReceived,
                e.TotalBytesToReceive,
                e.ProgressPercentage);
            if (e.ProgressPercentage == 100)
            {
                Console.Write("\n");
            }
        }
        //Buggy at the moment, sometimes is run before the loading bar. Well, I guess the other one is no better, but we need that.
        //public void DownloadFinishedCallback(object sender, DownloadStringCompletedEventArgs e)
        //{
        //    Console.WriteLine("Done.");
        //}
    }
}
