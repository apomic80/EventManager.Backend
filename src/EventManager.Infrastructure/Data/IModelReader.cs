using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManager.Infrastructure.Data
{
    public interface IModelReader<T> 
        : IQueryable<T> where T : class
    {
    }
}
