using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTypes
{
    public class ListParent
    {

        public List<Parent> ListP { get; set; }

        public void AddParents(Parent ps)
        {
            ListP.Add(ps);
        }

        public void AddParents(List<Parent> ps)
        {
            ListP = ps;
        }

        public void Search(int age, String sex)
        {
            foreach (var item in ListP)
            {
                if (item.Age == age && item.Sex.ToUpper() == sex.ToUpper())
                {
                    //Console.WriteLine($"Parent:{{ {item.FirstName},{item.LastName},{item.Age},{item.BithDate.ToString("dd.MM.yyyy")} }}");
                    //Console.WriteLine($"---------\n  Child:{{ {item.FirstName},{item.LastName},{item.Age},{item.BithDate.ToString("dd.MM.yyyy")} }}");
                    item.Show();
                }

            }

        }

        public ListParent()
        {
            ListP = new List<Parent>();
        }

    }
}
