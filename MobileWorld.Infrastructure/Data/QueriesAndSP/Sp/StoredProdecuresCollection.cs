using Microsoft.Data.SqlClient;
using MobileWorld.Infrastructure.Data.QueriesAndSP.Sp.Contracts;
using System.Data;

namespace MobileWorld.Infrastructure.Data.QueriesAndSP.Sp
{
    public class StoredProdecuresCollection : IStoredProdecuresCollection
    {
        public (string, SqlParameter[]) DeleteAd(string adId)
        {
            string sql = "EXEC [dbo].[DeleteAd] @AdId, @AfectedRowls out";

            var adIdParam = new SqlParameter()
            {
                ParameterName = "@AdId",
                SqlDbType = SqlDbType.NVarChar,
                Value = adId
            };

            var result = new SqlParameter()
            {
                ParameterName = "@AfectedRowls",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Output,
            };

            return (sql, new SqlParameter[] { adIdParam, result });
        }

        public (string, SqlParameter[]) GetAd(string adId)
        {
            SqlParameter param = new SqlParameter()
            {
                ParameterName = "@AdId",
                Value = adId,
                Direction = ParameterDirection.Input,
            };

            string sql = "EXEC GetAd @AdId";
            return (sql, new SqlParameter[] { param });
        }

        public (string, SqlParameter[]) GetAdById(string adId)
        {
            var adIdParam = new SqlParameter()
            {
                ParameterName = "@AdId",              
                Value = adId,
                Direction = ParameterDirection.Input,
            };

            string sql = "exec [GetAdById] @AdId";

            return (sql, new SqlParameter[] { adIdParam });
        }

        public string AllAds()
        {
            return "EXEC [AllAds]";
        }

        public string GetIndexAds()
        {
            return "EXEC [IndexAds]";
        }

        public (string, SqlParameter[]) GetTownIdByTownName(string townName)
        {
            string sql = "EXEC [dbo].[GetTownIdByTownName] @TownName, @Id out";

            var param = new SqlParameter()
            {
                ParameterName = "@TownName",
                SqlDbType = SqlDbType.NVarChar,
                Value = townName
            };
            var result = new SqlParameter()
            {
                ParameterName = "@Id",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Output,
            };
            return (sql, new SqlParameter[] { param, result });
        }
    }
}
