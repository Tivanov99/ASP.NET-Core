using MobileWorld.Core.Contracts;
using MobileWorld.Infrastructure.Data.Common;
using MobileWorld.Infrastructure.Data.Identity;
using MobileWorld.Core.ViewModels;
using MobileWorld.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace MobileWorld.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository repo;

        public UserService(IRepository _repo)
        {
            this.repo = _repo;
        }


        public List<AdCardViewModel> UserAds(string userId)
        {
            try
            {
                var userAds = this.repo.All<ApplicationUser>()
                   .AsNoTracking()
                   .Where(u => u.Id == userId)
                   .SelectMany(a => a.Ads
                                   .Select(x => new AdCardViewModel()
                                   {
                                       AdId = x.Id,
                                       Title = x.Title,
                                       Description = x.Description,
                                       Price = x.Price,
                                       ImageData = x.Images[0].ImageData
                                   }))
                   .ToList();

                return  userAds;
            }
            catch (KeyNotFoundException)
            {
                return null;
            }
        }

        public List<AdCardViewModel> UserFavourites(string userId)
        {
            var result = this.repo.All<ApplicationUser>()
                .AsNoTracking()
                .Where(u => u.Id == userId)
                .SelectMany(u => u.FavoriteAds)
                .Select(fv => new AdCardViewModel()
                {
                    AdId = fv.Ad.Id,
                    Title = fv.Ad.Title,
                    Description = fv.Ad.Description,
                    Price = fv.Ad.Price,
                })
                .ToList();
            return result;
        }
    }
}
