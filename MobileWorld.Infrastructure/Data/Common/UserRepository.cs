using MobileWorld.Infrastructure.Data.Identity;

namespace MobileWorld.Infrastructure.Data.Common
{
    public class UserRepository : Repository<ApplicationUser>, IUserRepository
    {
        public UserRepository(ApplicationDbContext _context) :
            base(_context)
        {
        }
    }
}
