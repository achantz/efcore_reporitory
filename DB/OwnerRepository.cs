using System;
using System.Collections.Generic;
using System.Linq;
using api.DB.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.DB
{
    public class OwnerRepository : RepositoryBase<Owner>, IOwnerRepository
    {
        public OwnerRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {

        }

        public void CreateOwner(Owner owner)
        {
            CreateOwner(owner);
        }

        public IEnumerable<Owner> GetAllOwners()
        {
            return FindAll()
            .OrderBy(o => o.Name)
            .ToList();
        }

        public Owner GetOwnerById(int ownerId)
        {
            return FindByCondition(owner => owner.Id.Equals(ownerId)).FirstOrDefault();
        }

        public Owner GetOwnerWithDetails(int ownerId)
        {
            return FindByCondition(owner => owner.Id.Equals(ownerId))
            .Include(ac => ac.Accounts)
            .FirstOrDefault();
        }

        public void UpdateOwner(Owner owner)
        {
            UpdateOwner(owner);
        }
    }
}