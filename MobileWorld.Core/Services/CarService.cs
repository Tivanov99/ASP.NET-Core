using MobileWorld.Core.Contracts;
using MobileWorld.Infrastructure.Data.Common;
using MobileWorld.Infrastructure.Data.Repositories;

namespace MobileWorld.Core.Services
{
    public class CarService : ICarService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CarService(IUnitOfWork unit)
        {
            this._unitOfWork = unit;
        }
    }
}