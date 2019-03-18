using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Config;
using System.Configuration;

namespace Logging
{
    class Program
    {
        static void Main(string[] args)
        {

            var logger = new Logger(LogManager.GetLogger("PSLogger"));


            Test1 test = new Test1(logger);
            Test2 TestEror = new Test2(logger);

            test.Test();
            TestEror.Test();




            Console.ReadKey();
        }
    }
}
