using System;
using System.IO;
using System.Linq;

namespace ServerModManager
{
    class Validator
    {
        //Make enum for easier time reading code
        public enum OP_TYPE
        {
            INVALID,
            MAIN_HELP = 0,
            INSTALL = 1,
            INSTALL_HELP = -1,
            REMOVE = 2,
            REMOVE_HELP = -2
        }

        //Define values that can be set by command
        public bool success = false;
        public OP_TYPE opType = OP_TYPE.INVALID;

        //Ensure plugin folders are found
        public bool pluginsExist = false;
        public bool dependenciesExist = false;

        public string packageName = null;

        public Validator(string[] args)
        {
            bool help = false;
            try
            {
                if (args.Last() == "help")
                {
                    help = true;
                }
            }
            catch (InvalidOperationException) 
            {
                help = true;
            }
            if (Directory.Exists("../sm_plugins"))
            {
                pluginsExist = true;
                if (Directory.Exists("../sm_plugins/dependencies"))
                {
                    dependenciesExist = true;
                }
            }
            //Check length of arguments
            int len = args.GetLength(0);
            if (len < 1)
            {
                Console.WriteLine("ERROR: Usage scpman command");
                opType = OP_TYPE.MAIN_HELP;
            }
            else
            {
                //Figure out which command we ran
                switch (args[0])
                {
                    case "help":
                        opType = OP_TYPE.MAIN_HELP;
                        break;
                    //scpman install
                    case "install":
                        //ensure we have a package name
                        if (len < 2)
                        {
                            Console.WriteLine("ERROR: Usage scpman install packagename");
                            opType = OP_TYPE.INSTALL_HELP;
                        }
                        else
                        {
                            //fill out details
                            if (!help)
                            {
                                opType = OP_TYPE.INSTALL;
                                packageName = args[1];
                                success = true;
                            }
                            else
                            {
                                opType = OP_TYPE.INSTALL_HELP;
                            }
                        }
                        break;
                    case "remove":
                        //ensure we have a package name
                        if (len < 2)
                        {
                            Console.WriteLine("ERROR: Usage scpman remove packagename");
                            opType = OP_TYPE.REMOVE_HELP;
                        }
                        else
                        {
                            if (!help)
                            {
                                //fill out details
                                opType = OP_TYPE.REMOVE;
                                packageName = args[1];
                                success = true;
                            }
                            else
                            {
                                opType = OP_TYPE.REMOVE_HELP;
                            }
                        }
                        break;
                    //invalid command
                    default:
                        Console.WriteLine("ERROR: Invalid command.");
                        opType = OP_TYPE.INVALID;
                        break;
                }
            }
        }
    }
}
