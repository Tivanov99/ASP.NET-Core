using MobileWorld.Core.Contracts;
using MobileWorld.Infrastructure.Data.Common;
using MobileWorld.Core.ViewModels;
using MobileWorld.Core.Models;
using Microsoft.EntityFrameworkCore;


namespace MobileWorld.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork unitOfWork;

        public UserService(IUnitOfWork _unitOfWork)
        {
            this.unitOfWork = _unitOfWork;
        }

        public List<UserViewModel> GetUsers()
        {
            return this.unitOfWork
                .UserRepository
                .GetAll()
                .Select(u => new UserViewModel()
                {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                })
                .ToList();
        }

        public List<AdCardViewModel> UserAds(string userId)
        {
            try
            {
                var userAds = this.unitOfWork
                    .UserRepository
                    .GetAllAsQueryable()
                    .Include(u => u.Ads)
                   .Where(u => u.Id == userId)
                   .SelectMany(u=>u.Ads)
                   .Select(a=> new AdCardViewModel()
                   {
                       AdId=a.Id,
                       Title=a.Title,
                       Description=a.Description,
                       Price=a.Price,
                       ImageData=a.Images[0].ImageData
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
            var result = this.unitOfWork.UserRepository.GetAll()
                //.AsNoTracking()
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
