using System.ComponentModel.DataAnnotations;

namespace DAB2_2RDB.Models
{
    public class PhoneNumber : BaseEntity
    {
        [Required]
        public string Number { get; set; }
        public string Usage { get; set; }

        public virtual int PersonId { get; set; }
        public virtual Person Person { get; set; }

        public virtual TelephoneCompany TelephoneCompany { get; set; }
    }
}