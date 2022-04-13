using MobileWorld.Core.Models;

namespace MobileWorld.Core.Contracts
{
    public interface IAdminService
    {
        IEnumerable<UserViewModel> Users();

        UserViewModel ModifyUser(string userId);

        void DeleteUser(string userId);
    }
}
