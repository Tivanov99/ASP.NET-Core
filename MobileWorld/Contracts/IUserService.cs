using MobileWorld.Models;

namespace MobileWorld.Contracts
{
    public interface IUserService
    {
        bool LogInUser(LoginModel model);

        (bool, string) RegisterUser(RegisterModel model);
    }
}
