using Microsoft.EntityFrameworkCore;
using System;

namespace MobileWorld.Infrastructure.Data.Common
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>, IDisposable where TEntity : class
    {
        private ApplicationDbContext context;
        private DbSet<TEntity> dbSet;

        public GenericRepository(ApplicationDbContext _context)
        {
            this.context = _context;
            this.dbSet = context.Set<TEntity>();
        }

        public void Delete(object id)
        {
            TEntity entity = dbSet.Find(id);

            if (entity != null)
            {
                Delete(entity);
            }
        }

        public IEnumerable<TEntity> GetAll()
        {
            return this.dbSet.ToList();
        }

        public TEntity GetById(object id)
        {
            return this.dbSet.Find(id);
        }

        public void Insert(TEntity entity)
        {
            this.dbSet.Add(entity);
        }

        public void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            this.context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        private bool disposed = false;

        protected void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IQueryable<TEntity> GetAsQueryable()
        {
            return this.dbSet.AsQueryable();
        }
    }
}
