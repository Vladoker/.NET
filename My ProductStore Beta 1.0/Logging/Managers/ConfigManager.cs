using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Logging.Managers
{
    public class ConfigManager : IConfigManager
    {
        public bool KeyBoolean(bool value)
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                bool result = appSettings[value].ToString() ?? "Not Found";
                return value;
               
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error reading app settings");
            }
            return ConfigurationManager.AppSettings[value] != "true";
        }

        public int Keyint(int value)
        {
            try
            {
                int result;
                var appSettings = ConfigurationManager.AppSettings;
                return int.TryParse(, out result);

            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error reading app settings");
            }
            
        }

        public string KeyString(string value)
        {
            return ConfigurationManager.AppSettings[value] ?? "Not Found";
        }
    }
}
