using System.Linq;

namespace MobileWorld.Infrastructure.Data.Common
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAsQueryable();

        IEnumerable<TEntity> GetAll();

        TEntity GetById(object id);

        void Insert(TEntity obj);

        void Update(TEntity obj);

        void Delete(object id);
    }
}
