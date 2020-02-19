using System.Data;
using api.Models.DAO;
using AutoMapper;

namespace api.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Owner, OwnerDAO>();
            CreateMap<Account, AccountDAO>();
            CreateMap<OwnerForCreationDAO, Owner>();
            CreateMap<OwnerForUpdateDAO, Owner>();
        }
    }
}