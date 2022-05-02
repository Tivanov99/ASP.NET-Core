using MobileWorld.Infrastructure.Data.Identity;
using MobileWorld.Infrastructure.Data.Models;
using MobileWorld.Infrastructure.Data.Repositories;

namespace MobileWorld.Infrastructure.Data.Common
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();

        public IApplicationDbRepository<Ad> AdRepository { get; }

        public IApplicationDbRepository<ApplicationUser> UserRepository { get; }

        public IApplicationDbRepository<Town> TownRepository { get; }
    }
}
