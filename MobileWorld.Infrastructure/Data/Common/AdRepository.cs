using MobileWorld.Infrastructure.Data.Models;

namespace MobileWorld.Infrastructure.Data.Common
{
    public class AdRepository : Repository<Ad> , IAdRepository
    {
        public AdRepository(ApplicationDbContext context)
            : base(context)
        {

        }
    }
}
