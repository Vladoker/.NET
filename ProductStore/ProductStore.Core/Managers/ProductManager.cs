using ProductStore.Entities;
using ProductStore.Persistence.Repositories;
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
        private ProductRepository productRepository;

        public ProductManager(ProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public Product AddProduct(Product product)
        {
            return productRepository.AddProduct(product); ;
        }

        public Product GetProduct(Guid productId)
        {
            return productRepository.GetProduct(productId);
        }
    }
}
