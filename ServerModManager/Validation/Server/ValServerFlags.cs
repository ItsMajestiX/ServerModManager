//For future use
/*using System;
using System.Collections.Generic;
using System.Text;

namespace ServerModManager.Validation
{
    partial class Validator
    {
        private int ServerFlags(string[] args, int len)
        {
            bool invalid = false;
            //Check if there are flags. No, it wont crash, thanks to short circuting.
            if (len > 2 && args[1].StartsWith("-"))
            {
                //Start a list of chars used
                List<char> flags = new List<char> { };
                //Just like python, loop over a string
                foreach (char i in args[1][1..])
                {
                    //Stop if we have encountered a bad flag
                    if (!invalid)
                    {
                        //No duplicate flags
                        if (flags.Contains(i))
                        {
                            Console.WriteLine("ERROR: Invalid flag.");
                            invalid = true;
                        }
                        else
                        {
                            //What flag are we using?
                            switch (i)
                            {
                                case 'd':
                                    flags.Add('d');
                                    createDir = true;
                                    break;
                                default:
                                    Console.WriteLine("ERROR: Invalid flag.");
                                    invalid = true;
                                    break;
                            }
                        }
                    }
                }
                //If flags invalid return -1. Else, increment search by 1
                if (invalid)
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            }
            //If no flags, return 0
            else
            {
                return 0;
            }
        }
    }
}*/
