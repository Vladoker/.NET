using ProductStore.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStore.Persistence.Repositories
{
    public class OwnerRepository
    {
        private string repositoryFilePath;
        private StreamWriter streamWriter;
        private StreamReader streamReader;

        public OwnerRepository(string repositoryFilePath)
        {
            this.repositoryFilePath = repositoryFilePath;
        }

        public Owner AddOwner(Owner owner)
        {
            streamWriter = new StreamWriter(repositoryFilePath,true);
            streamWriter.WriteLine(owner.ToString());
            streamWriter.Close();

            return owner;
        }

        public Owner GetOwner(Guid ownerId)
        {
            Owner result = null;
            string line = string.Empty;

            streamReader = new StreamReader(repositoryFilePath);
            while ((line = streamReader.ReadLine()) != null)
            {
                if (line.Contains(ownerId.ToString()))
                {
                    result = Owner.Parse(line);
                    break;
                }
            }
            streamReader.Close();

            return result;
        }

        public List<Owner> GetOwners()
        {
            List<Owner> result = new List<Owner>();
            string line = string.Empty;

            streamReader = new StreamReader(repositoryFilePath);
            while ((line = streamReader.ReadLine()) != null)
            {
                result.Add(Owner.Parse(line));
            }
            streamReader.Close();

            return result;
        }

        public void DeleteOwner(Guid ownerId)
        {

            Owner owner = GetOwner(ownerId);
            if (owner == null) return;

            List<Owner> owners = GetOwners();

            foreach (var item in owners)
            {
                if (item == owner)
                {
                    owners.Remove(item);
                    break;
                }
            }



            streamWriter = new StreamWriter(repositoryFilePath, true);

            foreach (var item in owners)
            {
                streamWriter.WriteLine(item.ToString());
            }
            streamWriter.Close();

        }

    }
}
