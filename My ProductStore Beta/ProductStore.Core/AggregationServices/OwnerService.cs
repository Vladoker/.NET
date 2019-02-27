using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductStore.Entities;
using ProductStore.Domain;

namespace ProductStore.Core.AggregationServices
{
    public class OwnerService
    {
        private Dictionary<Guid, List<Guid>> dictionaryOwnerProducts = new Dictionary<Guid, List<Guid>>();
        private readonly ProductManager productManager;
        private readonly OwnerManager ownerManager;

        public OwnerService(ProductManager productManager, OwnerManager ownerManager)
        {
            this.productManager = productManager;
            this.ownerManager = ownerManager;

            Init();
        }

        public Owner CheckProduct(Guid productId)
        {
            var result = new Owner();

            foreach (var key in dictionaryOwnerProducts.Keys)
            {
                List<Guid> values;
                dictionaryOwnerProducts.TryGetValue(key, out values);

                if (values != null && values.Contains(productId))
                {
                    result = ownerManager.GetOwner(key);
                    break;
                }
            }

           return result;
        }

        private void Init()
        {
            var owner = Guid.Empty;

            var products = productManager.GetProducts();

            //dictionaryOwnerProducts.Add(owner, productIds);

        }
    }
}
