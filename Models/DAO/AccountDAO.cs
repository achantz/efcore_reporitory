using System;

namespace api.Models.DAO
{
    public class AccountDAO
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public string AccountType { get; set; }
    }
}