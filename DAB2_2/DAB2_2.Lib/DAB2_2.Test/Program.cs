using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAB2_2.Lib;

namespace DAB2_2.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new DABHandin_2_2Entities();
            var uow = new UnitOfWork(context);

            uow.AddressRepository.Create(new Address
            {
                City = new City
                {
                    Name = "Aarhus",
                    Postnummer = "8200",
                    ZipCode = new ZipCode
                    {
                        Zip = "8200",
                    }
                },
                HouseNumber = "Housenumber",
                StreetName = "streetname"

            });

            uow.Save();

            Console.WriteLine(uow.AddressRepository.Get(0).HouseNumber);


        }
    }
}
