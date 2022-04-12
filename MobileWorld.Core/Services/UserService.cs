using MobileWorld.Core.Contracts;
using MobileWorld.Infrastructure.Data.Common;
using MobileWorld.Core.ViewModels;
using MobileWorld.Core.Models;

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
                var userAds = this.unitOfWork.UserRepository.GetAll()
                   //.AsNoTracking()
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
