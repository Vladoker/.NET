using ProductStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStore.Core.Comparers
{
    public class ProductComparer : IComparer<Product>
    {
        private int typeComparer = 1; // 2,3,4 ..6

        public ProductComparer(int typeComparer)
        {
            this.typeComparer = typeComparer;
        }

        public int Compare(Product x, Product y)
        {
            switch (typeComparer)
            {
                case 1: return CompareMethod(x, y);
                    break;
                default: return CompareMethodDefault(x, y);
            }
        }

        private int CompareMethod(Product x, Product y)
        {
            if (x.Name == y.Name)
            {
                return x.CreateDate.CompareTo(y.CreateDate);
            }

            return x.Name.CompareTo(y.Name);
        }

        private int CompareMethodDefault(Product x, Product y)
        {
          return x.Name.CompareTo(y.Name);
        }
    }
}
