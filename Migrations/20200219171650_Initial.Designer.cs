﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using api.DB;

namespace api.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20200219171650_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113");

            modelBuilder.Entity("api.Models.Account", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("AccountID");

                    b.Property<string>("AccountType")
                        .IsRequired();

                    b.Property<DateTime>("DateCreated");

                    b.Property<long>("OwnerId");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("account");
                });

            modelBuilder.Entity("api.Models.Owner", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("OwnerID");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.HasKey("Id");

                    b.ToTable("owner");

                    b.HasData(
                        new { Id = 1L, Address = "23 KillYou Street", DateOfBirth = new DateTime(1982, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), Name = "Steven Segal" },
                        new { Id = 2L, Address = "45 Funny Street", DateOfBirth = new DateTime(1979, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), Name = "Joe Dirt" },
                        new { Id = 3L, Address = "56 Pickadilly Street", DateOfBirth = new DateTime(1946, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), Name = "John Cleese" }
                    );
                });

            modelBuilder.Entity("api.Models.Account", b =>
                {
                    b.HasOne("api.Models.Owner", "Owner")
                        .WithMany("Accounts")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
