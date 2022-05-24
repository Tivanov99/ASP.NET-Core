namespace MobileWorld.Infrastructure.Data.QueriesAndSP.Queries
{
    public class QueriesCollection : IQueriesCollection
    {
        public string GetAdsByBaseCriteria()
        {
            return "SELECT A.Id AS [AdId], A.CreatedOn, A.Price, A.Title," +
                " (SELECT TOP(1) i.ImageTitle FROM [Images] AS I WHERE I.AdId = A.Id) AS [ImageTitle]," +
                " C.Mileage, C.[Year], E.HorsePower, E.FuelType" +
                " FROM [Ads] AS A " +
                "LEFT JOIN[Cars] AS C ON C.AdId = A.Id" +
                " LEFT JOIN [Engines] AS E ON E.CarId = C.Id";
        }
    }
}
