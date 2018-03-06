using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DABHandin2._1
{
    class Country
    {
        public List<Address> Adresses { get; set; }
        public string CountryCode { get; set; }

        public Country(List<Address> adresses, string countryCode)
        {
            Adresses = adresses;
            CountryCode = countryCode;
        }
    }
}
