using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStore.Entities.Drinks
{
    public class Drinks
    {
        public ArrayList MasDrinks { get; set; }

        public String GetDrink(int index)
        {
            return MasDrinks[index].ToString();
        }

        public int Getsizeof()
        {
            return MasDrinks.Count;
        }



        public Drinks()
        {
            MasDrinks = new ArrayList();

            MasDrinks.Add("Кока-кола");
            MasDrinks.Add("Спрайт");
            MasDrinks.Add("Дорна");
            MasDrinks.Add("Гура");
            MasDrinks.Add("Пепси");
            MasDrinks.Add("ОМ");
            MasDrinks.Add("Вино");
            MasDrinks.Add("Шампанское");
            MasDrinks.Add("Пиво");
            MasDrinks.Add("Ром");
        }
    }
}
