using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAB2_2RDB.Models
{
    public class CountryCode : BaseEntity
    {
        public string Code { get; set; }
        public virtual City City { get; set; }
    }
}
