using ProductStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStore.Core.Comparer
{
    public class ComparerProduct : IComparer<Product>
    {
        public int Compare(Product x, Product y)
        {
            if (x.Name == y.Name)
            {
                return 0;
            }
            else if (x.CreateDate < y.CreateDate)
            {
                return -1;
            }

            return 1;
        }
    }
}
