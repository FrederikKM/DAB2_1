using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DABHandin2._1
{
    class Phone
    {
        

        public String PhoneNumber { get; set; }
        public PhoneCompany Provider { get; set; }

        public Phone(String phoneNumber,PhoneCompany provider)
        {
            PhoneNumber = phoneNumber;
            Provider = provider;
        }

    }
}
