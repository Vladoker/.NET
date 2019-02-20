using ProductStore.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStore.Entities
{
    public class Product : IComparable<Product>
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; } //
        public ProductType Type { get; set; }
        public DateTime CreateDate { get; set; } //icomparer
        public DateTime EndDate { get; set; }
        public Owner Owner { get; set; }

        public bool IsValid => EndDate >= DateTime.Now.Date;

        public int CompareTo(Product obj)
        {
            return CreateDate.CompareTo(obj.CreateDate);
        }


        public override string ToString()
        {
            return $"{this.ProductId};{this.Name};{this.Type.ToString()};{this.CreateDate};{this.EndDate};{Owner.OwnerName}";
        }
    }
}
