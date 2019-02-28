using ProductStore.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ProductStore.Entities
{
    [Serializable]
    public class ProductXml
    {
        [XmlAttribute]
        public Guid ProductId { get; set; }
        [XmlAttribute]
        public string ProductName { get; set; }
        //public ProductType Type { get; set; }
        //public DateTime CreateDate { get; set; }
        //public DateTime EndDate { get; set; }

        public OwnerXml Owner { get; set; }
     }
}
