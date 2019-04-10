﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ServerModManager
{
    class TmpDir : IDisposable
    {
        public string dirName;

        private Random random;

        public void Dispose()
        {
            CleanDirRecursive(dirName);
            Directory.Delete(dirName);
        }

        private void CleanDirRecursive(string root)
        {
            foreach (string i in Directory.EnumerateFiles(root))
            {
                File.Delete(i);
            }
            foreach (string i in Directory.EnumerateDirectories(root))
            {
                if (Directory.EnumerateFiles(root + i).Count() + Directory.EnumerateDirectories(root + i).Count() > 0)
                {
                    CleanDirRecursive(root + i);
                }
                Directory.Delete(root + i);
            }
        }

        //This code from https://stackoverflow.com/questions/1344221/how-can-i-generate-random-alphanumeric-strings
        private string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public TmpDir(string path)
        {
            random = new Random();
            dirName = "tmp_" + RandomString(8) + "/";
            Directory.CreateDirectory(dirName);
        } 
    }
}