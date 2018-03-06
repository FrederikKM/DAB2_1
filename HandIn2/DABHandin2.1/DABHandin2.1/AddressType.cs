using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DABHandin2._1
{
    class AddressType
    {
        public String Type { get; set; }
        public Address Address { get; set; }

        public AddressType(Address Address, String type)
        {
            Type = type;
            Address = Address;
        }
    }
}
