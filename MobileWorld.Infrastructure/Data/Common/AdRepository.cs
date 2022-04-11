using MobileWorld.Infrastructure.Data.Models;

namespace MobileWorld.Infrastructure.Data.Common
{
    public class AdRepository : Repository<Ad>, IAdRepository
    {
        private ApplicationDbContext context;
        public AdRepository(ApplicationDbContext _context)
            : base(_context)
        {
            context = _context;
        }

        public IQueryable<Ad> GetAdByIdAsIQueryable(string id)
            => context.Ads.Where(ad => ad.Id == id);
    }
}
