using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToObject
{
    class Program
    {
        static void Main(string[] args)
        {
            var contracts = new List<Contract>
            {
              new Contract { ContractId = 1, ContracDate = DateTime.Now.AddDays(-1) },
              new Contract { ContractId = 2, ContracDate = DateTime.Now.AddDays(-3) },
              new Contract { ContractId = 3, ContracDate = DateTime.Now.AddDays(1) },
              new Contract { ContractId = 4, ContracDate = DateTime.Now.AddDays(5) },
              new Contract { ContractId = 5, ContracDate = DateTime.Now.AddDays(2) },

            };

            var invoices = new List<Invoice>
            {
                new Invoice{InvoiceId = Guid.NewGuid(), ContractId = 5, Total = 100.00M },
                new Invoice{InvoiceId = Guid.NewGuid(), ContractId = 4, Total = 200.00M },
                new Invoice{InvoiceId = Guid.NewGuid(), ContractId = 3, Total = 300.00M },
                new Invoice{InvoiceId = Guid.NewGuid(), ContractId = 2, Total = 400.00M },
                new Invoice{InvoiceId = Guid.NewGuid(), ContractId = 1, Total = 500.00M }
            };

            var Result = from c in contracts
                         join i in invoices on c.ContractId equals i.ContractId
                         select new
                         {

                             InvoiceId = i.InvoiceId,
                             ContractId = c.ContractId,
                             ContracDate = c.ContracDate,
                             Total = i.Total
                         };

            foreach (var item in Result)
            {
                Console.WriteLine($"Invoice-  {item.InvoiceId}     ContractId - {item.ContractId}    ContractDate-{item.ContracDate}    Total-{item.Total}");
            }

            Console.ReadKey();

            //var result = contracts.Join(invoices, // второй набор
            // c => c.ContractId, // свойство-селектор объекта из первого набора
            // i => i.ContractId,// свойство-селектор объекта из второго набора
            // (c, i) => new { ContractId = c.ContractId, ContracDate = c.ContracDate, InvoiceId = i.InvoiceId,}); // результат



        }
    }
}
