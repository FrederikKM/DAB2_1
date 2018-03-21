using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAB2_2RDB.Models
{
    public class TelephoneCompany : BaseEntity
    {

        [Required]
        public string CompanyName { get; set; }

        public ICollection<PhoneNumber> PhoneNumbers { get; set; } = new List<PhoneNumber>();
    }
}
