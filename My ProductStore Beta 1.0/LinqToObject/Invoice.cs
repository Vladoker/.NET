using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToObject
{
   public class Invoice
    {
        public Guid InvoiceId { get; set; }
        public int ContractId { get; set; }
        public decimal Total { get; set; }
    }
}
