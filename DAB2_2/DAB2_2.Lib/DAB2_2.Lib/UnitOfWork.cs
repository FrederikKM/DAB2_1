namespace DAB2_2.Lib
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DAB2_2DBContext _context;

        public UnitOfWork(DAB2_2DBContext context)
        {
            _context = context;
            AddressRepository = new Repository<Address>(context);
        }

        public async void Save()
        {
            await _context.SaveChangesAsync();
        }

        public IRepository<Address> AddressRepository { get; set; }
        public IRepository<AddressType> AddressTypeRepository { get; set; }
        public IRepository<City> CityRepository { get; set; }
        public IRepository<CountryCode> CountryCodeRepository { get; set; }
        public IRepository<Person> PersonRepository { get; set; }
        public IRepository<TelephoneCompany> TelephoneCompanyRepository { get; set; }
        public IRepository<TelephoneNumber> TelephoneNumberRepository { get; set; }
        public IRepository<ZipCode> ZipCodeRepository { get; set; }






    }
}