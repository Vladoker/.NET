using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Collections.Specialized;


namespace Logging.Managers
{
    public class ConfigManager : IConfigManager
    {
        public bool KeyBoolean(string value)
        {
            try
            {
                string result;

                // Read a particular key from the config file            
                result = ConfigurationManager.AppSettings.Get(value);

                if (result != null && result.Equals("true")) return true;
                else if(result != null && result.Equals("false"))return false;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: "+ ex);
                Console.ReadKey();
            }
            return false;
        }

        public int Keyint(string value)
        {
            try
            {
                int result;
                var appSettings = ConfigurationManager.AppSettings.Get(value);
                if (!int.TryParse(appSettings, out result))
                {
                    //обработка, если не число 
                    result = 0;
                }
                return result;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error :" + ex);
                Console.ReadKey();
            }
            return 0;
        }

        public string KeyString(string value)
        {
            string result = ConfigurationManager.AppSettings.Get(value);
            return result != null ? result : "key not found";
        }

        public void PrintAllKey()
        {
            // Read all the keys from the config file
            NameValueCollection sAll;
            sAll = ConfigurationManager.AppSettings;

            foreach (string s in sAll.AllKeys)
                Console.WriteLine("Key: " + s + " Value: " + sAll.Get(s));
            Console.ReadKey();
        }

    }
}
