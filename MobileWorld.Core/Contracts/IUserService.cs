using MobileWorld.Core.Models;
using MobileWorld.Core.ViewModels;

namespace MobileWorld.Core.Contracts
{
    public interface IUserService
    {
        List<AdCardViewModel> UserFavourites(string userId);

        List<AdCardViewModel> UserAds(string userId);
    }
}
