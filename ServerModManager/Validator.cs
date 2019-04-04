using System;
using System.Collections.Generic;
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

        //For commands that need a package name
        public List<string> packageNames =  new List<string> { };

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
                    //scpman help
                    case "help":
                        opType = OP_TYPE.MAIN_HELP;
                        break;
                    //scpman install
                    case "install":
                        //ensure we have a package name
                        if (len < 2)
                        {
                            //Always display usage if used incorrectly
                            Console.WriteLine("ERROR: Usage scpman install packagename");
                            opType = OP_TYPE.INSTALL_HELP;
                        }
                        else
                        {
                            //fill out details
                            if (!help)
                            {
                                opType = OP_TYPE.INSTALL;
                                foreach (string i in args[1..args.Length])
                                {
                                    packageName.Add(i);
                                }
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
                                foreach (string i in args[1..args.Length])
                                {
                                    packageName.Add(i);
                                }
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
