using MobileWorld.Core.Models.ViewModels;
using MobileWorld.Infrastructure.Data.Identity;

namespace MobileWorld.Core.Services.Contracts
{
    public interface IAdminService
    {
        IEnumerable<UserViewModel> Users();

        UserViewModel GetUserAsViewModel(string userId);

        void DeleteUser(string userId);

        Task<ApplicationUser> GetApplicationUser(string userId);
    }
}
