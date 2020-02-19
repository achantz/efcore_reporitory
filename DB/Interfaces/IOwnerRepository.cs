using System;
using System.Collections.Generic;
using api.Models;

namespace api.DB.Interfaces
{
    public interface IOwnerRepository : IRepositoryBase<Owner>
    {
        IEnumerable<Owner> GetAllOwners();
        Owner GetOwnerById(int ownerId);
        Owner GetOwnerWithDetails(int ownerId);
        void CreateOwner(Owner owner);
        void UpdateOwner(Owner owner);
    }
}