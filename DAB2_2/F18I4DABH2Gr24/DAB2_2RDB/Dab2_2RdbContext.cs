using DAB2_2RDB.Models;
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
        public DbSet<City> Cities { get; set; }
        public DbSet<CountryCode> CountryCodes { get; set; }
        public DbSet<PrimaryAddress> PrimaryAddresses { get; set; }
        public DbSet<AddressName> AddressNames { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Data Source=10.29.0.29;Initial Catalog=F184DABH2Gr24;Integrated Security=False;User ID=F184DABH2Gr24;Password=F184DABH2Gr24;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
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