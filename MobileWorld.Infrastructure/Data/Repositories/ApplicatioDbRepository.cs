using MobileWorld.Infrastructure.Data.Common;

namespace MobileWorld.Infrastructure.Data.Repositories
{
    public class ApplicatioDbRepository : Repository, IApplicatioDbRepository
    {
        public ApplicatioDbRepository(ApplicationDbContext context)
        {
            Context = context;
        }
    }
}
