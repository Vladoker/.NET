using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logging
{
    /// <summary>
    /// 
    /// </summary>
    interface IConfigManager
    {
        /// <summary>
        /// KeyBoolean
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        bool KeyBoolean(string value);

        /// <summary>
        /// KeyString
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        string KeyString(string value);

        /// <summary>
        /// Keyint
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        int Keyint(string value);

        List<string> GetStringList(string value, char separator);

    }
}
