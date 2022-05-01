using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace MobileWorld.Infrastructure.Data.Common
{
    public abstract class Repository : IRepository, IDisposable 
    {
        protected DbContext Context { get; set; }

        protected DbSet<T> DbSet<T>() where T : class
        {
            return this.Context.Set<T>();
        }

        public async Task<TEntity?> GetByIdAsync<TEntity>(object id) where TEntity : class
        {
            return await DbSet<TEntity>()
                .FindAsync(id);
        }

        public IQueryable<TEntity> GetAsQueryable<TEntity>() where TEntity : class
        {
            return DbSet<TEntity>().AsQueryable();
        }

        public IEnumerable<TEntity> GetAll<TEntity>() where TEntity : class
        {
            return DbSet<TEntity>();
        }

        public TEntity? GetById<TEntity>(object id) where TEntity : class
        {
            if (id != null)
            {
                return DbSet<TEntity>()
                    .Find(id);
            }

            return null;
        }
        public async Task AddAsync<TEntity>(TEntity entity) where TEntity : class
        {
            if (entity != null)
            {
                await DbSet<TEntity>().AddAsync(entity);
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

        public async Task DeleteAsync<TEntity>(object id) where TEntity : class
        {
            TEntity? entity = await GetByIdAsync<TEntity>(id);

            if(entity!=null)
            {
                Delete<TEntity>(entity);
            }
        }


        public void Dispose()
        {
            this.Context.Dispose();
        }
        
    }
}
