using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductStore.Entities;

namespace DeligatesLab
{
    public class Exporter
    {
        public Product P { get; set; }

        //                 Method(Product product) { ........; return string  }
        public void Export(Action<Product> exportProduct)
        {
            exportProduct(P);
        }
    }
}
