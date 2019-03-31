using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ServerModManager
{
    //This excelent code from https://stackoverflow.com/users/54026/daniel-ballinger
    internal class ConsoleSpiner
    {
        int counter;
        public ConsoleSpiner()
        {
            counter = 0;
        }
        public void Turn()
        {
            counter++;
            switch (counter % 4)
            {
                case 0: Console.Write("/"); break;
                case 1: Console.Write("-"); break;
                case 2: Console.Write("\\"); break;
                case 3: Console.Write("|"); break;
            }
            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
        }
    }

    class LoadingBar
    {
        public LoadingBar()
        {
        }
        public void DownloadProgressCallback(object sender, DownloadProgressChangedEventArgs e)
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
        //public void DownloadFinishedCallback(object sender, DownloadStringCompletedEventArgs e)
        //{
        //    Console.WriteLine("Done.");
        //}
    }
}
