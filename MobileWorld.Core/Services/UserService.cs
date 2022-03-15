namespace MobileWorld.Core.Services
{
    using MobileWorld.Core.Contracts;
    using MobileWorld.Infrastructure.Data.Common;
    using System.Collections.Generic;
    using MobileWorld.Core.ViewModels.CarViewModels;

    public class UserService : IUserService
    {
        private readonly IRepository repo;

        public UserService(IRepository _repo)
        {
            this.repo = _repo;
        }

        public List<CarCardViewModel> UserAnnouncements(string userId)
        {
            //user adds
            throw new NotImplementedException();
        }

        public List<CarCardViewModel> UserFavourites(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
