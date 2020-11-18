using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GpLib.Persistence.EventStore
{
    public interface IReadModel<T> : IDisposable
    {
        IQueryable<T> Filter(Expression<Func<T, bool>> expression);
        IQueryable<T> GetAll();
        Task<IQueryable<T>> FilterAsync(Expression<Func<T, bool>> expression);
        Task<IQueryable<T>> GetAllAsync();
    }
}
