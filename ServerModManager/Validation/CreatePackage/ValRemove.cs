using System;

using Pastel;
namespace ServerModManager.Validation
{
    partial class Validator
    {
        //Called on scpman remove
        private void ValCreatePackage(string[] args, bool help, int len)
        {
            //Ensure we have arguments
            if (len != 1)
            {
                Console.WriteLine("ERROR: Usage scpman createpackage".Pastel("ff0000"));
                opType = OP_TYPE.CREATEPACKAGE_HELP;
            }
            else
            {
                if (!help)
                {
                    opType = OP_TYPE.CREATEPACKAGE;
                    success = true;
                }
                else
                {
                    opType = OP_TYPE.CREATEPACKAGE_HELP;
                    success = true;
                }
            }
        }
    }
}
