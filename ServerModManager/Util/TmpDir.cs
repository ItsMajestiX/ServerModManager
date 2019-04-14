using System;
using System.IO;
using System.Linq;

//Fun fact: I must have been high or somthing when I made this. It used to be named FileCompare.cs . ??????? That goes to the class that actually compares files.
namespace ServerModManager
{
    //Basically a folder that can be put in a using statment that is deleted when done, just like unix mktmp but cross platform.
    class TmpDir : IDisposable
    {
        public string dirName;

        private Random random;

        //When done, remove files and dir.
        public void Dispose()
        {
            CleanDirRecursive(dirName);
            Directory.Delete(dirName);
        }

        //Basic recursive file remover.
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

        //Create the folder
        public TmpDir(string path)
        {
            random = new Random();
            dirName = "tmp." + RandomString(8) + "/";
            Directory.CreateDirectory(dirName);
        } 
    }
}
