using MobileWorld.Core.Contracts;
using MobileWorld.Infrastructure.Data.Common;

namespace MobileWorld.Core.Services
{
    public class CarService : ICarService
    {
        private readonly IUnitOfWork unitOfWork;

        public CarService(IUnitOfWork _unitOfWork)
        {
            this.unitOfWork = _unitOfWork;
        }
    }
}