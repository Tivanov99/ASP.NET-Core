using MobileWorld.Infrastructure.Data.Models;

namespace MobileWorld.Infrastructure.Data.Common
{
    public class CarRepository : Repository<Car>, IRepository<Car>
    {
        public CarRepository(ApplicationDbContext context)
            :base(context)
        {

        }
    }
}
