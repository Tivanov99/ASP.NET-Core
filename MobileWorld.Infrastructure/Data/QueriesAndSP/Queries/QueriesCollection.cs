using System.Text;

namespace MobileWorld.Infrastructure.Data.QueriesAndSP.Queries
{
    public class QueriesCollection : IQueriesCollection
    {
        public string GetAdsByAdvancedCriteria()
        {
            StringBuilder sb = new StringBuilder(GetAdsByBaseCriteriaSp());

            sb.Append("LEFT JOIN [Features] AS FE ON FE.CarId=C.Id " +
                      "LEFT JOIN[ComfortDetails] AS CD ON CD.FeatureId = FE.Id " +
                      "LEFT JOIN[ExteriorDetails] AS ED ON ED.Id = FE.Id " +
                      "LEFT JOIN[InteriorDetails] AS INTDETAILS ON INTDETAILS.Id = FE.Id " +
                      "LEFT JOIN[OthersDetails] AS OTD ON OTD.Id = FE.Id " +
                      "LEFT JOIN[ProtectionDetails]  AS PD ON PD.Id = FE.Id " +
                      "LEFT JOIN[SafetyDetails] AS SD ON SD.Id = FE.Id");
            return sb.ToString();
        }

        public string GetAdsByBaseCriteriaSp()
        {
            return "SELECT A.Id AS [AdId], A.CreatedOn, A.Price, A.Title, " +
                "(SELECT TOP(1) i.ImageTitle FROM [Images] AS I WHERE I.AdId = A.Id) AS [ImageTitle], " +
                "C.Mileage, C.[Year], E.HorsePower, E.FuelType " +
                "FROM [Ads] AS A " +
                "LEFT JOIN[Cars] AS C ON C.AdId = A.Id " +
                "LEFT JOIN [Engines] AS E ON E.CarId = C.Id";
        }
    }
}
