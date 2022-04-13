using MobileWorld.Core.Contracts;
using MobileWorld.Core.Models;
using MobileWorld.Infrastructure.Data.Common;

namespace MobileWorld.Core.Services
{
    public class AdminService : IAdminService
    {
        private readonly IUnitOfWork unitOfWork;

        public AdminService(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        public void DeleteUser(string userId)
        {
            throw new NotImplementedException();
        }

        public UserViewModel ModifyUser(string userId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserViewModel> Users()
        {
            throw new NotImplementedException();
        }
    }
}
