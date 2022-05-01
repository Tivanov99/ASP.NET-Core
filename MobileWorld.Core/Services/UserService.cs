﻿using MobileWorld.Core.Contracts;
using MobileWorld.Infrastructure.Data.Common;
using MobileWorld.Core.ViewModels;
using MobileWorld.Core.Models;
using Microsoft.EntityFrameworkCore;
using MobileWorld.Infrastructure.Data.Models;
using MobileWorld.Infrastructure.Data.Repositories;
using MobileWorld.Infrastructure.Data.Identity;

namespace MobileWorld.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IApplicationDbRepository _repo;

        public UserService(IApplicationDbRepository repo)
        {
            this._repo = repo;
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
                var userAds = this._repo
                    .GetAsQueryable<ApplicationUser>()
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
            var result = this._repo
                .GetAsQueryable<ApplicationUser>()
                .AsNoTracking()
                .Where(u => u.Id == userId)
                .SelectMany(u => u.FavoriteAds)
                .Select(fv => new AdCardViewModel()
                {
                    AdId = fv.Ad.Id,
                    Title = fv.Ad.Title,
                    Description = fv.Ad.Description,
                    Price = fv.Ad.Price,
                    ImageTitle=fv.Ad.Images[0].ImageTitle
                })
                .ToList();
            return result;
        }

        public bool AddToFavorites(string adId, string userId)
        {
            var user = this._repo.GetById<ApplicationUser>(userId);

            user.FavoriteAds.Add(new FavoriteAd()
            {
                AdId = adId,
                UserId = userId,
            });

            try
            {
                this._repo.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool RemoveFromFavorites(string adId, string userId)
        {
            var user = this._repo
                .GetAsQueryable<ApplicationUser>()
                .Where(u => u.Id == userId)
                .Include(u => u.FavoriteAds)
                .FirstOrDefault();

            try
            {
                var da = user.FavoriteAds.Where(fa => fa.AdId == adId).FirstOrDefault();
                user.FavoriteAds.Remove(da);
                this._repo.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
