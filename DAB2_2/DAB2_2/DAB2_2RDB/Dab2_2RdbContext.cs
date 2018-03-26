﻿using DAB2_2RDB.Models;
using Microsoft.EntityFrameworkCore;

namespace DAB2_2RDB
{
    public class Dab2_2RdbContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }
        public DbSet<TelephoneCompany> TelephoneCompanies { get; set; }
        public DbSet<PersonAddress> PersonAddresses { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<AddressType> AddressTypes { get; set; }
        public DbSet<PersonAddressType> PersonAddressTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Data Source =(localDB)\MSSQLLocalDB; Initial Catalog = DAB2_2RDB; Integrated Security = True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .HasMany(p => p.PhoneNumbers)
                .WithOne(pn => pn.Person);

            modelBuilder.Entity<PhoneNumber>()
                .HasOne(pn => pn.TelephoneCompany)
                .WithMany(tc => tc.PhoneNumbers);

            modelBuilder.Entity<PersonAddress>()
                .HasKey(k => new {k.PersonId, k.AddressId});

            modelBuilder.Entity<PersonAddressType>()
                .HasKey(k => new {k.PersonId, k.AddressTypeId});

            base.OnModelCreating(modelBuilder);
        }
    }
}