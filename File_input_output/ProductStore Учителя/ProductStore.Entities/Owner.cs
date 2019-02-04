using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStore.Entities
{
    public class Owner
    {
        public Guid OwnerId { get; set; }
        public string OwnerName { get; set; }

        public override string ToString()
        {
            return $"{this.OwnerId};{this.OwnerName}";
        }

        public static Owner Parse(string owner)
        {
            if (string.IsNullOrEmpty(owner))
            {
                return null;
            }

            var ownerSplited = owner.Split(new char[] { ';' });

            return new Owner
            {
                OwnerId = Guid.Parse(ownerSplited[0]),
                OwnerName = ownerSplited[1]
            };
        }
    }
}
