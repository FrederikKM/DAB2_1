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
            var cityRepo = new Repository<City>(context);
            var countryCodeRepo = new Repository<CountryCode>(context);

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
                AddressName = new AddressName()
                {
                    HouseNumber = "4",
                    StreetName = "Grankrogen"
                }
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

            var city = new City()
            {
                Name = "Skødstrup",
                ZipCode = "8541",
            };
            city.Addresses.Add(address);

            var countryCode = new CountryCode()
            {
                City = city,
                Code = "Dk"
            };


            Console.WriteLine("Creating classes");
            Console.WriteLine();

            // Create
            // Person
            await personRepo.CreateAsync(person);
            // Telephonecompany
            await telephoneCompanyRepo.CreateAsync(telephoneCompany);
            await personAddressRepo.CreateAsync(personAddress);
            await personAddressTypeRepo.CreateAsync(personAddressType);
            await cityRepo.CreateAsync(city);
            await countryCodeRepo.CreateAsync(countryCode);

            await uow.SaveAsync();
            Console.WriteLine("Unit Of Work - Saving...");

            Console.WriteLine("Reading info");
            Console.WriteLine();

            // Read
            person = personRepo.ReadAsync(person.Id).Result;
            PrintPerson(telephoneCompanyRepo, person, telephoneCompany);

            Console.WriteLine("Updating info");
            Console.WriteLine();

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
            Console.WriteLine("Unit Of Work - Saving...");

            PrintPerson(telephoneCompanyRepo, person, telephoneCompany);

            Console.WriteLine("Deleting Info");
            Console.WriteLine();

            // Delete
            personRepo.Delete(person);
            telephoneCompanyRepo.Delete(telephoneCompany);
            addressRepo.Delete(address);
            cityRepo.Delete(city);
            countryCodeRepo.Delete(countryCode);

            await uow.SaveAsync();
            Console.WriteLine("Unit Of Work - Saving...");


            try
            {
                person = null;
                person = personRepo.ReadAsync(person.Id).Result;
            }
            catch (Exception)
            {
                Console.WriteLine("Person not found...");
            }
        }

        private static void PrintPerson(Repository<TelephoneCompany> telephoneCompanyRepo, Person person, TelephoneCompany telephoneCompany)
        {
            Console.WriteLine($"Person {person.FirstName} {person.MiddleName} {person.LastName}");
            Console.WriteLine($"Person Context: {person.Context} | {person.Email}");
            foreach (var phoneNumber in person.PhoneNumbers)
            {
                Console.WriteLine($"   Phonenumbers {phoneNumber.Number} Usage: {phoneNumber.Usage}");
                Console.WriteLine($"      Company {telephoneCompanyRepo.Read(telephoneCompany.Id).CompanyName}");
            }

            foreach (var personPersonAddress in person.PersonAddresses)
            {
                Console.WriteLine($"   Address {personPersonAddress.Address.AddressName.StreetName} {personPersonAddress.Address.AddressName.HouseNumber}");
                Console.WriteLine($"   Address Type {personPersonAddress.Address.AddressTypes.SingleOrDefault(p => p.Address == personPersonAddress.Address)?.Type}");
                Console.WriteLine($"      City {personPersonAddress.Address.City.Name}");
                Console.WriteLine($"      ZipCode {personPersonAddress.Address.City.ZipCode}");
                Console.WriteLine($"         Country code {personPersonAddress.Address.City.CountryCode.Code}");

            }

            Console.WriteLine("\n\n");
        }
    }
}
