using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GpLib.Persistence.Repo
{
    public class RepositoryBase<T> : IRepository<T> where T : class
    {
        protected IStorage<T> _storage;

        public RepositoryBase(IStorage<T> storage) => _storage = storage;

        public virtual T Get(params object[] id) => _storage.Get(id);

        public virtual IQueryable<T> GetAll() => _storage.GetAll();

        public virtual IQueryable<T> Filter(Expression<Func<T, bool>> expression) => _storage.Filter(expression);

        public virtual void Add(T item) => _storage.Add(item);

        public virtual void Delete(T item) => _storage.Delete(item);

        public virtual void Update(T item) => _storage.Update(item);

        public virtual int SaveChanges() => _storage.SaveChanges();

        public virtual Task<int> SaveChangesAsync() => _storage.SaveChangesAsync();

        #region Dispose

        bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;
            if (disposing)
            {
                _storage?.Dispose();
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }



        #endregion
    }
}
