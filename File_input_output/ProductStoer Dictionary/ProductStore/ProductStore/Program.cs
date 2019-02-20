using ProductStore.Common;
using ProductStore.Core;
using ProductStore.Domain;
using ProductStore.Entities;
using ProductStore.Entities.Enums;
using ProductStore.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductStore.Common.Extentions;
using ProductStore.Core.AggregationServices;
using System.Collections;
using ProductStore.Core.Comparer;

namespace ProductStore
{
    class Program
    {
        static void Main(string[] args)
        {
            var ownerRepository = new OwnerRepository(Constants.OwnerStorePath);
            var ownerManager = new OwnerManager(ownerRepository);

            var productRepository = new ProductRepository(Constants.ProductStorePath);
            var productManager = new ProductManager(productRepository, ownerManager);


            var products = productRepository.GetProducts(new ProductFilter());
            ComparerProduct sortComparer = new ComparerProduct();


           

            ShowProduct(products);
            Console.WriteLine("\n-----------------------------------------------\nSorts list\n");
            products.Sort();
     
            ShowProduct(products);
 

            Console.ReadKey();
        }

        public static void ShowProduct(List<Product> obj)
        {
            foreach (var item in obj)
            {
                Console.WriteLine(item);
            }
        }

        private static void Dictionary()
        {
            var ownerRepository = new OwnerRepository(Constants.OwnerStorePath);
            var ownerManager = new OwnerManager(ownerRepository);

            var productRepository = new ProductRepository(Constants.ProductStorePath);
            var productManager = new ProductManager(productRepository, ownerManager);

            var ownerService = new OwnerService(productManager, ownerManager);

            var productId = Guid.Parse("09695773-97a2-490c-b5d2-83687a9a4cdb");
            var productOwner = ownerService.CheckProduct(productId);

            Console.Write(productOwner.OwnerName);
            Console.ReadKey();
        }
    }
}
