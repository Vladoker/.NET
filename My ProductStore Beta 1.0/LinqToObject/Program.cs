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
            SearchCity();
        }

        private static void SearchCity()
        {
            List<string> sity = new List<string>(20)
            {
                "Кишинёв",
                "Киев",
                "Копенгаген",
                "Мумбаи",
                "Флорианополис",
                "Сиэтл",
                "Осло",
                "Тель-Авив",
                "Лиссабон",
                "Кали",
                "Окленд",
                "Стамбул",
                "Ханой",
                "Токио",
                "Тайбэй",
                "Рейкьявик",
                "Берлин",
                "Кейптаун",
                "Лондон",
                "Торонто",
            };


            Console.Write("\nВведите первую букву города - ");
            string strStart = IsLetter(Console.ReadKey().KeyChar);


            Console.Write("\nВведите последнию букву города - ");
            string str_End = IsEnd(Console.ReadKey().KeyChar);


            Console.WriteLine();


            var result = from s in sity where s[0].ToString().ToLower() == strStart.ToLower() where s[s.Length - 1].ToString().ToLower() == str_End.ToLower() select s;



            if (result.Count() == 0) Console.WriteLine("\n\nТакого города нету");
            else
            {
                Console.WriteLine("\nГорода\n\n");
                foreach (var item in result)
                {
                    Console.WriteLine(item);
                }
            }

            Console.ReadKey();
        }

        public static string IsLetter(Char c)
        {
            var digit = new List<Char> { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        
            while (digit.Contains(c))
            {
                Console.WriteLine();
                Console.Write("Неправельный ввод данных : ");
                c = Console.ReadKey().KeyChar;             
            }

            string str = c.ToString().ToUpper();
            return str;
        }

        public static string IsEnd(Char c)
        {
            var digit = new List<Char> { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

            while (digit.Contains(c))
            {
                Console.WriteLine();
                Console.Write("Неправельный ввод данных : ");
                c = Console.ReadKey().KeyChar;
            }
            
            string str = c.ToString().ToLower();
            return str;
        }

        private static void Lesson1_Join_LINQ()
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
        }

    }
}
