namespace EventManager.Infrastructure.Data.Impl
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class EFModelReader<T> : IModelReader<T> where T : class
    {
        private readonly DbContext context;
        private readonly DbSet<T> entitySet;

        public EFModelReader(DbContext context)
        {
            this.context = context;
            this.entitySet = this.context.Set<T>();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.entitySet.AsNoTracking<T>().AsEnumerable().GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public Type ElementType
        {
            get { return (this.entitySet.AsNoTracking() as IQueryable).ElementType; }
        }

        public System.Linq.Expressions.Expression Expression
        {
            get { return (this.entitySet.AsNoTracking() as IQueryable).Expression; }
        }

        public IQueryProvider Provider
        {
            get { return (this.entitySet.AsNoTracking() as IQueryable).Provider; }
        }
    }
}
