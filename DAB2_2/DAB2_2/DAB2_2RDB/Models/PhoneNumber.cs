using System.ComponentModel.DataAnnotations;

namespace DAB2_2RDB.Models
{
    public class PhoneNumber : BaseEntity
    {
        [Required]
        public string Number { get; set; }
        public string Usage { get; set; }

        public int PersonId { get; set; }
        public Person Person { get; set; }

        public int TelephoneCompanyId { get; set; }
        public TelephoneCompany TelephoneCompany { get; set; } = null;
    }
}