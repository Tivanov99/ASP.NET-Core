using System.Linq;

namespace MobileWorld.Infrastructure.Data.Common
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAllAsQueryable();

        IEnumerable<TEntity> GetAll();

        TEntity GetById(object id);

        void Insert(TEntity obj);

        void Update(TEntity obj);

        void Delete(object id);

        void Delete(TEntity entityToDelete);
    }
}
