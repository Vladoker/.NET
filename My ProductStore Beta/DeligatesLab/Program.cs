using ProductStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeligatesLab
{
    class Program
    {
        public delegate long DelegatePower(int x);
        public delegate string DelegateToString(int x);
        public delegate void DelegateProduct(int x);
        static void Main(string[] args)
        {
            var p = new Program();

            Console.WriteLine("this Delegates Lab");

            var testDelegatePowerInstance = new TestDelegatePower();

            var powerDelegate = new DelegatePower(testDelegatePowerInstance.Power);
            powerDelegate += new DelegatePower(testDelegatePowerInstance.AddTwo);

            powerDelegate(50);

            var exporter = new Exporter();
            exporter.P = new Product { Name = "Test" };

            Console.WriteLine(exporter.P.Name + "   " + exporter.P.EndDate);

            exporter.Export(p.DummyProduct);

            exporter.Export(p.ChangeProduct);

            Console.WriteLine(exporter.P.Name + "   "+ exporter.P.EndDate);

            Console.ReadKey();
        }

        public void DummyProduct(Product product)
        {
            product.Name +=  "2";
        }

        public void ChangeProduct(Product product)
        {
            product.EndDate = DateTime.Now;
        }

    }

    public class TestDelegatePower
    {


        public long Power(int z)
        {
            var result = (z * z);

            Console.WriteLine(result);

            return result;
        }

        public long AddTwo(int z)
        {
            var result = (z + 2);

            Console.WriteLine(result);

            return result;
        }
    }
}
