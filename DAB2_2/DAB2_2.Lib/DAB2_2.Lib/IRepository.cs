namespace DAB2_2.Lib
{
    public interface IRepository<T>
    {
        void Create(T t);
        T Get(int id);
        void Remove(int id);
        void Update(int id, T t);
    }
}