using MobileWorld.Infrastructure.Data.Common;
using MobileWorld.Core.Models;
using Microsoft.EntityFrameworkCore;
using MobileWorld.Infrastructure.Data.Models;
using MobileWorld.Infrastructure.Data.Repositories;
using MobileWorld.Infrastructure.Data.Identity;
using MobileWorld.Core.Services.Contracts;
using MobileWorld.Core.Models.ViewModels;

namespace MobileWorld.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unit)
        {
            _unitOfWork = unit;
        }

        //public List<UserViewModel> GetUsers()
        //{
        //    return this.unitOfWork
        //        .UserRepository
        //        .GetAll()
        //        .Select(u => new UserViewModel()
        //        {
        //            Id = u.Id,
        //            FirstName = u.FirstName,
        //            LastName = u.LastName,
        //        })
        //        .ToList();
        //}

        public List<AdCardViewModel> UserAds(string userId)
        {
            try
            {
                var userAds = this._unitOfWork
                    .UserRepository
                    .GetAsQueryable()
                    .AsNoTracking()
                    .Include(u => u.Ads)
                   .Where(u => u.Id == userId)
                   .SelectMany(u => u.Ads)
                   .Select(a => new AdCardViewModel()
                   {
                       AdId = a.Id,
                       Title = a.Title,
                       Description = a.Description,
                       Price = a.Price,
                       ImagePath = a.Images[0].ImagePath,
                       ImageTitle = a.Images[0].ImageTitle,
                   })
                   .ToList();

                return userAds;
            }
            catch (KeyNotFoundException)
            {
                return null;
            }
        }

        public List<AdCardViewModel> UserFavourites(string userId)
        {
            var result = this._unitOfWork
                    .UserRepository
                .GetAsQueryable()
                .AsNoTracking()
                .Where(u => u.Id == userId)
                .SelectMany(u => u.FavoriteAds)
                .Select(fv => new AdCardViewModel()
                {
                    AdId = fv.Ad.Id,
                    Title = fv.Ad.Title,
                    Description = fv.Ad.Description,
                    Price = fv.Ad.Price,
                    ImageTitle = fv.Ad.Images[0].ImageTitle
                })
                .ToList();
            return result;
        }

        public bool AddToFavorites(string adId, string userId)
        {
            var user = this._unitOfWork
                    .UserRepository
                .GetById(userId);

            user.FavoriteAds.Add(new FavoriteAd()
            {
                AdId = adId,
                UserId = userId,
            });

            try
            {
                this._unitOfWork.Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool RemoveFromFavorites(string adId, string userId)
        {
            var user = this._unitOfWork
                    .UserRepository
                .GetAsQueryable()
                .Where(u => u.Id == userId)
                .Include(u => u.FavoriteAds)
                .FirstOrDefault();

            try
            {
                var da = user.FavoriteAds.Where(fa => fa.AdId == adId).FirstOrDefault();
                user.FavoriteAds.Remove(da);
                this._unitOfWork.Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
