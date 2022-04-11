using MobileWorld.Infrastructure.Data.Models;

namespace MobileWorld.Infrastructure.Data.Common
{
    public class TownRepository : Repository<Town>, ITownRepository
    {
        public TownRepository(ApplicationDbContext _context)
            : base(_context)
        {
        }
    }
}
