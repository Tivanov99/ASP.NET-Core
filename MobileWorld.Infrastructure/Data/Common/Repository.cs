using Microsoft.EntityFrameworkCore;
using System;

namespace MobileWorld.Infrastructure.Data.Common
{
    public class Repository : IRepository, IDisposable
    {
        private readonly ApplicationDbContext dbContext;

        public Repository(ApplicationDbContext _context)
        {
            this.dbContext = _context;
        }

        public void Add<T>(T entity) where T : class
        {
            this.DbSet<T>().Add(entity);
        }

        public IQueryable<T> All<T>() where T : class
        {
            return this.DbSet<T>().AsQueryable();
        }

        public void Delete<TEntity>(TEntity entity) where TEntity : class
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            this.DbSet<TEntity>().Remove(entity);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.dbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public int SaveChanges()
        {
            return this.dbContext.SaveChanges();
        }

        private DbSet<T> DbSet<T>() where T : class
        {
            return dbContext.Set<T>();
        }

        private bool disposed = false;

    }
}
