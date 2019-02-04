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

namespace ProductStore
{
    class Program
    {
        static void Main(string[] args)
        {

            var productRepository = new ProductRepository(Constants.ProductStorePath);
            var productManager = new ProductManager(productRepository);

            var ownerRepository = new OwnerRepository(Constants.OwnerStorePath);
            var ownerManager = new OwnerManager(ownerRepository);

          

            var owners = ownerManager.GetOwners();
            foreach (var item in owners)
            {
                Console.WriteLine(item.ToString());
            }

            //productManager.GenerateTestData(owners);

            var products = productManager.GetProducts(
                new ProductFilter { ProductIsValid = true });

            foreach (var item in products)
            {
                Console.WriteLine(item.ToString());
                Console.WriteLine(item.IsValid);
            }

            Console.ReadKey();
        }
    }
}
