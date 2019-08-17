using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTypes
{
    public class Parent : Person, IParent
    {
        private List<Child> Children { get; set; }

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


        public List<Child> GetChildren()
        {
            return Children;
        }
        public void SetChildren(List<Child> children)
        {
            Children = children;
        }


        public void Show()
        {
            Console.WriteLine($"Parent:{{ {FirstName},{LastName},{Age},{BithDate.ToString("dd.MM.yyyy")} }}");
            foreach (var item in Children)
            {

                item.ShowC();
               
            }

        }

        

       

    }
}
