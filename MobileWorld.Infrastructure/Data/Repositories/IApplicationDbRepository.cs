using MobileWorld.Infrastructure.Data.Common;

namespace MobileWorld.Infrastructure.Data.Repositories
{
    public interface IApplicationDbRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
    }
}
