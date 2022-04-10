using MobileWorld.Infrastructure.Data.Models;

namespace MobileWorld.Infrastructure.Data.Common
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private ApplicationDbContext context;

        public UnitOfWork(ApplicationDbContext _context,
            IRepository<Ad> _adRepository
            , IRepository<Car> _carRepository)
        {
            this.context = _context;
            this.AdRepository = _adRepository;
            this.CarRepository = _carRepository;
        }

        public IRepository<Ad> AdRepository { get; }

        public IRepository<Car> CarRepository { get; }


        public void Save()
        {
            this.context.SaveChanges();
        }
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
