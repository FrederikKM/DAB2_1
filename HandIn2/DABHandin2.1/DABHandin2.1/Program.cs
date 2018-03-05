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
        {   PhoneCompany tdc = new PhoneCompany("TDC");
            PhoneCompany oister = new PhoneCompany("Oister");
            PhoneCompany telmore = new PhoneCompany("Temore");
            PhoneCompany telenor = new PhoneCompany("Telenor");
            Phone phone1=new Phone("87654321",oister);
            Phone phone2 = new Phone("12345678", tdc);
            Phone phone3 = new Phone("11111111", telmore);
            Phone phone4 = new Phone("22222222", telenor);
            List<Phone> phone = new List<Phone> {phone1, phone2,phone3,phone4};
            HelpClass adr1 = new HelpClass(new Adress("Adress1"), "private");
            HelpClass adr2 = new HelpClass(new Adress("Adress2"), "Office");
            HelpClass adr3 = new HelpClass(new Adress("Adress3"), "School");
            HelpClass adr4 = new HelpClass(new Adress("Adress4"), "Center");
            Adress registeredAdress =new Adress("HomeAdress");
            List <HelpClass> adresses = new List<HelpClass> {adr1, adr2, adr3, adr4};
            Person pers = new Person("Nabo", "Nabo@oban.dk",registeredAdress, adresses, phone);
            pers.PresentPerson();

            phone1 = new Phone("44444444", oister);
            phone2 = new Phone("55555555", tdc);
            phone3 = new Phone("66666666", telmore);
            phone4 = new Phone("77777777", telenor);
            phone = new List<Phone> { phone1, phone2, phone3, phone4 };
            adr1 = new HelpClass(new Adress("Adress6"), "HolidayHome");
            adr2 = new HelpClass(new Adress("Adress7"), "Mall");
            adr3 = new HelpClass(new Adress("Adress8"), "School");
            adr4 = new HelpClass(new Adress("Adress9"), "Bank");
            registeredAdress = new Adress("WhereILive");
            adresses = new List<HelpClass> { adr1, adr2, adr3, adr4 };

            pers = new Person("Another person", "person2@asd.dk", registeredAdress, adresses, phone);
            pers.PresentPerson();
        }
    }
}
