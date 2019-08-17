using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Config;

namespace Logging
{
    public class Test1
    {
        private Logger logger;

        public Test1(Logger logger)
        {
            this.logger = logger;
        }

        public int Test()
        {
            logger.LogInfo("Start");

            int n = 2 + 2;

            logger.LogInfo(" Finish Рузультат сложения: " + n);

            return n;
        }
    }
}
