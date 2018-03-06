using System.Collections.Generic;

namespace F18I4DABH2Gr24Lib
{
    public class Address
    {
        public string StreetName { get; set; }
        public string HouseNumber { get; set; }

        public City City { get; set; }
        public List<Person> Persons { get; set; }
        public List<AddressType> AddressTypes { get; set; }
    }
}