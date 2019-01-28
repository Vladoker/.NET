using ProductStore.Core.Rand;
//using ProductStore.Core.SQL;
using ProductStore.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
            //streamWriter = new StreamWriter(this.filePath, true);
        }

        public Product Add(Product product)
        {
            streamWriter.WriteLine(product.ToString());
            streamWriter.Close();

            return product;
        }

        public void Add(Product product, int count)
        {

            for (int i = 0; i < count; i++)
            {
                
                try
                {
                    streamWriter.WriteLine(product.ToString());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    Console.ReadKey();
                }
            }

            streamWriter.Close(); 
        }
        public void AddRand(int count)
        {
            RandProduct rand = new RandProduct();
            Product product;


            for (int i = 0; i < count; i++)
            {
                
                try
                {
                    product = rand.Rand();
                    streamWriter.WriteLine(product.ToString());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    Console.ReadKey();
                }
                
            }

            streamWriter.Close(); 
        }


        public Product GetProduct(Guid productId)
        {
            Product result = null;
            string line = string.Empty;
            StreamReader streamReader = new StreamReader(filePath);
            while ((line = streamReader.ReadLine()) != null)
            {
                if (line.Contains(productId.ToString()))
                {

                    result = Product.Parse(line);
                    break;

      
                }
            }

            streamReader.Close();
            return result;
        }





        //public Product GetProduct(Guid productId)
        //{
        //    Product_SQL sql = new Product_SQL();
        //    Product prod;

        //    foreach (var item in sql.SQL)
        //    {
        //        if (item.ProductId == productId)
        //        {
        //            return item;
        //        }
        //    }

        //    for (int i = 0; i < sql.getCount(); i++)
        //    {
        //        prod = sql.SQL;

        //    }
        //    return;
        //}
    }
}
