﻿using System;

namespace ServerModManager
{
    class Validator
    {
        //Make enum for easier time reading code
        public enum OP_TYPE
        {
            INVALID = -1,
            INSTALL = 0,
            REMOVE = 1
        }

        //Define values that can be set by command
        public bool success = false;
        public OP_TYPE opType;

        public string packageName;

        public Validator(string[] args)
        {
            //Check length of arguments
            int len = args.GetLength(0);
            if (len < 1)
            {
                Console.WriteLine("ERROR: Usage scpman command");
            }
            else
            {
                //Figure out which command we ran
                switch (args[0])
                {
                    //scpman install
                    case "install":
                        //ensure we have a package name
                        if (len < 2)
                        {
                            Console.WriteLine("ERROR: Usage scpman install packagename");
                            opType = OP_TYPE.INVALID;
                            break;
                        }
                        else
                        {
                            //fill out details
                            opType = OP_TYPE.INSTALL;
                            packageName = args[1];
                            success = true;
                            break;
                        }
                    case "remove":
                        //ensure we have a package name
                        if (len < 2)
                        {
                            Console.WriteLine("ERROR: Usage scpman remove packagename");
                            opType = OP_TYPE.INVALID;
                            break;
                        }
                        else
                        {
                            //fill out details
                            opType = OP_TYPE.REMOVE;
                            packageName = args[1];
                            success = true;
                            break;
                        }
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
