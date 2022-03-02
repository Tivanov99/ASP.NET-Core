using MobileWorld.Core.ViewModels;

namespace MobileWorld.Core.Contracts
{
    public interface IUserService
    {
        bool LogInUser(LoginModel model);

        (bool, string) RegisterUser(RegisterModel model);
    }
}
