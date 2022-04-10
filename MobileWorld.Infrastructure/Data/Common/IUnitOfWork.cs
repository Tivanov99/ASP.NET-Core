using MobileWorld.Infrastructure.Data.Models;

namespace MobileWorld.Infrastructure.Data.Common
{
    public interface IUnitOfWork
    {
        IRepository<Ad> AdRepository { get;  }

        IRepository<Car> CarRepository { get;  }

        void Save();

        //IRepository<Engine> EngineRepository { get; set; }

    }
}
