using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStore.Entities.Food
{
    public class Food
    {
         public ArrayList MasFood { get; set; }

        public String GetFood(int index)
        {
            return MasFood[index].ToString();
        }

        public int Getsizeof()
        {
            return MasFood.Count;
        }

        public Food()
        {
            MasFood = new ArrayList();

            MasFood.Add("Рис");
            MasFood.Add("Хлеб");
            MasFood.Add("Мясо");
            MasFood.Add("Творог");
            MasFood.Add("Выпичка");
            MasFood.Add("Гречка");
            MasFood.Add("Овсянка");
            MasFood.Add("Кукурузная крупа");
            MasFood.Add("Пица");
            MasFood.Add("Бургер");
        }
       
    }
}
