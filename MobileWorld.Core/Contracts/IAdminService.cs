using MobileWorld.Core.Models;
using MobileWorld.Infrastructure.Data.Identity;

namespace MobileWorld.Core.Contracts
{
    public interface IAdminService
    {
        IEnumerable<ApplicationUser> Users();

        ApplicationUser ModifyUser(string userId);

        void DeleteUser(string userId);
    }
}
