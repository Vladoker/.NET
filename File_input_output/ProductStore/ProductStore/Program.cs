using ProductStore.Common;
using ProductStore.Core;
using ProductStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStore
{
    class Program
    {
        static void Main(string[] args)
        {
            var productStoreFilePath = @"D:\GR1724\Projects\ProductStore\DATA\Products.txt";
            var productManager = new ProductManager(productStoreFilePath);
            var product = new Product
            {
                ProductId = Guid.NewGuid(),
                Name = "Lapte",
                Type = Entities.Enums.ProductType.Drink,
                CreateDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(Constants.ProductDays.ValidPeriod)
            };

            try
            {
                productManager.Add(product);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.ReadKey();
            }
         }
    }
}
