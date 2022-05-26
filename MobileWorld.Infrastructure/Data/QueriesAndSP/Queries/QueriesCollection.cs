using System.Text;

namespace MobileWorld.Infrastructure.Data.QueriesAndSP.Queries
{
    public class QueriesCollection : IQueriesCollection
    {
        private readonly string _baseCriteriaQuery = "SELECT A.Id AS [AdId], A.CreatedOn, A.Price, A.Title, " +
                "(SELECT TOP(1) i.ImageTitle FROM [Images] AS I WHERE I.AdId = A.Id) AS [ImageTitle], " +
                "C.Mileage, C.[Year], E.HorsePower, E.FuelType " +
                "FROM [Ads] AS A " +
                "LEFT JOIN[Cars] AS C ON C.AdId = A.Id " +
                "LEFT JOIN [Engines] AS E ON E.CarId = C.Id ";

        public string GetAdsByAdvancedCriteria()
        {
            StringBuilder sb = new StringBuilder(_baseCriteriaQuery);

            sb.Append("LEFT JOIN [Features] AS FE ON FE.CarId=C.Id " +
                      "LEFT JOIN[ComfortDetails] AS CD ON CD.FeatureId = FE.Id " +
                      "LEFT JOIN[ExteriorDetails] AS ED ON ED.Id = FE.Id " +
                      "LEFT JOIN[InteriorDetails] AS INTDETAILS ON INTDETAILS.Id = FE.Id " +
                      "LEFT JOIN[OthersDetails] AS OTD ON OTD.Id = FE.Id " +
                      "LEFT JOIN[ProtectionDetails]  AS PD ON PD.Id = FE.Id " +
                      "LEFT JOIN[Regions] AS R ON R.Id = A.RegionId " +
                      "LEFT JOIN[Towns] AS T ON T.Id = R.TownId "+
                      "LEFT JOIN[SafetyDetails] AS SD ON SD.Id = FE.Id Where ");
            return sb.ToString();
        }

        public string GetAdsByBaseCriteriaSp()
        {
            string query = _baseCriteriaQuery;

            return query += (" Where "); 
        }
    }
}
