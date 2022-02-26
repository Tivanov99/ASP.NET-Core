using MobileWorld.Contracts;
using MobileWorld.Models;

namespace MobileWorld.Services
{
    public class UserService : IUserService
    {

        public UserService()
        {

        }

        public bool LogInUser(LoginModel model)
        {
            throw new NotImplementedException();
        }

        public (bool, string) RegisterUser(RegisterModel model)
        {
            throw new NotImplementedException();
        }
    }
}
