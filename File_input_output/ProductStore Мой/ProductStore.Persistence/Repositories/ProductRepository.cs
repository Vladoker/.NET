using ProductStore.Domain;
using ProductStore.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStore.Persistence
{
    public class ProductRepository
    {
        private string repositoryfilePath;
        private StreamWriter sreamWriter;
        private StreamReader streamReader;
        
        public ProductRepository(string repositoryFilePath)
        {
            this.repositoryfilePath = repositoryFilePath;
        }

        public Product addProduct(Product product)
        {
            sreamWriter = new StreamWriter(repositoryfilePath,true);
            sreamWriter.WriteLine(product.ToString());
            sreamWriter.Close();

            return product;
        }

        public Product GetProduct(Guid productId)
        {
            Product result = null;
            string line = string.Empty;
            streamReader = new StreamReader(repositoryfilePath);
            while ((line = streamReader.ReadLine()) != null)
            {
                if (line.Contains(productId.ToString()))
                {
                    result = Product.Parse(line);
                    break;
                }
            }
            return result;
        }

        public List<Product> GetProducts(ProductFilter filter)
        {
            List<Product> result = new List<Product>();
            string line = string.Empty;

            streamReader = new StreamReader(repositoryfilePath);

            while ((line = streamReader.ReadLine()) != null)
            {
                Product product = Product.Parse(line);

                if (
                    (!filter.ProductType.HasValue || product.Type == filter.ProductType.Value)
                    &&
                    (string.IsNullOrEmpty(filter.OwnerName) || product.Owner.Name == filter.OwnerName)
                    &&
                    (!filter.ProductEndDate.HasValue || product.EndDate <= filter.ProductEndDate.Value)
                     &&
                    (!filter.ProductIsValid.HasValue || product.IsValid == filter.ProductIsValid.Value)
                   )
                {
                    result.Add(product);
                }
            }
            streamReader.Close();

            return result;
        }
    }
}
