using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStore.Entities
{
    public class Owner
    {
       public String Name { get; set; }
       public Guid OwnerId { get; set; }
    }
}
