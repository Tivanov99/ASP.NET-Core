using Microsoft.AspNetCore.Identity;
using MobileWorld.Core.Contracts;
using MobileWorld.Core.Models;
using MobileWorld.Infrastructure.Data.Common;

namespace MobileWorld.Core.Services
{
    public class AdminService : IAdminService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly UserManager<IdentityUser> _userManager;

        public AdminService(
            IUnitOfWork _unitOfWork,
            UserManager<IdentityUser> userManager)
        {
            unitOfWork = _unitOfWork;
            _userManager = userManager;
        }

        public void DeleteUser(string userId)
        {
            this.unitOfWork.AdminRepository.Delete(userId);
            this.unitOfWork.Save();
        }

        public UserViewModel ModifyUser(string userId)
        {
            var user = this.unitOfWork.AdminRepository.GetAll()
                .Where(u => u.Id == userId)
                .FirstOrDefault();

            var role = _userManager.GetRolesAsync(user);

            return null;
        }

        public IEnumerable<UserViewModel> Users()
        {
            var user = this.unitOfWork.AdminRepository.GetAll()
               .ToList();

            var role = _userManager.GetRolesAsync(user[0]);
              
            return null;
            
        }
    }
}
