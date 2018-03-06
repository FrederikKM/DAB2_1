using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DABHandin2._1
{
    class Program
    {
        static void Main(string[] args)
        {   var tdc = new PhoneCompany("TDC");
            var oister = new PhoneCompany("Oister");
            var telmore = new PhoneCompany("Temore");
            var telenor = new PhoneCompany("Telenor");
            var phone1= new Phone("87654321",oister);
            var phone2 = new Phone("12345678", tdc);
            var phone3 = new Phone("11111111", telmore);
            var phone4 = new Phone("22222222", telenor);
            var phone = new List<Phone> {phone1, phone2,phone3,phone4};
            var adr1 = new AddressType(new Address("Adress1"), "private");
            var adr2 = new AddressType(new Address("Adress2"), "Office");
            var adr3 = new AddressType(new Address("Adress3"), "School");
            var adr4 = new AddressType(new Address("Adress4"), "Center");
            var registeredAdress = new Address("HomeAdress");
            var adresses = new List<AddressType> {adr1, adr2, adr3, adr4};
            var pers = new Person("Nabo", "Nabo@oban.dk",registeredAdress, adresses, phone);

            pers.PresentPerson();

            phone1 = new Phone("44444444", oister);
            phone2 = new Phone("55555555", tdc);
            phone3 = new Phone("66666666", telmore);
            phone4 = new Phone("77777777", telenor);
            phone = new List<Phone> { phone1, phone2, phone3, phone4 };
            adr1 = new AddressType(new Address("Adress6"), "HolidayHome");
            adr2 = new AddressType(new Address("Adress7"), "Mall");
            adr3 = new AddressType(new Address("Adress8"), "School");
            adr4 = new AddressType(new Address("Adress9"), "Bank");
            registeredAdress = new Address("WhereILive");
            adresses = new List<AddressType> { adr1, adr2, adr3, adr4 };

            pers = new Person("Another person", "person2@asd.dk", registeredAdress, adresses, phone);
            pers.PresentPerson();
        }
    }
}
