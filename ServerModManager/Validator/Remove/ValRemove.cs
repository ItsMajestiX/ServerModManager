using System;
using System.Collections.Generic;
using System.Text;

namespace ServerModManager
{
    partial class Validator
    {
        //Called on scpman remove
        private void ValRemove(string[] args, bool help, int len)
        {
            //Ensure we have arguments
            if (len < 2)
            {
                Console.WriteLine("ERROR: Usage scpman remove packagename");
                opType = OP_TYPE.REMOVE_HELP;
            }
            else
            {
                if (!help)
                {
                    //Fill out details
                    opType = OP_TYPE.REMOVE;
                    foreach (string i in args[1..args.Length])
                    {
                        packageNames.Add(i);
                    }
                    success = true;
                }
                else
                {
                    opType = OP_TYPE.REMOVE_HELP;
                }
            }
        }
    }
}
