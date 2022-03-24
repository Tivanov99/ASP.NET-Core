using MobileWorld.Infrastructure.Data.Common;

namespace MobileWorld.Core.Services
{
    public class AdService
    {
        private readonly IRepository repo;
        public AdService(IRepository _repo)
        {
            this.repo = _repo;
        }

    }
}
