using DataTypes.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTypes.Entities
{
    public class Parent : Person
    {
        public List<Child> Children { get; set; }

        public Parent()
        {
            Sex = "Unknow";
            Children = new List<Child>();
        }

        public Parent(string firstName, string lastName, string sex, List<Child> children)
        {
            FirstName = firstName;
            LastName = lastName;
            Sex = sex; 
            Children = children;
        }
    }
}
