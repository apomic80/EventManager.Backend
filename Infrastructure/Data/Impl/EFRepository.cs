namespace EventManager.Infrastructure.Data.Impl
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using Extensions;

    public class EFRepository<T, K> 
        : IDisposable, IRepository<T, K> where T: class
    {
        private readonly DbContext context;
        private readonly DbSet<T> entitySet;

        public EFRepository(DbContext context)
        {
            this.context = context;
            this.entitySet = this.context.Set<T>();
        }

        public void Create(T entity)
        {
            this.entitySet.Add(entity);
            this.context.SaveChanges();
        }

        public T Read(K key)
        {
            return this.context.Find<T>(key);
        }

        public void Update(T entity)
        {
            this.entitySet.Update(entity);
            this.context.SaveChanges();
        }

        public void Delete(T entity)
        {
            this.entitySet.Remove(entity);
            this.context.SaveChanges();
        }

        public void Dispose()
        {
            if (this.context != null)
                this.context.Dispose();
        }
    }
}
