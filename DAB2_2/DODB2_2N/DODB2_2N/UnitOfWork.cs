using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using DocumentDB.Repository;
using DODB2_2N.Model;
using Microsoft.Azure.Documents.Client.TransientFaultHandling;


namespace DODB2_2N
{

    public class UnitOfWork : IDisposable
    {

        private readonly DocumentDbRepository <Person >_repo;
        private List<Person> NewOnes= new List<Person>();
        private List<Person> UpdatedOnes = new List<Person>();
        private List<Person> RemovedOnes = new List<Person>();
        
        public UnitOfWork(DocumentDbRepository <Person> repo)
        {
            _repo = repo;
            this.WriteToConsoleAndPromptToContinue("Added repo to UOW {0}","hello");

        }

        public void AddPerson(Person input)
        {
            NewOnes.Add(input);
            this.WriteToConsoleAndPromptToContinue("Added {0} to queue", input.Name);
        }

        public async Task<Person> ReadPerson(Person input)
        {
            return await _repo.GetByIdAsync(input.Id);
            //this.WriteToConsoleAndPromptToContinue("added {0} to Readqueue ", input.Id);
        }

        public void ChangePerson(Person input)
        {
            UpdatedOnes.Add(input);
            this.WriteToConsoleAndPromptToContinue("added {0} to change queue", input.Name);
        }

        public void DeletePerson(Person input)
        {
            RemovedOnes.Add(input);
            this.WriteToConsoleAndPromptToContinue("Added {0} to Deletequeue", input.Name);
        }

        public async Task DoChanges()
        {
            this.WriteToConsoleAndPromptToContinueasd("Do changes to DB{0}", "");
            foreach (var news in NewOnes)
            {
                await _repo.AddOrUpdateAsync(news);
                //this.WriteToConsoleAndPromptToContinue("Added {0} to DB", news.Name);

            }

            foreach (var updates in UpdatedOnes)
            {
                await _repo.AddOrUpdateAsync(updates);
                //this.WriteToConsoleAndPromptToContinue("changed {0} to DB", updates.Name);

            }

            foreach (var removes in RemovedOnes)
            {
                await _repo.RemoveAsync(removes.Id);
                //this.WriteToConsoleAndPromptToContinue("Removed {0} to DB", removes.Name);
            }
            this.WriteToConsoleAndPromptToContinueasd("Did changes to DB{0}", "");

        }


        private void WriteToConsoleAndPromptToContinueasd(string format, params object[] args)
        {
            Console.WriteLine(format, args);
            Console.WriteLine("press key to proceed...");
            Console.ReadKey();
        }
        private void WriteToConsoleAndPromptToContinue(string format, params object[] args)
        {
            Console.WriteLine(format, args);
            Console.WriteLine("__________________________________________________");
            //Console.ReadKey();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}