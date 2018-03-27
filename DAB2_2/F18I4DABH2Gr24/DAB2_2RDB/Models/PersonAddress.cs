using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAB2_2RDB.Models
{
    public class PersonAddress
    {
        public int PersonId { get; set; }
        public virtual Person Person { get; set; }

        public int AddressId { get; set; }
        public virtual Address Address { get; set; }
    }
}
