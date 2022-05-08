using Microsoft.Data.SqlClient;
using MobileWorld.Infrastructure.Data.QueriesAndSP.Sp.Contracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileWorld.Infrastructure.Data.QueriesAndSP.Sp
{
    public class StoredProdecuresCollection : IStoredProdecuresCollection
    {
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
