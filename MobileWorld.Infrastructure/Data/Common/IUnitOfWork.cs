using MobileWorld.Infrastructure.Data.Models;

namespace MobileWorld.Infrastructure.Data.Common
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();

    }
}
