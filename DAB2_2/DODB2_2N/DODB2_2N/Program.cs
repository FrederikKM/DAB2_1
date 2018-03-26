using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using DocumentDB.Repository;
using DODB2_2N.Model;
using Microsoft.Azure.Documents.Client.TransientFaultHandling;

namespace DODB2_2N
{
    class Program
    {
       public static IReliableReadWriteDocumentClient Client { get; set; }
        static void Main(string[] args)
        {
            IDocumentDbInitializer init = new DocumentDbInitializer();
            string endpointUrl = ConfigurationManager.AppSettings["azure.documentdb.endpointUrl"];
            string authorizationKey = ConfigurationManager.AppSettings["azure.documentdb.authorizationKey"];

            //Get the DB client
            Client = init.GetClient(endpointUrl, authorizationKey);
            Task t = MainAsync(args);
            t.Wait();
        }
        private static async Task MainAsync(string[] args)
        {
            string databaseId = ConfigurationManager.AppSettings["azure.documentdb.databaseId"];

            // create repository for persons
            DocumentDbRepository<Person> repo = new DocumentDbRepository<Person>(Client, databaseId);
            //create instance of Unit Of Work
            UnitOfWork UOW = new UnitOfWork(repo);
            // create a new person
            Person person1 = new Person
            {
                Id = "007",
                Name = "Ib",
                PrimaryAdress = new Primaryadress
                {
                    Adressname = "adress1",
                    City = new City { Name = "Skandeborg", ZipCode = new Zipcode { Code = "8660", CountryCode = "DK" } }
                },
                SecondaryAdress = new Secondaryadress[]
                {
                    new Secondaryadress
                    {
                        Adressname = "seconadre1",
                        AdressType = "Work",
                        City = new City {Name = "Stilling", ZipCode = new Zipcode {Code = "8660", CountryCode = "DK"}}
                    },
                    new Secondaryadress
                    {
                        Adressname = "seconadre2",
                        AdressType = "Holiday",
                        City = new City {Name = "Sønderborg", ZipCode = new Zipcode {Code = "6400", CountryCode = "DK"}}
                    },
                },
                TelephoneNumbers = new Telephonenumber[]
                {
                    new Telephonenumber {Number = "12345678", Provider = "TDC"},
                    new Telephonenumber {Number = "87654321", Provider = "Telenor"}
                }

            };

            // add person to database's collection (if collection doesn't exist it will be created and named as class name -it's a convenction, that can be configured during initialization of the repository)
            UOW.AddPerson(person1);

            // create another person
            Person person2 = new Person
            {
                Id = "008",
                Name="Bob",
                PrimaryAdress = new Primaryadress
                {
                    Adressname = "adress1",
                    City = new City { Name = "Aarhus N", ZipCode = new Zipcode { Code = "8200", CountryCode = "DK" } }
                },
                SecondaryAdress = new Secondaryadress[]
                {
                    new Secondaryadress
                    {
                        Adressname = "seconadre10",
                        AdressType = "Work",
                        City = new City {Name = "Aarhus V", ZipCode = new Zipcode {Code = "8210", CountryCode = "DK"}}
                    },
                    new Secondaryadress
                    {
                        Adressname = "seconadre20",
                        AdressType = "Holiday",
                        City = new City {Name = "Aarhus C", ZipCode = new Zipcode {Code = "8000", CountryCode = "DK"}}
                    },
                },
                TelephoneNumbers = new Telephonenumber[]
                {
                    new Telephonenumber {Number = "123456789", Provider = "TDC"},
                    new Telephonenumber {Number = "876543219", Provider = "Telenor"}
                }

            };

            // add jack to collection
            
            UOW.AddPerson(person2);
            await UOW.DoChanges();
            //System.Threading.Thread.Sleep(20000);
            //Person justMatt = await UOW.ReadPerson(person1);
            //Console.WriteLine(justMatt);


            // update first name
            person1.Name = "Matt";

            // should update person
            UOW.ChangePerson(person1);
            await UOW.DoChanges();

            // get Matt by his Id
            //justMatt = await UOW.ReadPerson(person1);
            // Console.WriteLine(justMatt);


            // remove matt from collection
            UOW.DeletePerson(person1);
            await UOW.DoChanges();


        }
    }

}
