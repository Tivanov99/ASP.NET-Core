using MobileWorld.Infrastructure.Data.Identity;
using MobileWorld.Infrastructure.Data.Models;
using MobileWorld.Infrastructure.Data.Repositories;
using MobileWorld.Infrastructure.Data.Repositories.Contracts;

namespace MobileWorld.Infrastructure.Data.Common
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();

        public IAdRepository AdRepository { get; }

        public IApplicationDbRepository<ApplicationUser> UserRepository { get; }

        public IApplicationDbRepository<Town> TownRepository { get; }
    }
}
