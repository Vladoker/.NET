using ProductStore.Entities;
using ProductStore.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStore.Common.Extentions
{
    public static class ProductExtentions
    {
        public static Product Parse(string product)
        {
            if (string.IsNullOrEmpty(product))
            {
                return null;
            }

            var productSplited = product.Split(new char[] { ';' });

            return new Product
            {
                ProductId = Guid.Parse(productSplited[0]),
                Name = productSplited[1],
                Type = (ProductType)Enum.Parse(typeof(ProductType), productSplited[2]),
                CreateDate = DateTime.Parse(productSplited[3]),
                EndDate = DateTime.Parse(productSplited[4]),
                Owner = new Owner { OwnerId = Guid.Parse(productSplited[5]) }
            };
        }

        public static Product ParseThis(this String product)
        {
            return new Product();
        }

        public static string ProductToString(this Product product)
        {
            return product.ToString();
        }

    }
}
