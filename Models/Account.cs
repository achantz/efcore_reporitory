using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("account")]
    public class Account
    {
        [Key]
        [Column("AccountID")]
        public long Id { get; set; }

        [Required(ErrorMessage = "Date created is required")]
        public DateTime DateCreated { get; set; }

        [Required(ErrorMessage = "Account type is required")]
        public string AccountType { get; set; }

        [ForeignKey(nameof(Owner))]
        public long OwnerId { get; set; }
        public Owner Owner { get; set; }
    }
}