namespace EventManager.Infrastructure.Extensions
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public static class EFExtensions
    {
        public static TEntity Find<TEntity>(this DbContext context, params object[] keyValues) where TEntity : class
        {
            var entityType = context.Model.FindEntityType(typeof(TEntity));
            var keys = entityType.GetKeys();
            var entries = context.ChangeTracker.Entries<TEntity>();
            var parameter = Expression.Parameter(typeof(TEntity), "x");
            IQueryable<TEntity> query = context.Set<TEntity>();

            //first, check if the entity exists in the cache
            var i = 0;

            //iterate through the key properties
            foreach (var property in keys.SelectMany(x => x.Properties))
            {
                var keyValue = keyValues[i];

                //try to get the entity from the local cache
                entries = entries.Where(e => keyValue.Equals(e.Property(property.Name).CurrentValue));

                //build a LINQ expression for loading the entity from the store
                var expression = Expression.Lambda(
                        Expression.Equal(
                            Expression.Property(parameter, property.Name),
                            Expression.Constant(keyValue)),
                        parameter) as Expression<Func<TEntity, bool>>;

                query = query.Where(expression);

                i++;
            }

            var entity = entries.Select(x => x.Entity).FirstOrDefault();

            if (entity != null)
            {
                return entity;
            }

            //second, try to load the entity from the data store
            entity = query.FirstOrDefault();

            return entity;
        }
    }
}
