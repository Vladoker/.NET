using DataTypes.Entities;
using DataTypes.Interfaces.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTypes.Core.Managers
{
    public class ParentManager: IParentManager
    {
        public List<Parent> Parents { get; set; }

        public void AddParent(Parent parent)
        {
            Parents.Add(parent);
        }

        public void AddParents(List<Parent> parents)
        {
            Parents = parents;
        }

        //public List<Parent> Search(ParentFilter filter)

        public List<Parent> Search(int? age = null , string parentSex = null, string childSex = null)
        {
            var result = new List<Parent>();

            foreach (var item in Parents)
            {
                if (
                    (!age.HasValue || (age.HasValue && item.Age == age.Value))
                    &&
                    (string.IsNullOrEmpty(parentSex) //FALSE
                        ||
                        (
                        !string.IsNullOrEmpty(parentSex) //TRUE
                        &&
                        item.Sex.ToUpper() == parentSex.ToUpper()) //TRUE
                        )
                     )

                {
                    //Console.WriteLine($"Parent:{{ {item.FirstName},{item.LastName},{item.Age},{item.BithDate.ToString("dd.MM.yyyy")} }}");
                    //Console.WriteLine($"---------\n  Child:{{ {item.FirstName},{item.LastName},{item.Age},{item.BithDate.ToString("dd.MM.yyyy")} }}");
                    result.Add(item);
                }

            }

            return result;
        }

        public ParentManager()
        {
            Parents = new List<Parent>();
        }

        public void ToString(Parent parent)
        {
            Console.WriteLine($"Parent:{{ {parent.FirstName},{parent.LastName},{parent.Age},{parent.BithDate.ToString("dd.MM.yyyy")} }}");
            foreach (var item in parent.Children)
            {
                item.ShowC();
            }

        }
    }
}
