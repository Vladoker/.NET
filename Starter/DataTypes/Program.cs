using DataTypes.Core.Managers;
using DataTypes.Entities;
using System;
using System.Collections.Generic;
//using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime D = new DateTime(1995, 01, 25);
            DateTime L = new DateTime(2017, 01, 6);

            Parent parent1 = new Parent { FirstName = "Владик", LastName = "Томащук", Age = 25, BithDate = D, Sex = "M" };
            Child child1 = new Child { FirstName = "Артём", LastName = "Томащук", Age = 2, BithDate = L, Sex = "M" };

            Parent parent2 = new Parent { FirstName = "Витя", LastName = "Усов", Age = 18, BithDate = D, Sex = "M" };
            Child child2 = new Child { FirstName = "Коля", LastName = "Усов", Age = 2, BithDate = L, Sex = "M" };

            Parent parent3 = new Parent { FirstName = "Славик", LastName = "Устюгов", Age = 23, BithDate = D, Sex = "M" };
            Child child3 = new Child { FirstName = "Мирча", LastName = "Устюгов", Age = 2, BithDate = L, Sex = "M" };

            Parent parent4 = new Parent { FirstName = "Антон", LastName = "Погребной", Age = 23, BithDate = D, Sex = "M" };
            Child child4 = new Child { FirstName = "Лена", LastName = "Погребная", Age = 2, BithDate = L, Sex = "L" };


            parent1.Children.Add(child1);
            parent2.Children.AddRange(new List<Child> { child2 });
            parent3.Children.AddRange(new List<Child> { child3 });
            parent4.Children.AddRange(new List<Child> { child4 });

            List<Parent> mas = new List<Parent> { parent1, parent2, parent3, parent4 };



              /*
               1. Create List of Parents with Children
               2. Add AddParent(Parent p) Method
               3. Add AddParents(List<Parent> ps) Method
               3. Add Search (Age, Sex) */

            ParentManager parentManager = new ParentManager();

            parentManager.AddParents(mas);//List
                                          //Ls.AddParents(parent1);// one Parent

            //Search(int? age = null
            //string parentSex = null,
            //string childSex = null)

            // parentManager.Search(ParentFilter{Age= 23, ParentSex="M", ChildSex= "F"})

            var parents = parentManager.Search(23,"M");

            //ShowerParents(parents);
            //ExporterParents.ToPdf(parents)

            parents.ForEach(x => parentManager.ToString(x));

            Console.ReadKey();
        }

        private static void Lesson1()
        {
            DateTime D = new DateTime(1995, 01, 25);
            DateTime L = new DateTime(1996, 03, 27);

            Parent x = new Parent { FirstName = "Peter", LastName = "Petrov", Age = 25, BithDate = D, Sex = "M" };

            Child child = new Child { FirstName = "Vasea", LastName = "Sidorov", Age = 20, BithDate = L, Sex = "M" };
            var child2 = new Child { FirstName = "V1", LastName = "V1", Age = 30, BithDate = L, Sex = "M" };

            //x.SetChildren(new List<Child> { child, child2 });


            //4. Display Parent details (FirstName, LastName, List of Children)

            //x.Show();//выводит родителя и потомков
                     //child2.ShowC();
        }
    }

}
