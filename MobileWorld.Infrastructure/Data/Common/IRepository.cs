using Microsoft.EntityFrameworkCore;

namespace MobileWorld.Infrastructure.Data.Common
{
    public interface IRepository<TEntity> where TEntity : class
    {
        DbSet<WantedEntity> Set<WantedEntity>() where WantedEntity : class;

        void UserStoredProdecude(string sqlCommand, params object[] parameters);

        TEntity GetById(object id);

        IQueryable<TEntity> GetAsQueryable();

        void Update(TEntity entityToUpdate);

        void Delete(TEntity entityToDelete);

        void Delete(object id);

        void Insert(TEntity entity);
    }
}
