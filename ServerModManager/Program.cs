using System;

namespace ServerModManager
{
    class Program
    {
        static void Main(string[] args)
        {
            //Validate arguments passed to program
            Validator validator = new Validator(args);
            //Get the available packages
            if (validator.success)
            {
                PackageOverview overview = new PackageOverview();
                if (overview.GenPackages())
                {
                    //What command are we running?
                    switch (validator.opType)
                    {
                        case Validator.OP_TYPE.MAIN_HELP:
                            Help.MainHelp();
                            break;
                        case Validator.OP_TYPE.INSTALL:
                            Installer.install(validator, overview);
                            break;
                        case Validator.OP_TYPE.INSTALL_HELP:
                            Help.InstallHelp();
                            break;
                        case Validator.OP_TYPE.REMOVE:
                            Remover.remove(validator, overview);
                            break;
                        case Validator.OP_TYPE.REMOVE_HELP:
                            Help.RemoveHelp();
                            break;
                        default:
                            Console.WriteLine("Unknown error");
                            break;
                    }
                }
            }
            //In case we need to display help
            else
            {
                switch (validator.opType)
                {
                    case Validator.OP_TYPE.MAIN_HELP:
                        Help.MainHelp();
                        break;
                    case Validator.OP_TYPE.INSTALL_HELP:
                        Help.InstallHelp();
                        break;
                    case Validator.OP_TYPE.REMOVE_HELP:
                        Help.RemoveHelp();
                        break;
                    default:
                        Console.WriteLine("Unknown error");
                        break;
                }
            }
            #if (DEBUG)
                Console.ReadKey();
            #endif
        }
    }
}