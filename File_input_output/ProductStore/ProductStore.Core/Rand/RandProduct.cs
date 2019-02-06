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

        Product product;
        Random rnd;
        Food food;
        Drinks drinks;
        int max;


        public Product GetRandProduct()
        {
            return product;
        }


        public Product Rand()
        {
           
             max = Enum.GetNames(typeof(ProductType)).Length; //Вычисляем максимальный элемент Emuma ProductType

            product.ProductId = Guid.NewGuid();
            product.Type = (ProductType)rnd.Next(max);
            if (product.Type == ProductType.Food) product.Name = food.GetFood(rnd.Next(0, food.GetCount()));
            else product.Name = drinks.GetDrink(rnd.Next(0, drinks.GetCount()));

            product.CreateDate = DateTime.Now;
            product.EndDate = DateTime.Now.AddDays(+7);





            return product;
        }


        public RandProduct()
        {
             product = new Product();
             rnd = new Random();
             food = new Food();
             drinks = new Drinks();

             max = Enum.GetNames(typeof(ProductType)).Length; //Вычисляем максимальный элемент Emuma ProductType

            product.ProductId = Guid.NewGuid();
            product.Type = (ProductType)rnd.Next(max);
            if (product.Type == ProductType.Food) product.Name = food.GetFood(rnd.Next(0, food.GetCount()));
            else product.Name = drinks.GetDrink(rnd.Next(0, drinks.GetCount()));

            product.CreateDate = DateTime.Now;
            product.EndDate = DateTime.Now.AddDays(+7);
        }
    }
}
