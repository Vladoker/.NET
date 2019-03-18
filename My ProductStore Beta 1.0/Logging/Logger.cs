using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Config;

namespace Logging
{
    public class Logger 
    {
        private ILog log;

        public Logger(ILog log)
        {
            XmlConfigurator.Configure();
            this.log = log;
        }

        public void LogInfo(string message)
        {
            log.Info(message);
        }

        public void LogError(string message)
        {
            log.Error(message);
        }

    }
}
