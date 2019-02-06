using ProductStore.Common;
using ProductStore.Core.Rand;
using ProductStore.Domain;
using ProductStore.Entities;
using ProductStore.Persistence;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProductStore.Core
{
    public class ProductManager
    {
        private ProductRepository productRepository;

        public ProductManager(ProductRepository productRepository) //конструктор
        {
            this.productRepository = productRepository;
        }

        public Product AddProduct(Product product) // Метод который записывает Продукт в txt
        {
            return productRepository.addProduct(product);
        }

        public Product GetProdcut(Guid productId) // возрощает продукт по указаному id 
        {
            return productRepository.GetProduct(productId);
        }

        public List<Product> GetProducts(ProductFilter filter)
        {
            List<Product> products = productRepository.GetProducts(filter);
            return productRepository.GetProducts(filter);
        }


        public void GenerateTestData(List<Owner> owners)
        {
            StreamWriter streamWriter = new StreamWriter(Constants.ProductStorePath, false);

            for (var i = 0; i < 100; i++)
            {
                var product = new Product
                {
                    ProductId = Guid.NewGuid(),
                    Name = $"Product_{i}",
                    Type = (Entities.Enums.ProductType)((i % 2) == 0 ? 2 : 1),
                    CreateDate = DateTime.Now.AddDays(i),
                    EndDate = DateTime.Now.AddDays(i + 3),
                    Owner = owners[(new Random().Next(owners.Count))]
                };
                streamWriter.WriteLine(product.ToString());
            }

            streamWriter.Flush();
            streamWriter.Close();
            streamWriter.Dispose();
        }







        //public void addRand(int count)
        //{
        //    StreamWriter streamWriter = new StreamWriter(Constants.ProductStorePath, false);
        //    RandProduct rand = new RandProduct();
        //    Product product;


        //    for (int i = 0; i < count; i++)
        //    {

        //        try
        //        {
        //            product = rand.Rand();
        //            streamWriter.WriteLine(product.ToString());
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine(ex.ToString());
        //            Console.ReadKey();
        //        }

        //    }
        //    streamWriter.Flush();
        //    streamWriter.Close();
        //    streamWriter.Dispose();
        //}








    }
}
