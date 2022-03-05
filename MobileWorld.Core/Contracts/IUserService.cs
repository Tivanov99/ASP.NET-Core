using MobileWorld.Core.ViewModels.UserModels;

namespace MobileWorld.Core.Contracts
{
    public interface IUserService
    {
        bool LogInUser(LoginViewModel model);

        (bool, string) RegisterUser(RegisterModel model);
    }
}
