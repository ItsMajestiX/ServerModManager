﻿using System;

using Pastel;

namespace ServerModManager.Validation
{
    partial class Validator
    {
        private void ValServer(string[] args, bool help, int len)
        {
            if (len != 1)
            {
                //Always display usage if used incorrectly
                Console.WriteLine("ERROR: Usage scpman server".Pastel("ff0000"));
                opType = OP_TYPE.SERVER_HELP;
            }
            else
            {
                //fill out details
                if (!help)
                {
                    opType = OP_TYPE.SERVER;
                    success = true;
                }
                else
                {
                    opType = OP_TYPE.SERVER_HELP;
                    success = true;
                }
            }
        }
    }
}
