using Microsoft.EntityFrameworkCore;
using MobileWorld.Infrastructure.Data.Identity;
using MobileWorld.Infrastructure.Data.Models;
using MobileWorld.Infrastructure.Data.Repositories;
using MobileWorld.Infrastructure.Data.Repositories.Contracts;

namespace MobileWorld.Infrastructure.Data.Common
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context,
           IAdRepository adRepository,
            IApplicationDbRepository<ApplicationUser> userRepository,
            IApplicationDbRepository<Town> townRepository
            )
        {
            _context = context;
            AdRepository = adRepository;
            UserRepository = userRepository;
            TownRepository = townRepository;           
        }


        public IAdRepository AdRepository
        {
            get;
            //{
            //    if (this._adRepository == null)
            //    {
            //        this._adRepository = new ApplicationDbRepository<Ad>(_context);
            //    }
            //    return _adRepository;
            //}
        }

        public IApplicationDbRepository<ApplicationUser> UserRepository
        {
            get;
            //{
            //    {
            //        if (this._userRepository == null)
            //        {
            //            this._userRepository = new ApplicationDbRepository<ApplicationUser>(_context);
            //        }
            //        return _userRepository;
            //    }
            //}
        }

        public IApplicationDbRepository<Town> TownRepository { get; }

        public void Save()
        {
             _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
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
