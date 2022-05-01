using MobileWorld.Core.Contracts;
using MobileWorld.Infrastructure.Data.Repositories;

namespace MobileWorld.Core.Services
{
    public class CarService : ICarService
    {
        private readonly IApplicationDbRepository _reop;

        public CarService(IApplicationDbRepository repo)
        {
            this._reop = repo;
        }
    }
}