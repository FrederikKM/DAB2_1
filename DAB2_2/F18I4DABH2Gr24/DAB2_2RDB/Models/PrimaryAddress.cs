namespace DAB2_2RDB.Models
{
    public class PrimaryAddress : BaseEntity
    {
        public AddressName AddressName { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
    }
}