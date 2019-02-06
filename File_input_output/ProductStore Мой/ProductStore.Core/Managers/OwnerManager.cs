using ProductStore.Entities;
using ProductStore.Entities.Enums;
using ProductStore.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStore.Core
{
    public class OwnerManager
    {
        private OwnerRepository ownerRepository;

        public OwnerManager(OwnerRepository ownerRepository)
        {
            this.ownerRepository = ownerRepository;
        }

        

        public Owner AddOwner(Owner owner)
        {
            return ownerRepository.AddOwner(owner);
        }

        public Owner GetOwner(Guid ownerId)
        {
            return ownerRepository.GetOwner(ownerId);
        }

        public List<Owner> GetOwners()
        {
            return ownerRepository.GetOwners();
        }

        public void DeleteOwner(Guid ownerId)
        {
            ownerRepository.DeleteOwner(ownerId);
        }
    }
}
