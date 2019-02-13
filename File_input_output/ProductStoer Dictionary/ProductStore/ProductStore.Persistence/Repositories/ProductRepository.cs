using ProductStore.Domain;
using ProductStore.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductStore.Common.Extentions;

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
            Product result = null;
            var line = string.Empty;

            streamReader = new StreamReader(repositoryFilePath);
            while ((line = streamReader.ReadLine()) != null)
            {
                if (line.Contains(productId.ToString()))
                {
                    result = Common.Extentions.ProductExtentions.Parse(line);
                    break;
                }
            }
            streamReader.Close();

            return result;
        }

        public List<Product> GetProducts(ProductFilter filter)
        {
            var result = new List<Product>();
            
            var line = string.Empty;

            streamReader = new StreamReader(repositoryFilePath);
            while ((line = streamReader.ReadLine()) != null)
            {
                var product = Common.Extentions.ProductExtentions.Parse(line);

                if (filter != null &&
                    ((!filter.ProductType.HasValue || product.Type == filter.ProductType.Value)
                    &&
                    (filter.Owner == null|| product.Owner.OwnerId == filter.Owner.OwnerId)
                    &&
                    (!filter.ProductEndDate.HasValue || product.EndDate <= filter.ProductEndDate.Value)
                     &&
                    (!filter.ProductIsValid.HasValue || product.IsValid == filter.ProductIsValid.Value)
                   ))
                {
                    result.Add(product);
                }
            }
            streamReader.Close();

            return result;
        }
    }
}
