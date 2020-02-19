using System;

namespace api.Models.DAO
{
    public class AccountDAO
    {
        public long Id { get; set; }
        public DateTime DateCreated { get; set; }
        public string AccountType { get; set; }
    }
}