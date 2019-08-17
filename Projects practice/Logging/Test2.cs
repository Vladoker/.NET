using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logging
{
    public class Test2
    {
        private Logger logger;

        public Test2(Logger logger)
        {
            this.logger = logger;
        }

        public void Test()
        {         
            try
            {
                logger.LogInfo("Start Test2");
                //Специально вызываем ошибку для проверки
                Object d = null;
                d.ToString();
            }
            catch (Exception error)
            {
                logger.LogError(error.ToString());
            }
        }

    }
}
