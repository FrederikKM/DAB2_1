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

        public PrimaryAddress PrimaryAddress { get; set; }

        public virtual ICollection<PhoneNumber> PhoneNumbers { get; set; } = new List<PhoneNumber>();
        public virtual ICollection<PersonAddress> PersonAddresses { get; set; } = new List<PersonAddress>();
    }

    public class PrimaryAddress : BaseEntity
    {
        public AddressName AddressName { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
    }

    public class AddressName
    {
        public string StreetName { get; set; }
        public string HouseNumber { get; set; }
    }
}
