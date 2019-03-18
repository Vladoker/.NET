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
            log4net.Config.XmlConfigurator.Configure();

            string productStorePathXml = ConfigurationManager.AppSettings["Test1"];

            Test1.Test();

            Console.ReadKey();
        }
    }
}
