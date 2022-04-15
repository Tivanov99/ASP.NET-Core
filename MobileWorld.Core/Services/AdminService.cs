using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MobileWorld.Core.Contracts;
using MobileWorld.Core.Models;
using MobileWorld.Core.ViewModels;
using MobileWorld.Infrastructure.Data.Common;
using MobileWorld.Infrastructure.Data.Identity;

namespace MobileWorld.Core.Services
{
    public class AdminService : IAdminService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUnitOfWork unitOfWork;

        public AdminService(
            IUnitOfWork _unitOfWork,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager
            )
        {
            _userManager = userManager;
            _roleManager = roleManager;
            unitOfWork = _unitOfWork;
        }

        public void DeleteUser(string userId)
        {
            this.unitOfWork.AdminRepository.Delete(userId);
            this.unitOfWork.Save();
        }

        public UserViewModel GetUser(string userId)
        {
            var user = this.unitOfWork.AdminRepository
                .GetAllAsQueryable()
                .Include(u=>u.Ads)
                .Where(u => u.Id == userId)
                .Select(u=> new UserViewModel()
                {
                    Id = u.Id,
                    UserName = u.UserName,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email,
                    AdsCount = u.Ads.Count,
                    UserAds = (List<AdViewModel>)u.Ads.Select(a => new AdViewModel()
                    {
                        Id = a.Id,

                    })
                })
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
