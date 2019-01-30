﻿using ProductStore.Common;
using ProductStore.Core;
using ProductStore.Core.Rand;
using ProductStore.Entities;
using System;
using System.Collections;
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
            String productStoreFilePath = @"D:\vladok\new_C_charp\File_input_output\ProductStore\DATA\Products.txt";
            ProductManager productManager = new ProductManager(productStoreFilePath);




            // productManager.AddRand(1000);


            Guid e = Guid.Parse("47361c0b-bfde-436a-8427-f8f5ad03cd06");

            Product prod = productManager.GetProduct(e);

            Console.WriteLine(prod.ToString());
            Console.ReadKey();


            //ArrayList SQL = new ArrayList();

            //for (int i = 0; i < 50; i++)
            //{
            //    SQL.Add(new RandProduct());
            //}


            //foreach (var item in SQL)
            //{


            //}









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