using MobileWorld.Infrastructure.Data.Identity;

namespace MobileWorld.Infrastructure.Data.Common
{
    public class UserRepository : GenericRepository<ApplicationUser>, IUserRepository
    {
        public UserRepository(ApplicationDbContext _context) :
            base(_context)
        {
        }
    }
}
