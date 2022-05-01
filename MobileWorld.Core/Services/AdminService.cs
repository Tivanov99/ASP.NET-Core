using Microsoft.EntityFrameworkCore;
using MobileWorld.Core.Contracts;
using MobileWorld.Core.Models;
using MobileWorld.Core.ViewModels;
using MobileWorld.Infrastructure.Data.Common;
using MobileWorld.Infrastructure.Data.Identity;
using MobileWorld.Infrastructure.Data.Repositories;

namespace MobileWorld.Core.Services
{
    public class AdminService : IAdminService
    {
        private readonly IApplicatioDbRepository _repo;

        public AdminService(
            IApplicatioDbRepository repo
            )
        {
            _repo = repo;
        }

        public void DeleteUser(string userId)
        {
            this.unitOfWork.Delete(userId);
            this.unitOfWork.Save();
        }

        public UserViewModel GetUserAsViewModel(string userId)
        {
            var user = this.unitOfWork.AdminRepository
                .GetAsQueryable()
                .Include(u => u.Ads)
                .Where(u => u.Id == userId)
                .Select(u =>  new UserViewModel()
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
        => unitOfWork
                .AdminRepository
                .GetAll()
                .Select(u => new UserViewModel()
                {
                    Id = u.Id,
                    UserName = u.UserName
                })
                .ToList();

        public ApplicationUser GetApplicationUser(string userId)
        => this.unitOfWork.UserRepository.GetAll()
                .Where(u => u.Id == userId)
                .First();
    }
}
