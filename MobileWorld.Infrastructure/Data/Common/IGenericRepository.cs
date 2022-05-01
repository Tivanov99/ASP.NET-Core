namespace MobileWorld.Infrastructure.Data.Common
{
    public interface IGenericRepository
    {
        IQueryable GetAsQueryable<TEntity>() where TEntity : class;

        IEnumerable<TEntity> GetAll<TEntity>() where TEntity : class;

        TEntity GetById<TEntity>(object id) where TEntity : class;

        void Insert<TEntity>(TEntity obj) where TEntity : class;

        void Update<TEntity>(TEntity entity) where TEntity : class;

        void Delete<TEntity>(object id) where TEntity : class;
    }
}
