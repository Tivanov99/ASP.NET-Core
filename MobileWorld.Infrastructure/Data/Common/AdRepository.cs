using MobileWorld.Infrastructure.Data.Models;

namespace MobileWorld.Infrastructure.Data.Common
{
    public class AdRepository : Repository<Ad>, IAdRepository
    {
        private ApplicationDbContext context;
        public AdRepository(ApplicationDbContext _context)
            : base(_context)
        {
            context = _context;
        }

        public List<object> GetByCriteria()
        {
            //var q =
            // from c in context.Cars
            // join a in context.Ads
            //    on c.AdId equals a.Id
            // join i in context.Images
            //    on a.Id equals i.AdId
            // join r in context.Regions
            //     on a.RegionId equals r.Id
            // join t in context.Towns
            //     on r.TownId equals t.Id
            // join e in context.Engines
            //     on c.Engine.Id equals e.Id
            // select new
            // {
            //     a.Id,
            //     a.Title,
            //     a.Description,
            //     a.Price,
            //     i.ImageData
            // };

            //var result = context.Data<List<SomeType>>(...);

            //from e in emps
            //select new { o.OrderID, e.FirstName };

            //var ads = context.Ads.FromSqlInterpolated()
            return new List<object>();
        }

    }
}
