using System;

namespace ServerModManager
{
    class Validator
    {
        public bool success = true;
        public int opType;
        public string packageName;

        public Validator(string[] args)
        {
            //Check length of arguments
            int len = args.GetLength(0);
            if (len < 1)
            {
                Console.WriteLine("ERROR: Usage scpman command");
                success = false;
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
                            success = false;
                            break;
                        }
                        else
                        {
                            //fill out details
                            opType = 0;
                            packageName = args[1];
                            break;
                        }
                    case "remove":
                        //ensure we have a package name
                        if (len < 2)
                        {
                            Console.WriteLine("ERROR: Usage scpman remove packagename");
                            success = false;
                            break;
                        }
                        else
                        {
                            //fill out details
                            opType = 1;
                            packageName = args[1];
                            break;
                        }
                    //invalid command
                    default:
                        Console.WriteLine("ERROR: Invalid command.");
                        success = false;
                        break;
                }
            }
        }
    }
}
