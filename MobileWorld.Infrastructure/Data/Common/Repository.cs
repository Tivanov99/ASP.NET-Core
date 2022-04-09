using Microsoft.EntityFrameworkCore;

namespace MobileWorld.Infrastructure.Data.Common
{
    public class Repository : IRepository
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



        public int SaveChanges()
        {
            return this.dbContext.SaveChanges();
        }

        private DbSet<T> DbSet<T>() where T : class
        {
            return dbContext.Set<T>();
        }
    }
}
