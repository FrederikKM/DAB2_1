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

            // Create
            await personRepo.CreateAsync(person);

            await uow.SaveAsync();
           
            // Read
            person = personRepo.ReadAsync(person.Id).Result;

            Console.WriteLine(person.PhoneNumbers.First().Usage);

            // Update
            person.FirstName = "Karsten";
            person.PhoneNumbers.Add(new PhoneNumber()
            {
                Usage = "Misc"
            });

            await personRepo.UpdateAsync(person.Id, person);
            await uow.SaveAsync();

            // Delete
            personRepo.Delete(person);
            await uow.SaveAsync();
        }
    }
}
