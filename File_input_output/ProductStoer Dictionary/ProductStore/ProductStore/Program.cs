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

            var ownerService = new OwnerService(productManager, ownerManager);

            var productId = Guid.Parse("09695773-97a2-490c-b5d2-83687a9a4cdb");
            var productOwner = ownerService.CheckProduct(productId);

            Console.Write(productOwner.OwnerName);
            Console.ReadKey();
  
        }
    }
}
