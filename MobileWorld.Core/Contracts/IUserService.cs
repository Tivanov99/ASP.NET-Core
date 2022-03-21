using MobileWorld.Core.ViewModels;

namespace MobileWorld.Core.Contracts
{
    public interface IUserService
    {
        List<CardAdViewModel> UserFavourites(string userId);

        List<CardAdViewModel> UserAds(string userId);
    }
}
