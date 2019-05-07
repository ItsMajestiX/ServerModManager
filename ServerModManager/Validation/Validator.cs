using System;
using System.Linq;

using Pastel;

//Abandon hope to all ye who dare to enter.
//Must have made this at the same time I made TmpDir.cs
namespace ServerModManager.Validation
{
    [Serializable]
    partial class Validator
    {
        public Validator(string[] args)
        {
            //Does the user want help?
            bool help = false;
            try
            {
                if (args.Last() == "help")
                {
                    help = true;
                }
            }
            //In case the user runs scpman by itself
            catch (InvalidOperationException) 
            {
                help = true;
            }
            //Check if directories exist so we don't get errors
            //Depreciated
            //if (Directory.Exists("../sm_plugins"))
            //{
            //    pluginsExist = true;
            //    if (Directory.Exists("../sm_plugins/dependencies"))
            //    {
            //        dependenciesExist = true;
            //    }
            //}
            //Check length of arguments
            int len = args.GetLength(0);
            if (len < 1)
            {
                Console.WriteLine("ERROR: Usage scpman command".Pastel("ff0000"));
                opType = OP_TYPE.MAIN_HELP;
            }
            else
            {
                //Figure out which command we ran
                switch (args[0])
                {
                    //scpman help
                    case "help":
                        opType = OP_TYPE.MAIN_HELP;
                        break;
                    //scpman install
                    case "install":
                        ValInstall(args, help, len);
                        break;
                    case "remove":
                        //ensure we have a package name
                        ValRemove(args, help, len);
                        break;
                    case "update":
                        ValUpdate(args, help, len);
                        break;
                    case "server":
                        ValServer(args, help, len);
                        break;
                    //invalid command
                    default:
                        Console.WriteLine("ERROR: Invalid command.".Pastel("ff0000"));
                        opType = OP_TYPE.INVALID;
                        break;
                }
            }
        }
    }
}
