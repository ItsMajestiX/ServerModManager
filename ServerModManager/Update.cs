﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace ServerModManager
{
    class Update
    {
        //This code from https://support.microsoft.com/en-us/help/320348/how-to-create-a-file-compare-function-in-visual-c
        private static bool fileCompare(string file1, string file2)
        {
            int file1byte;
            int file2byte;
            FileStream fs1;
            FileStream fs2;

            // Determine if the same file was referenced two times.
            if (file1 == file2)
            {
                // Return true to indicate that the files are the same.
                return true;
            }

            // Open the two files.
            fs1 = new FileStream(file1, FileMode.Open);
            fs2 = new FileStream(file2, FileMode.Open);

            // Check the file sizes. If they are not the same, the files 
            // are not the same.
            if (fs1.Length != fs2.Length)
            {
                // Close the file
                fs1.Close();
                fs2.Close();

                // Return false to indicate files are different
                return false;
            }

            // Read and compare a byte from each file until either a
            // non-matching set of bytes is found or until the end of
            // file1 is reached.
            do
            {
                // Read one byte from each file.
                file1byte = fs1.ReadByte();
                file2byte = fs2.ReadByte();
            }
            while ((file1byte == file2byte) && (file1byte != -1));

            // Close the files.
            fs1.Close();
            fs2.Close();

            // Return the success of the comparison. "file1byte" is 
            // equal to "file2byte" at this point only if the files are 
            // the same.
            return ((file1byte - file2byte) == 0);
        }

        public static void update(Validator val, PackageOverview overview)
        {
            List<Package> pkgToUpdate = new List<Package> { };
            if (val.updateAll)
            {
                foreach (Package i in overview.packages)
                {
                    if (File.Exists("../sm_plugins/" + i.downloadLocation)) {
                        pkgToUpdate.Add(i);
                    }
                }
            }
            else
            {
                foreach (string i in val.packageNames)
                {
                    pkgToUpdate.Add(overview.GetPackageWithName(i));
                }
            }
            using (TmpDir dir = new TmpDir("."))
            using (WebClient client = new WebClient())
            {
                foreach (Package i in pkgToUpdate)
                {
                    if (File.Exists("../sm_plugins/" + i.downloadLocation))
                    {
                        string filename = Path.GetFileName(i.downloadLocation);
                        Console.WriteLine("Getting newest version of package " + i.name);
                        //Setup loading bar
                        client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(LoadingBar.DownloadProgressCallback);
                        //Get latest version
                        client.DownloadFileTaskAsync(i.downloadLink, dir.dirName + filename).Wait();
                        if (fileCompare(dir.dirName + filename, "../sm_plugins/" + i.downloadLocation))
                        {
                            Console.WriteLine(i.name + " is up to date.");
                        }
                        else
                        {
                            File.Move(dir.dirName + filename, "../sm_plugins/" + i.downloadLocation, true);
                            Console.WriteLine(i.name + " was updated.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("WARNING: Package " + i.name + " is not installed. Skipping.");
                    }
                }
            }
        }
    }
}