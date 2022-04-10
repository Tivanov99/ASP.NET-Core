using MobileWorld.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileWorld.Infrastructure.Data.Common
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private ApplicationDbContext context ;

        public UnitOfWork(ApplicationDbContext _context,
            IRepository<Ad> _adRepository
            , IRepository<Car> _carRepository)
        {
            this.context = _context;
            this.AdRepository = _adRepository;
            this.CarRepository = _carRepository;
        }


        public IRepository<Ad> AdRepository { get ;  }

        public IRepository<Car> CarRepository { get ;}

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
