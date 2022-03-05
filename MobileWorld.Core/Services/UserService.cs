namespace MobileWorld.Core.Services
{
    using MobileWorld.Core.ViewModels.UserModels;
    using MobileWorld.Core.Contracts;
    using MobileWorld.Infrastructure.Data.Common;

    public class UserService : IUserService
    {
        private readonly IRepository repo;

        public UserService(IRepository _repo)
        {
            this.repo = _repo;
        }

        public bool LogInUser(LoginViewModel model)
        {
            throw new NotImplementedException();
        }

        public (bool, string) RegisterUser(RegisterModel model)
        {
            throw new NotImplementedException();
        }
    }
}
