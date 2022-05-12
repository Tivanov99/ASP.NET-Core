using Microsoft.Data.SqlClient;

namespace MobileWorld.Infrastructure.Data.QueriesAndSP.Sp.Contracts
{
    public interface IStoredProdecuresCollection
    {
         (string, SqlParameter[]) GetTownIdByTownName(string townName);

        (string, SqlParameter[]) DeleteAd(string adId);

        (string, SqlParameter[]) GetAdById(string adId);

        (string, SqlParameter[]) GetAd(string adId);

    }
}
