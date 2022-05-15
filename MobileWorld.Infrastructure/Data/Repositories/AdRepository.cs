using MobileWorld.Infrastructure.Data.Common;
using MobileWorld.Infrastructure.Data.Models;
using MobileWorld.Infrastructure.Data.Repositories.Contracts;

namespace MobileWorld.Infrastructure.Data.Repositories
{
    public class AdRepository : Repository<Ad>, IAdRepository
    {
        public AdRepository(ApplicationDbContext context) :
            base(context)
        {
        }
    }
}
