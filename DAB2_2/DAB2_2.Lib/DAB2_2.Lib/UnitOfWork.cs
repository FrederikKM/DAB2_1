namespace DAB2_2.Lib
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DABHandin_2_2Entities _context;

        public UnitOfWork(DABHandin_2_2Entities context)
        {
            _context = context;
            AddressRepository = new Repository<Address>(context);
        }

        public async void Save()
        {
            await _context.SaveChangesAsync();
        }

        public IRepository<Address> AddressRepository { get;  }

        public IRepository<AddressType> AddressTypeRepository { get; set; }
        public IRepository<City> CityRepository { get; set; }
        public IRepository<CountryCode> CountryCodeRepository { get; set; }
        public IRepository<Person> PersonRepository { get; set; }
        public IRepository<TelephoneCompany> TelephoneCompanyRepository { get; set; }
        public IRepository<TelephoneNumber> TelephoneNumberRepository { get; set; }
        public IRepository<ZipCode> ZipCodeRepository { get; set; }






    }
}