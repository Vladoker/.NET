using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProductStore.Entities
{
    [Serializable]
    public class OwnerXml
    {
        [XmlAttribute]
        public Guid OwnerId { get; set; }
        [XmlAttribute]
        public string OwnerName { get; set; }

        public override string ToString()
        {
            return $"{this.OwnerId};{this.OwnerName}";
        }

        public static OwnerXml Parse(string owner)
        {
            if (string.IsNullOrEmpty(owner))
            {
                return null;
            }

            var ownerSplited = owner.Split(new char[] { ';' });

            return new OwnerXml
            {
                OwnerId = Guid.Parse(ownerSplited[0]),
                OwnerName = ownerSplited[1]
            };
        }
    }
}
