using MobileWorld.Infrastructure.Data.Models;

namespace MobileWorld.Infrastructure.Data.Common
{
    public class CarRepository : Repository<Car>, ICarRepository
    {
        public CarRepository(ApplicationDbContext context)
            :base(context)
        {

        }
    }
}
