using ProductStore.Common;
using ProductStore.Core;
using ProductStore.Core.Rand;
using ProductStore.Domain;
using ProductStore.Entities;
using ProductStore.Persistence;
using ProductStore.Persistence.Repositories;
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
            ProductRepository productRepositoy = new ProductRepository(Constants.ProductStorePath);
            ProductManager productManager = new ProductManager(productRepositoy);

            OwnerRepository ownerRepository = new OwnerRepository(Constants.OwnerStorePath);
            OwnerManager ownerManager = new OwnerManager(ownerRepository);


            var owners = ownerManager.GetOwners();


            Console.WriteLine("До");
            foreach (var item in owners)
            {
                Console.WriteLine(item);
            }



            ownerManager.DeleteOwner(Guid.Parse("825193E7-3091-492A-84D3-21963616B62F"));


            Console.WriteLine();
            Console.WriteLine("После");

            foreach (var item in owners)
            {
                Console.WriteLine(item);
            }


            Console.ReadKey();
        }
    }
}
