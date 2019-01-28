using ProductStore.Common;
using ProductStore.Core;
using ProductStore.Entities;
using ProductStore.Entities.Enums;
using ProductStore.Persistence.Repositories;
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
            var productRepository = new ProductRepository(productStoreFilePath);
            var productManager = new ProductManager(productRepository);
            var product = new Product
            {
                ProductId = Guid.NewGuid(),
                Name = "Lapte",
                Type = (ProductType)1,
                CreateDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(Constants.ProductDays.ValidPeriod)
            };

            try
            {
                productManager.AddProduct(product);

                var productResult = productManager.GetProduct(product.ProductId);

                Console.WriteLine(productResult?.ProductId);
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.ReadKey();
            }
         }
    }
}
