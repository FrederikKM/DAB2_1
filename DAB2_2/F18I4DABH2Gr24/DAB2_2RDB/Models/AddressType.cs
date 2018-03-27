using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAB2_2RDB.Models
{
    public class AddressType : BaseEntity
    {
        public string Type { get; set; }
        public virtual Address Address { get; set; }
    }
}
