using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using DAB2_2RDB;
using DAB2_2RDB.Models;

namespace DAB2_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Task(args).GetAwaiter().GetResult();
        }



        static async Task Task(string[] args)
        {
            var context = new Dab2_2RdbContext();
            var uow = new UnitOfWork(context);
            var personRepo = new Repository<Person>(context);
            var telephoneCompanyRepo = new Repository<TelephoneCompany>(context);
            var addressRepo = new Repository<Address>(context);
            var personAddressRepo = new UnionRepository<PersonAddress>(context);
            var addressTypeRepo = new Repository<AddressType>(context);
            var personAddressTypeRepo = new UnionRepository<PersonAddressType>(context);

            var person = new Person
            {
                FirstName = "Kasper",
                LastName = "Hermansen",
                Email = "Drelixgaming@gmail.com",
                Context = "Myself",
                PhoneNumbers = new List<PhoneNumber>()
                {
                    new PhoneNumber()
                    {
                        Number = "+45 28 99 02 58",
                        Usage = "Work",
                    },
                    new PhoneNumber()
                    {
                        Number = "+45 61 66 20 25",
                        Usage = "School",
                    }
                },
            };

            var telephoneCompany = new TelephoneCompany()
            {
                CompanyName = "Telmore"
            };

            var address = new Address()
            {
                HouseNumber = "4",
                StreetName = "Grankrogen"
            };

            var personAddress = new PersonAddress()
            {
                Address = address,
                Person = person
            };

            var addressType = new AddressType()
            {
                Type = "Home",
                Address = address
            };
            
            var personAddressType = new PersonAddressType()
            {
                Person = person,
                AddressType = addressType
            };
            

            // Create
            // Person
            await personRepo.CreateAsync(person);
            // Telephonecompany
            await telephoneCompanyRepo.CreateAsync(telephoneCompany);
            await personAddressRepo.CreateAsync(personAddress);
            await personAddressTypeRepo.CreateAsync(personAddressType);

            await uow.SaveAsync();

            // Read
            person = personRepo.ReadAsync(person.Id).Result;

            Console.WriteLine(person.PhoneNumbers.First().Usage);


            // Update
            person.FirstName = "Karsten";
            person.PhoneNumbers.Add(new PhoneNumber()
            {
                Number = "Blabla 22 22",
                Usage = "Misc"
            });

            foreach (var personPhoneNumber in person.PhoneNumbers)
            {
                personPhoneNumber.TelephoneCompany = telephoneCompany;
            }
            await telephoneCompanyRepo.UpdateAsync(telephoneCompany.Id, telephoneCompany);


            await personRepo.UpdateAsync(person.Id, person);
            await uow.SaveAsync();




            // Delete
            personRepo.Delete(person);
            telephoneCompanyRepo.Delete(telephoneCompany);
            addressRepo.Delete(address);

            await uow.SaveAsync();
        }
    }
}
