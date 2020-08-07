using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GpLib.Persistence.Repo
{
    public interface IRepository<T> : IDisposable where T : class
    {
        T Get(params object[] id);

        IQueryable<T> GetAll();

        IQueryable<T> Filter(Expression<Func<T, bool>> expression);

        void Add(T item);

        void Update(T item);

        void Delete(T item);

        int SaveChanges();

        Task<int> SaveChangesAsync();

    }
}
