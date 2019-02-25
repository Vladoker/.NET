using ProductStore.Domain;
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
        public ProductStore.Entities.Owner AddOwner(Owner owner)
        {
            streamWriter = new StreamWriter(repositoryFilePath, true);
            streamWriter.WriteLine(owner.ToString());
            streamWriter.Close();

            return owner;
        }

        public Owner GetOwner(Guid ownerId)
        {
            Owner result = null;
            var line = string.Empty;

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

        public Owner GetOwner(string ownerName)
        {
            Owner result = null;
            var line = string.Empty;

            streamReader = new StreamReader(repositoryFilePath);
            while ((line = streamReader.ReadLine()) != null)
            {
                if (line.Contains(ownerName))
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
            var result = new List<Owner>();
            var line = string.Empty;

            streamReader = new StreamReader(repositoryFilePath);
            while ((line = streamReader.ReadLine()) != null)
            {
                result.Add(Owner.Parse(line));
            }
            streamReader.Close();

            return result;
        }
    }
}
