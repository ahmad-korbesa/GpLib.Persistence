using GpLib.Persistence.Repo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GpLib.Persistence.EFStorage
{
    public class EFStorage<T> : IStorage<T> where T : class
    {
        protected DbContext _dbContext;

        public EFStorage(DbContext dbContext) =>
            _dbContext = dbContext;

        public virtual void Add(T item) => _dbContext.Set<T>().Add(item);
  
        public virtual void Delete(T item) => _dbContext.Set<T>().Remove(item);
  
        public virtual void Update(T item) => _dbContext.Entry(item).State = EntityState.Modified;

        public virtual int SaveChanges() => _dbContext.SaveChanges();

        public virtual Task<int> SaveChangesAsync() => _dbContext.SaveChangesAsync();

        public virtual IQueryable<T> Filter(Expression<Func<T, bool>> expression)
            => _dbContext.Set<T>().Where(expression);

        public virtual T Get(params object[] id)
            => _dbContext.Set<T>().Find(id);

        public virtual IQueryable<T> GetAll() => _dbContext.Set<T>();

        #region Dispose

        bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;
            if (disposing)
            {
                _dbContext?.Dispose();
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
