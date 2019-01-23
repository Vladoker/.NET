using DataTypes.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTypes.Interfaces.Managers
{
    public interface IParentManager
    {
        /// <summary>
        /// Find Parent objects by filter
        /// </summary>
        /// <param name="age"></param>
        /// <param name="parentSex"></param>
        /// <param name="childSex"></param>
        /// <returns></returns>
        List<Parent> Search(int? age = null, string parentSex = null, string childSex = null);
    }
}
