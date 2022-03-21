using MobileWorld.Core.ViewModels;

namespace MobileWorld.Core.Contracts
{
    public interface IUserService
    {
        List<AdViewModel> UserFavourites(string userId);

        List<AdViewModel> UserAds(string userId);
    }
}
