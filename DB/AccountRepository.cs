using api.DB.Interfaces;
using api.Models;

namespace api.DB
{
    public class AccountRepository : RepositoryBase<Account>, IAccountRepository
    {
        public AccountRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {

        }
    }
}