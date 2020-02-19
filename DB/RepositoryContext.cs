using System;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.DB
{
    public class RepositoryContext : DbContext
    {
        // protected override void OnConfiguring(DbContextOptionsBuilder builder)
        // {
        //     builder.UseSqlite(@"Data Source=api.db;");
        // }

        public RepositoryContext(DbContextOptions options) : base(options)
        {
            //this.Database.EnsureCreated();
        }

        public DbSet<Owner> Owners { get; set; }
        public DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Owner>().HasKey(p => p.Id);
            builder.Entity<Owner>().HasData(
                new Owner
                {
                    Id = 1,
                    Name = "Steven Segal",
                    Address = "23 KillYou Street",
                    DateOfBirth = new DateTime(1982, 12, 15)
                },
                new Owner
                {
                    Id = 2,
                    Name = "Joe Dirt",
                    DateOfBirth = new DateTime(1979, 3, 13),
                    Address = "45 Funny Street",
                },
                new Owner
                {
                    Id = 3,
                    Name = "John Cleese",
                    DateOfBirth = new DateTime(1946, 6, 24),
                    Address = "56 Pickadilly Street"
                }
            );

            builder.Entity<Account>().HasKey(p => p.Id);
        }
    }
}