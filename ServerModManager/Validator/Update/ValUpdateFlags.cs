using System;
using System.Collections.Generic;
using System.Text;

namespace ServerModManager
{
    partial class Validator
    {
        private int UpdateFlags(string[] args, int len)
        {
            bool invalid = false;
            if (len > 2 && args[1].StartsWith("-"))
            {
                List<char> flags = new List<char> { };
                foreach (char i in args[1][1..])
                {
                    if (!invalid)
                    {
                        if (flags.Contains(i))
                        {
                            Console.WriteLine("ERROR: Invalid flag.");
                            invalid = true;
                        }
                        else
                        {
                            switch (i)
                            {
                                case 'f':
                                    flags.Add('f');
                                    forceUpdate = true;
                                    break;
                                default:
                                    Console.WriteLine("ERROR: Invalid flag.");
                                    invalid = true;
                                    break;
                            }
                        }
                    }
                }
                if(invalid)
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            }
            else
            {
                return 0;
            }
        }
    }
}
