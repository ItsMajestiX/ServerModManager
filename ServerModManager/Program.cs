using System;
using System.Threading.Tasks;

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
                overview.GenPackages();
                //What command are we running?
                switch (validator.opType)
                {
                    case 0:
                        Installer installer = new Installer(validator, overview);
                        break;
                    case 1:
                        Remover remover = new Remover(validator, overview);
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