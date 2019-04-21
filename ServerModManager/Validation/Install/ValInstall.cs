using System;

namespace ServerModManager.Validation
{
    partial class Validator
    {
        //Called on scpman install
        private void ValInstall(string[] args, bool help, int len)
        {
            int flag = InstallFlags(args, len);
            //ensure we have a package name
            if (len < 2 + flag)
            {
                //Always display usage if used incorrectly
                Console.WriteLine("ERROR: Usage scpman install [-d] packagename");
                opType = OP_TYPE.INSTALL_HELP;
            }
            else
            {
                //fill out details
                if (!help)
                {
                    opType = OP_TYPE.INSTALL;
                    foreach (string i in args[1 + flag..len])
                    {
                        packageNames.Add(i);
                    }
                    success = true;
                }
                else
                {
                    opType = OP_TYPE.INSTALL_HELP;
                }
            }
        }
    }
}
