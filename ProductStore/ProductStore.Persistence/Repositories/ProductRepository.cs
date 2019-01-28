using ProductStore.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStore.Persistence.Repositories
{
    public class ProductRepository
    {
        private string repositoryFilePath;
        private StreamWriter streamWriter;
        private StreamReader streamReader;

        public ProductRepository(string repositoryFilePath)
        {
            this.repositoryFilePath = repositoryFilePath;

        }
        public Product AddProduct(Product product)
        {
            streamWriter = new StreamWriter(repositoryFilePath, true);
            streamWriter.WriteLine(product.ToString());
            streamWriter.Close();

            return product;
        }

        public Product GetProduct(Guid productId)
        {
            var result = new Product();
            var line = string.Empty;
            streamReader = new StreamReader(repositoryFilePath);
            while ((line = streamReader.ReadLine()) != null)
            {
                if (line.Contains(productId.ToString()))
                {
                    result.ProductId = productId;
                    return result;
                }
            }
                return result;
        }
    }
}
