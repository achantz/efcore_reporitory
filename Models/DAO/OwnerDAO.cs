using System.Security.Principal;
using System;
using System.Collections.Generic;

namespace api.Models.DAO
{
    public class OwnerDAO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }

        public IEnumerable<AccountDAO> Accounts { get; set; }
    }
}