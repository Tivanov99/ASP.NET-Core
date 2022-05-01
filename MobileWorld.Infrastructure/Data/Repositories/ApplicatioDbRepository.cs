using MobileWorld.Infrastructure.Data.Common;

namespace MobileWorld.Infrastructure.Data.Repositories
{
    public class ApplicatioDbRepository : Repository, IApplicationDbRepository
    {
        public ApplicatioDbRepository(ApplicationDbContext context)
        {
            Context = context;
        }
    }
}
