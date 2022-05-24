using MobileWorld.Core.Models;
using MobileWorld.Core.ViewModels;

namespace MobileWorld.Core.Services.Contracts
{
    public interface IUserService
    {
        List<AdCardViewModel> UserFavourites(string userId);

        List<AdCardViewModel> UserAds(string userId);

        bool AddToFavorites(string adId, string userId);

        bool RemoveFromFavorites(string adId, string userId);

        //List<UserViewModel> GetUsers();
    }
}
