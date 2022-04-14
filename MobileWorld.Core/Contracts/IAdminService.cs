using MobileWorld.Core.Models;

namespace MobileWorld.Core.Contracts
{
    public interface IAdminService
    {
        IEnumerable<UserViewModel> Users();

        UserViewModel GetUser(string userId);

        void DeleteUser(string userId);
    }
}
