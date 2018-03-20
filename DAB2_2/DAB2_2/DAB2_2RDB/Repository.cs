using Microsoft.EntityFrameworkCore;

namespace DAB2_2RDB
{
    public class Repository<T> where T : BaseEntity
    {
        private readonly Dab2_2RdbContext _context;

        public Repository(Dab2_2RdbContext context)
        {
            _context = context;
        }

        public void Create(T t)
        {
            _context.Entry<T>(t).State = EntityState.Added;
            _context.SaveChanges();
        }

        public T Read(int id)
        {
            return _context.Find<T>(id);
        }
        public void Update(int id, T t)
        {
            _context.Entry<T>(t).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public void Delete(T t)
        {
            _context.Entry<T>(t).State = EntityState.Deleted;
            _context.SaveChanges();
        }
    }
}