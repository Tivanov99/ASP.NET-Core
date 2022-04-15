using MobileWorld.Core.Models;
using MobileWorld.Infrastructure.Data.Identity;

namespace MobileWorld.Core.Contracts
{
    public interface IAdminService
    {
        IEnumerable<UserViewModel> Users();

        UserViewModel GetUserAsViewModel(string userId);

        void DeleteUser(string userId);

        ApplicationUser GetApplicationUser(string userId);
    }
}
