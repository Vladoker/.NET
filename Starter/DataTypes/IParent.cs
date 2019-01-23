using DataTypes.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTypes.Interfaces
{
    public interface IParent
    {
        List<Child> GetChildren();
        void SetChildren(List<Child> children);
    }
}
