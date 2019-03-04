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
using ProductStore.Core.Comparers;

namespace ProductStore
{
    class Program
    {
        static void Main(string[] args)
        {
            var program = new Program();

            var ownerRepository = new OwnerRepository(Constants.OwnerStorePath);
            var ownerManager = new OwnerManager(ownerRepository);

            var productRepository = new ProductRepository(Constants.ProductStorePathXml);
            var productManager = new ProductManager(productRepository, ownerManager);






            //var randProductXml = productManager.GenerateTestDataXml(20);

            //foreach (var item in randProductXml)
            //{
            //    Console.WriteLine(item.ProductName + " " + item.ProductId + " " + item.Prica + " " + item.Owner.OwnerId + " " + item.Owner.OwnerName);
            //}






            //var removeProductXml = productManager.RemoveProductFromXml(Guid.Parse("710eec3f-f237-4f62-8030-518a9bce96f2"));
            //List<ProductXml> products = productManager.GetProductsFromXml();

            //foreach (ProductXml product in products)
            //{
            //    Console.WriteLine(product.ProductName);
            //}





            //ProductXml product = new ProductXml
            //{
            //    ProductId = Guid.NewGuid(),
            //    ProductName = "Lapte Acru",
            //    Prica = 22.55M,
            //    Owner = new OwnerXml
            //    {
            //        OwnerId = Guid.NewGuid(),
            //        OwnerName = "JLC"
            //    }
            //};

            //productManager.AddProductToXml(product);





            Console.ReadKey();
        }

        private static void SearchOwnerIdfromXml()
        {
            var program = new Program();

            var ownerRepository = new OwnerRepository(Constants.OwnerStorePath);
            var ownerManager = new OwnerManager(ownerRepository);

            var productRepository = new ProductRepository(Constants.ProductStorePathXml);
            var productManager = new ProductManager(productRepository, ownerManager);

            var ownerService = new OwnerService(productManager, ownerManager);

            var productId = Guid.Parse("09695773-97a2-490c-b5d2-83687a9a4cdb");
            var productOwner = ownerService.CheckProduct(productId);

            Console.Write(productOwner.OwnerName);

            var products = productManager.GetProducts();

            program.DisplayProducts(products);

            products.Sort(new ProductComparer(1));

            Console.WriteLine();
            Console.WriteLine("-----------------------------DIVIDER-----------------");
            Console.WriteLine();

            program.DisplayProducts(products);
        }

        public void DisplayProducts(List<ProductStore.Entities.Product> products)
        {
            foreach (var product in products)
            {
                Console.WriteLine(product.ToString());
            }
        }
    }
}
