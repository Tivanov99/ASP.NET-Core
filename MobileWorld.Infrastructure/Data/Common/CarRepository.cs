using MobileWorld.Infrastructure.Data.Models;

namespace MobileWorld.Infrastructure.Data.Common
{
    public class CarRepository : GenericRepository<Car>, ICarRepository
    {
        public CarRepository(ApplicationDbContext context)
            :base(context)
        {

        }
    }
}
