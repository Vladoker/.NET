using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTypes.Entities
{
    public class Child:Person
    {
        Parent Parent { get; set; }

        public void ShowC()
        {
            Console.WriteLine($"\n----------   Child:{{ {FirstName},{LastName},{Age},{BithDate.ToString("dd.MM.yyyy")} }}");
        }


    }

   
}
