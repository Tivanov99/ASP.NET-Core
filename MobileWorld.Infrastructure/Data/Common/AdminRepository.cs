using MobileWorld.Infrastructure.Data.Identity;

namespace MobileWorld.Infrastructure.Data.Common
{
    public class AdminRepository : Repository<ApplicationUser>, IAdminRepository
    {
        private ApplicationDbContext context;

        public AdminRepository(ApplicationDbContext _context)
            : base(_context)
        {
            context = _context;
        }
    }
}
