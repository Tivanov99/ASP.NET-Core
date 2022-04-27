using MobileWorld.Core.Contracts;
using MobileWorld.Infrastructure.Data.Common;
using MobileWorld.Core.ViewModels;
using MobileWorld.Core.Models;
using Microsoft.EntityFrameworkCore;
using MobileWorld.Infrastructure.Data.Models;

namespace MobileWorld.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork unitOfWork;

        public UserService(IUnitOfWork _unitOfWork)
        {
            this.unitOfWork = _unitOfWork;
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
                var userAds = this.unitOfWork
                    .UserRepository
                    .GetAllAsQueryable()
                    .AsNoTracking()
                    .Include(u => u.Ads)
                   .Where(u => u.Id == userId)
                   .SelectMany(u=>u.Ads)
                   .Select(a=> new AdCardViewModel()
                   {
                       AdId=a.Id,
                       Title=a.Title,
                       Description=a.Description,
                       Price=a.Price,
                       ImagePath=a.Images[0].ImagePath,
                       ImageTitle=a.Images[0].ImageTitle,
                   })
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
            var result = this.unitOfWork.UserRepository
                .GetAllAsQueryable()
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

        public bool AddToFavorites(string adId, string userId)
        {
            var user = this.unitOfWork.UserRepository.GetById(userId);

            user.FavoriteAds.Add(new FavoriteAd()
            {
                AdId=adId,
                UserId=userId,
            });

            try
            {
                this.unitOfWork.Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool RemoveFromFavorites(string adId, string userId)
        {
            var user = this.unitOfWork.UserRepository.GetById(userId);

            user.FavoriteAds.Add(new FavoriteAd()
            {
                AdId = adId,
                UserId = userId,
            });

            try
            {
                this.unitOfWork.Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
