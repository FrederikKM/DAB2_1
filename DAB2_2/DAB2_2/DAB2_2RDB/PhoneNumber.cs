namespace DAB2_2RDB
{
    public class PhoneNumber : BaseEntity
    {
        public string Usage { get; set; }

        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}