using MobileWorldBL.Core.ViewModels;

namespace MobileWorldBL.Core.Contracts
{
    public interface IUserService
    {
        bool LogInUser(LoginModel model);

        (bool, string) RegisterUser(RegisterModel model);
    }
}
