using ProductStore.Common;
using ProductStore.Domain;
using ProductStore.Entities;
using ProductStore.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStore.Core
{
    public class ProductManager
    {
        private ProductRepository productRepository;

        public ProductManager(ProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public Product AddProduct(Product product)
        {
            return productRepository.AddProduct(product);
        }

        public Product GetProduct(Guid productId)
        {
            return productRepository.GetProduct(productId);
        }
        public List<Product> GetProducts(ProductFilter filter)
        {
            var products = productRepository.GetProducts(filter);

            return productRepository.GetProducts(filter);
        }
       

        public void GenerateTestData(List<Owner> owners)
        {
            StreamWriter streamWriter = new StreamWriter(Constants.ProductStorePath, false);

            for (var i = 0; i < 1000; i++)
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
    }
}
