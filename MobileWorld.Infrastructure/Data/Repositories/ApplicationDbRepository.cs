using MobileWorld.Infrastructure.Data.Common;

namespace MobileWorld.Infrastructure.Data.Repositories
{
    public class ApplicationDbRepository<TEntity> : Repository<TEntity>, IApplicationDbRepository<TEntity> where TEntity : class
    {
        public ApplicationDbRepository(ApplicationDbContext context)
            :base(context)
        {
        }
    }
}
