namespace EventManager.Infrastructure.Data
{
    public interface IRepository<T, K>
        where T : class
    {
        void Create(T entity);
        void Delete(T entity);
        T Read(K key);
        void Update(T entity);
    }
}