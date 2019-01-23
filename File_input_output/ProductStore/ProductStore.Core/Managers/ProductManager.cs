using ProductStore.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStore.Core
{
    public class ProductManager
    {
        private string filePath;
        private StreamWriter streamWriter;

        public ProductManager(string filePath)
        {
            this.filePath = filePath;
            streamWriter = new StreamWriter(this.filePath, true);
        }

        public Product Add(Product product)
        {
            streamWriter.WriteLine(product.ToString());
            streamWriter.Close();

            return product;
        }
    }
}
