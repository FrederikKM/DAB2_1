using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DABHandin2._1
{
    class Person
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Type { get; set; }
        public string Email { get; set; }

        public List<TelephoneNumber> TelephoneNumbers { get; set; }

        public Address PrimaryAddress { get; set; }
        public List<Address> AlternativeAddresses { get; set; }
        public List<AddressType> AddressTypes { get; set; }
    }

    class TelephoneNumber
    {
        public string Number { get; set; }
        public string Use { get; set; }
    }

    class TelephoneCompany
    {
        public List<TelephoneNumber> TelephoneNumbers { get; set; }
        public string Company { get; set; }
    }

    class Address
    {
        public string StreetName { get; set; }
        public string HouseNumber { get; set; }

        public City City { get; set; }
        public List<Person> Persons { get; set; }
        public List<AddressType> AddressTypes { get; set; }
    }

    class City
    {
        public string Name { get; set; }
        public ZipCode ZipCode { get; set; }
    }

    class ZipCode
    {
        public string Zip { get; set; }
        public string CityName { get; set; }

        public List<CountryCode> CountryCodes { get; set; }
    }

    class CountryCode
    {
        public string code { get; set; }
    }

    class AddressType
    {
        public string Type { get; set; }

        public List<Address> Addresses { get; set; }
        public List<Person> Persons { get; set; }
    }




    class Program
    {
        static void Main(string[] args)
        {

        }
    }
}
