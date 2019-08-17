using LinqToObject.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToObject
{
   public class Contract
    {
        public int ContractId { get; set; }
        public DateTime ContracDate { get; set; }
        public ContractStatus Status { get; set; }
        
    }
}
