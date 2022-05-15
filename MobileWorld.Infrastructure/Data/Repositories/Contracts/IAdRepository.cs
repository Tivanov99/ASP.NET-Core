using Microsoft.Data.SqlClient;
using MobileWorld.Infrastructure.Data.Common;
using MobileWorld.Infrastructure.Data.Models;
using MobileWorld.Infrastructure.Data.QueriesAndSPDtoModels;

namespace MobileWorld.Infrastructure.Data.Repositories.Contracts
{
    public interface IAdRepository : IRepository<Ad>
    {
        AdSpModel GetAdById(string sql, SqlParameter [] parameters);
    }
}
