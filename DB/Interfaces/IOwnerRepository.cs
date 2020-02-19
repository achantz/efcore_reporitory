using System;
using System.Collections.Generic;
using api.Models;

namespace api.DB.Interfaces
{
    public interface IOwnerRepository : IRepositoryBase<Owner>
    {
        IEnumerable<Owner> GetAllOwners();
        Owner GetOwnerById(long ownerId);
        Owner GetOwnerWithDetails(long ownerId);
        void CreateOwner(Owner owner);
        void UpdateOwner(Owner owner);
        void DeleteOwner(Owner owner);
    }
}