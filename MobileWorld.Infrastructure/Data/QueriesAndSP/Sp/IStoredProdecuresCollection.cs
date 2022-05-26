using Microsoft.Data.SqlClient;

namespace MobileWorld.Infrastructure.Data.QueriesAndSP.Sp
{
    public interface IStoredProdecuresCollection
    {
        (string, SqlParameter[]) GetTownIdByTownName(string townName);

        (string, SqlParameter[]) DeleteAd(string adId);

        (string, SqlParameter[]) GetAdById(string adId);

        string GetIndexAds();

        string AllAds();

        (string, SqlParameter[]) GetAdFeatures(string adId);

        (string, SqlParameter[]) GetUserAds(string userId);
    }
}
