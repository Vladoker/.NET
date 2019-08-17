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
        private OwnerManager ownerManager;

        public ProductManager(ProductRepository productRepository, OwnerManager ownerManager)
        {
            this.productRepository = productRepository;
            this.ownerManager = ownerManager;
        }

        public ProductStore.Entities.Product AddProduct(ProductStore.Entities.Product product)
        {
            return productRepository.AddProduct(product);
        }

        public ProductStore.Entities.Product GetProduct(Guid productId)
        {
            return productRepository.GetProduct(productId);
        }

        public List<ProductStore.Entities.Product> GetProducts(ProductStore.Domain.ProductFilter filter = null)
        {
            ProductStore.Entities.Owner filterOwner = null;
            if (filter != null && !string.IsNullOrEmpty(filter.Owner.OwnerName))
            {
                filterOwner = ownerManager.GetOwner(filter.Owner.OwnerName);
                filter.Owner = filterOwner;
            }

            var products = productRepository.GetProducts(filter);

            foreach (var product in products)
            {
                var owner = ownerManager.GetOwner(product.Owner.OwnerId);
                product.Owner = owner;
            }

            return products;
        }

        public void GenerateTestData(List<ProductStore.Entities.OwnerXml> owners, int count)
        {
            List<ProductXml> products = new List<ProductXml>();

            for (var i = 0; i < count; i++)
            {
                var product = new ProductStore.Entities.ProductXml
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = $"Product_{i}",
                    //Type = (Entities.Enums.ProductType)((i % 2) == 0 ? 2 : 1),
                    //CreateDate = DateTime.Now.AddDays(i),
                    //EndDate = DateTime.Now.AddDays(i + 3),
                    Owner = owners[(new Random().Next(owners.Count))]
                };
                products.Add(product);

              
                //streamWriter.WriteLine(product.ToString());
            }
            productRepository.AddRangeProductsToXml(products);
        }

        public List<ProductXml> GenerateTestDataXml(int count)
        {
            var result = new List<ProductXml>(count);

            var randomer = new Random();

            for (int i = 0; i < count; i++)
            { 
                result.Add(new ProductXml
                {
                    ProductId = Guid.NewGuid(),

                    /// Utilities.GetStringOfCaracters(10)
                    /// Utilities.GetDecemalOfDigits(2)
                    /// Utilities.GetIntegerOfDigits(3)
                    ProductName = $"{i+1}_ProductName",
                    Prica = randomer.Next(20, 700),
                    Owner = new OwnerXml
                    {
                        OwnerId = Guid.NewGuid(),
                        OwnerName = $"{i+1}_OwnerName"
                    }
                });      
                
            }
            productRepository.AddRangeProductsToXml(result);
            return result;
        }

        public List<ProductXml> GetProductsFromXml()
        {
            return productRepository.GetProductsFromXml();
        }

        public ProductXml AddProductToXml(ProductXml product)
        {
            return productRepository.AddProductToXml(product);
        }

        public ProductXml RemoveProductFromXml (Guid ProductId)
        {
            return productRepository.RemoveProductFromXml(ProductId);
        }
    }
}
