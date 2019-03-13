using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToObject.Managers
{
    public class CityManager
    {

        private readonly List<string> cities = new List<string>()
        {
              "Кишинёв",
                "Киев",
                "Копенгаген",
                "Мумбаи",
                "Флорианополис",
                "Сиэтл",
                "Осло",
                "Тель-Авив",
                "Лиссабон",
                "Кали",
                "Окленд",
                "Стамбул",
                "Ханой",
                "Токио",
                "Тайбэй",
                "Рейкьявик",
                "Берлин",
                "Кейптаун",
                "Лондон",
                "Торонто",
        };

        public List<string> SearchCities(char startLetter, char endLetter)
        {
            var result = from c in cities where Char.ToUpper(c.ToArray().First()) == Char.ToUpper(startLetter)
                         && Char.ToUpper(c.ToArray().Last()) == Char.ToUpper(endLetter)
                         select c;

            return result.ToList();
        }

    }
}

//Console.Write("Please enter first letter of city :");
//            char startLetter = Console.ReadKey().KeyChar;

//Console.WriteLine();
//            Console.Write("Please enter last letter of city :");
//            char endLetter = Console.ReadKey().KeyChar;


//var cityManager = new CityManager();

//var cities = cityManager.SearchCities(startLetter, endLetter);

//            if (!cities.Any())
//            {
//                Console.WriteLine("Data not found");
//                Console.ReadKey();
//                return;
//            }

//            Console.WriteLine();
//            foreach (var city in cities)
//            {
//                Console.WriteLine(city);
//            }

//           Console.ReadKey();
