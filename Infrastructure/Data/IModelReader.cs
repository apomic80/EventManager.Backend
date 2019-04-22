namespace EventManager.Infrastructure.Data
{
    using System.Linq;

    public interface IModelReader<T> 
        : IQueryable<T> where T : class
    {
    }
}
