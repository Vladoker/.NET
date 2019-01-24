using ProductStore.Entities;
using ProductStore.Entities.Drinks;
using ProductStore.Entities.Enums;
using ProductStore.Entities.Food;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStore.Core.Rand
{
   public class RandProduct
    {
        public Product Rand(Product product)
        {
            Random rnd = new Random();
            Food food = new Food();
            Drinks drinks = new Drinks();
            
            int max = Enum.GetNames(typeof(ProductType)).Length; //Вычисляем максимальный элемент Emuma ProductType

            product.ProductId = Guid.NewGuid();
            product.Type = (ProductType)rnd.Next(max);
            if (product.Type == ProductType.Food) product.Name = food.GetFood(rnd.Next(0, food.Getsizeof()));
            else product.Name = drinks.GetDrink(rnd.Next(0, drinks.Getsizeof()));

            product.CreateDate = DateTime.Now;
            product.EndDate = DateTime.Now.AddDays(+7);





            return product;
        }
    }
}
