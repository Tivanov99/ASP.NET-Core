using Microsoft.EntityFrameworkCore;

namespace MobileWorld.Infrastructure.Data.Common
{
    public class GenericRepository : IGenericRepository, IDisposable 
    {
        private ApplicationDbContext context;

        public GenericRepository()
        {
            
        }

        protected DbContext Context { get; set; }

        public IEnumerable<TEntity> GetAll()
        {
            return this.dbSet.ToList();
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

        public IQueryable GetAsQueryable<TEntity>() where TEntity : class
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetAll<TEntity>() where TEntity : class
        {
            throw new NotImplementedException();
        }

        public TEntity? GetById<TEntity>(object id) where TEntity : class
        {
            if (id != null)
            {
                return DbSet<TEntity>().Find(id);
            }

            return null;
        }

        public void Insert<TEntity>(TEntity obj) where TEntity : class
        {
            if (obj != null)
            {
                DbSet<TEntity>().Add(obj);
            }
        }

        public void Update<TEntity>(TEntity entity) where TEntity : class
        {
            DbSet<TEntity>().Attach(entity);
           context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete<TEntity>(object id) where TEntity : class
        {
            TEntity entity = DbSet<TEntity>()
                .Find(id);

            if (entity != null)
            {
                DbSet<TEntity>().Remove(entity);
            }
        }

        private DbSet<TEntity> DbSet<TEntity>() where TEntity : class
        {
            return context.Set<TEntity>();
        }
    }
}
