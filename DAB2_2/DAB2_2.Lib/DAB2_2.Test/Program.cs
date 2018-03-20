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
            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;



            var context = new DAB2_2DBContext();
            var uow = new UnitOfWork(context);

            uow.ZipCodeRepository.Create(new ZipCode()
            {
                Zip = "8541",
                CountryCode = new CountryCode()
                {
                    Code = "DK"
                }
            });

            uow.Save();

            Console.WriteLine(uow.AddressRepository.Get(0).HouseNumber);

        }
    }
}
