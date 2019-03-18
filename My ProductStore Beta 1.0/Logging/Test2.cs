using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logging
{
    public static class Test2
    {
        public static readonly ILog log = LogManager.GetLogger(typeof(Test2));

        public static void Test()
        {
            try
            {
                //Специально вызываем ошибку для проверки
                Object d = null;
                d.ToString();
            }
            catch (Exception error)
            {
                log.Error(error.Message);
            }
        }

    }
}
