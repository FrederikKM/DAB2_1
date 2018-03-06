using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DABHandin2._1
{
    class Person
    {
        public Context PersonContext { get; set; }
        public Mail PersonMail { get; set; }
        public List<AddressType> AddressTypes { get; set; }
        public List<Phone> PersonPhone { get; set; }
        public Address RegisteredAddress { get; set; }

        public Person(string personContext,string mailAdress,Address registerAddress,List<AddressType> helpClass,List<Phone> phoneNums)
        {
            PersonContext=new Context(personContext);
            PersonMail = new Mail(mailAdress);
            AddressTypes = helpClass;
            PersonPhone = phoneNums;
            RegisteredAddress = registerAddress;
        }

        public void PresentPerson()
        {
            Console.WriteLine("The persons Context is: " + PersonContext.PersonContext);
            Console.WriteLine("Her/his Registered Address is: "+ RegisteredAddress.AdressName);
            Console.WriteLine("Her/his Mailadress is : " +PersonMail.MailAdress);
            Console.WriteLine("");
            Console.WriteLine("He/She is connected to following adresses:");
            foreach (var address in AddressTypes)
            {
                Console.WriteLine("AdressType: " + address.Type + " is at: " + address.Address.AdressName);
            }

            Console.WriteLine("");
            Console.WriteLine("He/She has the following phoneNumbers:");
            foreach (var numbers in PersonPhone)
            {
                Console.WriteLine("PhoneNumber: " + numbers.PhoneNumber + " And the privider is named: "+ numbers.Provider.CompanyName);
            }
            Console.WriteLine("_______________________________________________________________");
            Console.WriteLine("");

        }

    }
}
