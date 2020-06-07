﻿using GpLib.Persistence.Repo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GpLib.Persistence.EFCoreStorage
{
    public class EFCoreStorage<T> : IStorage<T> where T : class
    {
        protected DbContext _dbContext;

        public EFCoreStorage(DbContext dbContext) =>
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
