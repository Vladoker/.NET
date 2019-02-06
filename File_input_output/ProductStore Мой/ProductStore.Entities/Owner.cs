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


        public override string ToString()
        {
            return $"{this.OwnerId};{this.Name}";
        }

        public static Owner Parse(string owner)
        {
            if (string.IsNullOrEmpty(owner)) return null;

            string[] mas = owner.Split(new char[] { ';' });

            return new Owner
            {
                OwnerId = Guid.Parse(mas[0]),
                Name = mas[1]
            };


        }
    }
}
