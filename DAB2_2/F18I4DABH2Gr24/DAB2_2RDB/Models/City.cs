using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAB2_2RDB.Models
{
    public class City : BaseEntity
    {
        public string Name { get; set; }
        public string ZipCode { get; set; }

        public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

        public int CountryCodeId { get; set; }
    }
}
