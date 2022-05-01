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
        private readonly IApplicationDbRepository _repo;

        public AdminService(
            IApplicationDbRepository repo
            )
        {
            _repo = repo;
        }

        public void DeleteUser(string userId)
        {
            _repo.DeleteAsync<ApplicationUser>(userId);
        }

        public UserViewModel GetUserAsViewModel(string userId)
        {
            var user = this._repo
                .GetAsQueryable<ApplicationUser>()
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
        => this._repo
                .GetAll<ApplicationUser>()
                .Select(u => new UserViewModel()
                {
                    Id = u.Id,
                    UserName = u.UserName
                })
                .ToList();

        public async Task<ApplicationUser> GetApplicationUser(string userId)
        {
            var result = await this._repo.GetByIdAsync<ApplicationUser>(userId);
            return result;
        }
    }
}
