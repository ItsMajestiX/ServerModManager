using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ServerModManager
{
    class LoadingBar
    {
        public LoadingBar() { }

        //Copied straight from the .NET docs
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
        //Buggy at the moment, sometimes is run before the loading bar
        //public void DownloadFinishedCallback(object sender, DownloadStringCompletedEventArgs e)
        //{
        //    Console.WriteLine("Done.");
        //}
    }
}
