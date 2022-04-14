using MobileWorld.Core.Contracts;
using MobileWorld.Core.Models;
using MobileWorld.Infrastructure.Data.Common;
using MobileWorld.Infrastructure.Data.Identity;

namespace MobileWorld.Core.Services
{
    public class AdminService : IAdminService
    {
        private readonly IUnitOfWork unitOfWork;

        public AdminService(
            IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        public void DeleteUser(string userId)
        {
            this.unitOfWork.AdminRepository.Delete(userId);
            this.unitOfWork.Save();
        }

        public ApplicationUser GetUser(string userId)
        {
            var user = this.unitOfWork.AdminRepository
                .GetAll()
                .Where(u => u.Id == userId)
                .FirstOrDefault();

            return user;
        }

        public IEnumerable<UserViewModel> Users()
        {
            
            var users = unitOfWork
                .AdminRepository
                .GetAll()
                .Select(u => new UserViewModel()
                {
                    Id = u.Id,
                    UserName=u.UserName
                })
                .ToList();

            return users;
        }
    }
}
