using ProductStore.Common;
using ProductStore.Core;
using ProductStore.Core.Rand;
using ProductStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProductStore
{
    class Program
    {
        static void Main(string[] args)
        {
            String productStoreFilePath = @"D:\new_C_charp\File_input_output\ProductStore\DATA\Products.txt";
            //ProductManager productManager = new ProductManager(productStoreFilePath);

            
            RandProduct rand = new RandProduct();
            Product product = new Product();

            for (int i = 0; i < 50; i++)
            {

                ProductManager productManager = new ProductManager(productStoreFilePath);

                rand.Rand(product);

                try
                {
                    productManager.Add(product);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    Console.ReadKey();
                }
                Thread.Sleep(400);
            }
                      
                

            




            //Product product = new Product
            //{
            //    ProductId = Guid.NewGuid(),
            //    Name = "Lapte",
            //    Type = Entities.Enums.ProductType.Drink,
            //    CreateDate = DateTime.Now,
            //    EndDate = DateTime.Now.AddDays(Constants.ProductDays.ValidPeriod)
            //};

            //try
            //{
            //    productManager.Add(product);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.ToString());
            //    Console.ReadKey();
            //}
        }
    }
}
