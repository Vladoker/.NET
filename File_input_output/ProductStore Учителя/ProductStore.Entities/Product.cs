using ProductStore.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStore.Entities
{
    public class Product
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public ProductType Type { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime EndDate { get; set; }
        public Owner Owner { get; set; }

        public bool IsValid => EndDate >= DateTime.Now.Date;

        public override string ToString()
        {
            return $"{this.ProductId};{this.Name};{this.Type.ToString()};{this.CreateDate};{this.EndDate};{Owner.OwnerId.ToString()}";
        }

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
                Owner = new Owner {OwnerId = Guid.NewGuid()}
            };
        }
    }
}
