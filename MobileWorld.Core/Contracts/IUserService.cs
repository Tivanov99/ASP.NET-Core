using MobileWorld.Core.ViewModels.CarViewModels;
using MobileWorld.Core.ViewModels.UserModels;

namespace MobileWorld.Core.Contracts
{
    public interface IUserService
    {
        List<CarCardViewModel> UserFavourites(string userId);

        List<CarCardViewModel> UserAnnouncements(string userId);
    }
}
