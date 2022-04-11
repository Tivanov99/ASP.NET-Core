namespace MobileWorld.Infrastructure.Data.Common
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext context;
        private bool disposed = false;


        public UnitOfWork(ApplicationDbContext _context,
            IAdRepository _adRepository,
            ICarRepository _carRepository,
            IUserRepository _userRepository)
        {
            this.context = _context;
            this.AdRepository = _adRepository;
            this.CarRepository = _carRepository;
            this.UserRepository = _userRepository;
        }

        public IAdRepository AdRepository { get; }

        public ICarRepository CarRepository { get; }

        public IUserRepository UserRepository { get; }

        public void Save()
        {
            this.context.SaveChanges();
        }

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
