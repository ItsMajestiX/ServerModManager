﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ServerModManager
{
    partial class Validator
    {
        private void ValRemove(string[] args, bool help, int len)
        {
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