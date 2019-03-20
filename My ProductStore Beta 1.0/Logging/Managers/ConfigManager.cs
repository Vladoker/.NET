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
        public List<string> GetStringList(string value, char separator)
        {
            var result = new List<string>();

           string countriesString = ConfigurationManager.AppSettings.Get(value);

            var countries = countriesString.Split(separator);

            foreach (var country in countries)
            {
                result.Add(country.Trim()); //Trim() удаляет лишнии пробелы
            }

            return result;
        }

        public bool KeyBoolean(string value)
        {
            // Solution 1: 
            bool result = false;

            bool.TryParse(ConfigurationManager.AppSettings.Get(value), out result);

            return result;

            // Solution 2: 
            //return ConfigurationManager.AppSettings.Get(value) == "true";
        }

        public int Keyint(string value)
        {
            int result = 0;
            var keyValue = ConfigurationManager.AppSettings.Get(value);

            int.TryParse(keyValue, out result);
            return result;

        }

        public string KeyString(string value)
        {
            return ConfigurationManager.AppSettings.Get(value);
        }

       
    }
}
