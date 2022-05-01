using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace MobileWorld.Infrastructure.Data.Common
{
    public class GenericRepository : IGenericRepository, IDisposable 
    {
        protected DbContext Context { get; set; }

        protected DbSet<T> DbSet<T>() where T : class
        {
            return this.Context.Set<T>();
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
            this.DbSet<TEntity>().Update(entity);
        }

        public void Delete<TEntity>(TEntity entity) where TEntity : class
        {
            EntityEntry entry =
                this.Context.Entry(entity);

            if (entity != null && entry.State == EntityState.Detached)
            {
                this.DbSet<TEntity>().Attach(entity);
            }
            entry.State = EntityState.Deleted;
        }

        public void Dispose()
        {
            this.Context.Dispose();
        }
    }
}
