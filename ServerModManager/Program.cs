using System;

using Pastel;

using ServerModManager.PackageType;
using ServerModManager.Util;
using ServerModManager.Validation;
using ServerModManager.Commands;

namespace ServerModManager
{
    class Program
    {
        static void Main(string[] args)
        {
            string version = "0.3-alpha1";

            //Validate arguments passed to program
            Validator validator = new Validator(args);
            //Get the available packages
            if (validator.success)
            {
                PackageOverview overview = new PackageOverview();
                if (overview.GenPackages(version))
                {
                    //What command are we running?
                    switch (validator.opType)
                    {
                        case Validator.OP_TYPE.MAIN_HELP:
                            Help.MainHelp();
                            break;
                        case Validator.OP_TYPE.INSTALL:
                            Installer.InstallPackages(validator, overview);
                            break;
                        case Validator.OP_TYPE.INSTALL_HELP:
                            Help.InstallHelp();
                            break;
                        case Validator.OP_TYPE.REMOVE:
                            Remover.RemovePackages(validator, overview);
                            break;
                        case Validator.OP_TYPE.REMOVE_HELP:
                            Help.RemoveHelp();
                            break;
                        case Validator.OP_TYPE.UPDATE:
                            Updater.UpdatePackages(validator, overview);
                            break;
                        case Validator.OP_TYPE.UPDATE_HELP:
                            Help.UpdateHelp();
                            break;
                        case Validator.OP_TYPE.SERVER:
                            Server.CreateServer(validator);
                            break;
                        case Validator.OP_TYPE.SERVER_HELP:
                            Help.ServerHelp();
                            break;
                        default:
                            Console.WriteLine("Unknown error".Pastel("ff0000"));
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
                    case Validator.OP_TYPE.UPDATE_HELP:
                        Help.UpdateHelp();
                        break;
                    case Validator.OP_TYPE.SERVER_HELP:
                        Help.ServerHelp();
                        break;
                    default:
                        Console.WriteLine("Unknown error".Pastel("ff0000"));
                        break;
                }
            }
            #if (DEBUG)
                Console.ReadKey();
            #endif
        }
    }
}