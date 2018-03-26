using System;
using DODB2_2.Model;

using System.Linq;
using System.Threading.Tasks;
using System.Net;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Newtonsoft.Json;
/// <summary>
/// In tis sollution there is taken codesample and ideas from the following tutorials:
/// https://docs.microsoft.com/da-dk/azure/cosmos-db/sql-api-dotnetcore-get-started
/// Also the the repository pattern is installed by nuGet PM
/// source: https://github.com/Crokus/cosmosdb-repo
/// </summary>
namespace DODB2_2
{

    class Program
    {
        
        private const string EndpointUri = "https://localhost:8081";

        private const string PrimaryKey =
            "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";

        private DocumentClient client;

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            try
            {
                Program p = new Program();
                p.GetStarted().Wait();
            }
            catch (DocumentClientException de)
            {
                Exception baseException = de.GetBaseException();
                Console.WriteLine("{0} error occurred: {1}, Message: {2}", de.StatusCode, de.Message,
                    baseException.Message);
            }
            catch (Exception e)
            {
                Exception baseException = e.GetBaseException();
                Console.WriteLine("Error: {0}, Message: {1}", e.Message, baseException.Message);
            }
            finally
            {
                Console.WriteLine("End of demo, press any key to exit.");
                Console.ReadKey();
            }
        }

        private async Task GetStarted()
        {
            this.client = new DocumentClient(new Uri(EndpointUri), PrimaryKey);
            //Creates DB
            await this.client.CreateDatabaseIfNotExistsAsync(new Database {Id = "DAB2_2"});
            //Creates Collection on DB
            await this.client.CreateDocumentCollectionIfNotExistsAsync(UriFactory.CreateDatabaseUri("DAB2_2"),
                new DocumentCollection {Id = "PersonIndex"});
            // create Person1
            Person person1 = new Person
            {
                Id = "007",
                PrimaryAdress = new Primaryadress
                {
                    Adressname = "adress1",
                    City = new City {Name = "Skandeborg", ZipCode = new Zipcode {Code = "8660", CountryCode = "DK"}}
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
            //upload person 1
            await this.CreateFamilyDocumentIfNotExists("DAB2_2", "PersonIndex", person1);

            //Create Person 2
            Person person2 = new Person
            {
                Id = "008",
                PrimaryAdress = new Primaryadress
                {
                    Adressname = "adress1",
                    City = new City {Name = "Aarhus N", ZipCode = new Zipcode {Code = "8200", CountryCode = "DK"}}
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
            //Upload person2
            await this.CreateFamilyDocumentIfNotExists("DAB2_2", "PersonIndex", person2);

            //Read DB for ID=007
            this.ExecuteSimpleQuery("DAB2_2", "PersonIndex");

            //update person 1
            person1.SecondaryAdress[0].AdressType = "work";

            await this.ReplaceFamilyDocument("DAB2_2", "PersonIndex", "007", person1);

            //Remove person1
            await this.DeleteFamilyDocument("DAB2_2", "PersonIndex", "007");

            // Clean up/delete the database
            await this.client.DeleteDatabaseAsync(UriFactory.CreateDatabaseUri("DAB2_2"));




        }

        private void WriteToConsoleAndPromptToContinue(string format, params object[] args)
        {
            Console.WriteLine(format, args);
            Console.WriteLine("Press any key to continue ...");
            Console.ReadKey();
        }

        //Create Operatione
        private async Task CreateFamilyDocumentIfNotExists(string databaseName, string collectionName, Person person)
        {
            try
            {
                await this.client.ReadDocumentAsync(UriFactory.CreateDocumentUri(databaseName, collectionName,
                    person.Id));
                this.WriteToConsoleAndPromptToContinue("Found {0}", person.Id);
            }
            catch (DocumentClientException de)
            {
                if (de.StatusCode == HttpStatusCode.NotFound)
                {
                    await this.client.CreateDocumentAsync(
                        UriFactory.CreateDocumentCollectionUri(databaseName, collectionName), person);
                    this.WriteToConsoleAndPromptToContinue("Created Person {0}", person.Id);
                }
                else
                {
                    throw;
                }
            }
        }

        //READ operation
        private void ExecuteSimpleQuery(string databaseName, string collectionName)
        {
            // Set some common query options
            FeedOptions queryOptions = new FeedOptions {MaxItemCount = -1};

            // Here we find the Person with ID 007
            IQueryable<Person> personQuery = this.client.CreateDocumentQuery<Person>(
                    UriFactory.CreateDocumentCollectionUri(databaseName, collectionName), queryOptions)
                .Where(f => f.Id == "007");

            // The query is executed synchronously here, but can also be executed asynchronously via the IDocumentQuery<T> interface
            Console.WriteLine("Running LINQ query...");
            foreach (Person person in personQuery)
            {
                Console.WriteLine("\tRead {0}", person);
            }

            Console.WriteLine("Press any key to continue ...");
            Console.ReadKey();
        }

        //Update Operation
        private async Task ReplaceFamilyDocument(string databaseName, string collectionName, string personName,
            Person updatedPerson)
        {
            await this.client.ReplaceDocumentAsync(
                UriFactory.CreateDocumentUri(databaseName, collectionName, personName), updatedPerson);
            this.WriteToConsoleAndPromptToContinue("Replaced Person {0}", personName);
        }

        //Delete operation
        private async Task DeleteFamilyDocument(string databaseName, string collectionName, string documentName)
        {
            await this.client.DeleteDocumentAsync(UriFactory.CreateDocumentUri(databaseName, collectionName,
                documentName));
            Console.WriteLine("Deleted Person {0}", documentName);
        }
    }
}