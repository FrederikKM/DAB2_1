using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAB2_2RDB.Models
{
    public class Person : BaseEntity
    {
        [Required]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Context { get; set; }
        public string Email { get; set; }

        public ICollection<PhoneNumber> PhoneNumbers { get; set; } = new List<PhoneNumber>();
    }
}
