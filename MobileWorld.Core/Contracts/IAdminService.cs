using MobileWorld.Core.Models;

namespace MobileWorld.Core.Contracts
{
    public interface IAdminService
    {
        IEnumerable<UserViewModel> Users();

        UserViewModel GetUserAsViewModel(string userId);

        void DeleteUser(string userId);

        void GetApplicationUser(string userId);
    }
}
