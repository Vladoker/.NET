using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Config;
using System.Configuration;
using Logging.Managers;

namespace Logging
{
    class Program
    {
        static void Main(string[] args)
        {

            //var logger = new Logger(LogManager.GetLogger("PSLogger"));


            //Test1 test = new Test1(logger);
            //Test2 TestEror = new Test2(logger);

            //test.Test();
            //TestEror.Test();


            ////////////////////////////////////////////////////////////////////////////

            ConfigManager manager = new ConfigManager();
   
            Console.WriteLine(manager.KeyBoolean("KeyBoolean") + "\n");
            Console.WriteLine(manager.Keyint("KeyInteger") + "\n");
            Console.WriteLine(manager.KeyString("keyString") + "\nall Keys from App\n");

            manager.PrintAllKey();






            Console.ReadKey();
        }
    }
}
