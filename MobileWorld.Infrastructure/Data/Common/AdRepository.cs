using MobileWorld.Infrastructure.Data.Models;

namespace MobileWorld.Infrastructure.Data.Common
{
    public class AdRepository : Repository<Car> ,IRepository<Car>
    {
        public AdRepository(ApplicationDbContext context)
            : base(context)
        {

        }
    }
}
