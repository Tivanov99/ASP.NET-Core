using MobileWorld.Infrastructure.Data.Models;

namespace MobileWorld.Infrastructure.Data.Common
{
    public interface IUnitOfWork : IDisposable
    {
        IAdRepository AdRepository { get;  }

        ICarRepository CarRepository { get;  }

        IUserRepository UserRepository { get; }

        void Save();

        //IRepository<Engine> EngineRepository { get; set; }

    }
}
