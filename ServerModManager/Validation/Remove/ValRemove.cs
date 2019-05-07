using System;

using Pastel;
namespace ServerModManager.Validation
{
    partial class Validator
    {
        //Called on scpman remove
        private void ValRemove(string[] args, bool help, int len)
        {
            //Ensure we have arguments
            if (len < 2)
            {
                Console.WriteLine("ERROR: Usage scpman remove packagename".Pastel("ff0000"));
                opType = OP_TYPE.REMOVE_HELP;
            }
            else
            {
                if (!help)
                {
                    //Fill out details
                    if (args[1] == "*")
                    {
                        if (args.Length == 2)
                        {
                            removeAll = true;
                            opType = OP_TYPE.REMOVE;
                            success = true;
                        }
                        else
                        {
                            Console.WriteLine("ERROR: Usage scpman update *".Pastel("ff0000"));
                            opType = OP_TYPE.REMOVE_HELP;
                        }
                    }
                    else
                    {
                        foreach (string i in args[1..args.Length])
                        {
                            packageNames.Add(i);
                        }
                        opType = OP_TYPE.REMOVE;
                        success = true;
                    }
                }
                else
                {
                    opType = OP_TYPE.REMOVE_HELP;
                    success = true;
                }
            }
        }
    }
}
