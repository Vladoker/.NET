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
            return $"{this.ProductId};{this.Name};{this.Type.ToString()};{this.CreateDate.ToString("dd.MM.yyyy")};{this.EndDate.ToString("dd.MM.yyyy")};{Owner.OwnerId.ToString()}";
        }

        public static Product Parse(string str)
        {

            if (string.IsNullOrEmpty(str)) return null;


            string[] mas = str.Split(new char[] { ';' });

            Product product = new Product()
            {
                ProductId = Guid.Parse(mas[0]),
                Name = mas[1],
                Type = (ProductType)Enum.Parse(typeof(ProductType), mas[2]),
                CreateDate = DateTime.Parse(mas[3]),
                EndDate = DateTime.Parse(mas[4]),
                Owner = new Owner {OwnerId = Guid.NewGuid()}
            };

            return product;
        }
    }
}
