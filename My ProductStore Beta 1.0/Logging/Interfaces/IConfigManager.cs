using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logging
{
    interface IConfigManager
    {

        bool KeyBoolean(string value);

        string KeyString(string value);

        int Keyint(string value);

    }
}
