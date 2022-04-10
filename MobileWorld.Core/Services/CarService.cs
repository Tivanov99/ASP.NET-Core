using MobileWorld.Core.Contracts;
using MobileWorld.Core.Dto;
using MobileWorld.Core.Models;
using MobileWorld.Core.ViewModels;
using MobileWorld.Infrastructure.Data.Common;
using MobileWorld.Infrastructure.Data.Models;

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