using MobileWorld.Infrastructure.Data.Models;

namespace MobileWorld.Infrastructure.Data.Common
{
    public interface IAdRepository : IRepository<Ad>
    {
        IQueryable<Ad> GetAdByIdAsIQueryable(string id);
    }
}
