using DAB2_2RDB.Models;
using Microsoft.EntityFrameworkCore;

namespace DAB2_2RDB
{
    public class Dab2_2RdbContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }
        public DbSet<TelephoneCompany> TelephoneCompanies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Data Source =(localDB)\MSSQLLocalDB; Initial Catalog = DAB2_2RDB; Integrated Security = True;");


        }
    }
}