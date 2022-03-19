using MobileWorld.Core.Contracts;
using MobileWorld.Infrastructure.Data.Common;
using MobileWorld.Infrastructure.Data.Identity;
using MobileWorld.Core.ViewModels;

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
            var users = this.repo.All<ApplicationUser>()
                .Where(u => u.Id == userId)
                .SelectMany(a => a.Ads
                                .Select(x => new AdCardViewModel()
                                {
                                    CarId = x.CarId,
                                    Title = x.Title,
                                    Description = x.Description,
                                    Price = x.Price,
                                }))
                .ToList();


            //user adds
            throw new NotImplementedException();
        }

        public List<AdCardViewModel> UserFavourites(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
