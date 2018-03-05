using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DABHandin2._1
{
    class PhoneCompany
    {
        public String CompanyName { get; set; }
        public int BillBase { get; set; }

        public PhoneCompany(String companyName)
        {
            CompanyName = companyName;
        }
    }
}
