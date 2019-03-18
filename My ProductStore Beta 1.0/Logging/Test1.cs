using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Config;

namespace Logging
{
    public static class Test1
    {
        public static readonly ILog log = LogManager.GetLogger(typeof(Test1));

        public static void Test()
        {
            log.Info("Start");

            int n = 2 + 2;

            log.Info(" Finish Рузультат сложения: " + n);
        }
    }
}
