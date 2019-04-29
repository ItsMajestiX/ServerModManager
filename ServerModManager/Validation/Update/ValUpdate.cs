using System;

//This is a nightmare, but it somehow works.
namespace ServerModManager.Validation
{
    partial class Validator
    {
        //Called on scpman update
        private void ValUpdate(string[] args, bool help, int len)
        {
            //Int return type is to offset where we look for other arguments
            int flag = UpdateFlags(args, len);
            if (flag == -1)
            {
                opType = OP_TYPE.UPDATE_HELP;
            }
            else
            {
                if (len < 2 + flag)
                {
                    Console.WriteLine("ERROR: Usage scpman update [-f] * \n scpman update [-f] package [package2, package3]");
                    opType = OP_TYPE.UPDATE_HELP;
                }
                else
                {
                    if (!help)
                    {
                        if (args[1 + flag] == "*")
                        {
                            if (args.Length == 2 + flag)
                            {
                                updateAll = true;
                                opType = OP_TYPE.UPDATE;
                                success = true;
                            }
                            else
                            {
                                Console.WriteLine("ERROR: Usage scpman update *");
                                opType = OP_TYPE.UPDATE_HELP;
                            }
                        }
                        else
                        {
                            foreach (string i in args[1 + flag..args.Length])
                            {
                                packageNames.Add(i);
                            }
                            opType = OP_TYPE.UPDATE;
                            success = true;
                        }
                    }
                    else
                    {
                        opType = OP_TYPE.UPDATE_HELP;
                        success = true;
                    }
                }
            }
        }
    }
}
