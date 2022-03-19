namespace MobileWorld.Core.Services
{
    using MobileWorld.Core.Contracts;
    using MobileWorld.Infrastructure.Data.Common;
    using System.Collections.Generic;
    using MobileWorld.Core.ViewModels.CarViewModels;
    using Microsoft.AspNetCore.Identity;

    public class UserService : IUserService
    {
        private readonly IRepository repo;

        public UserService(IRepository _repo)
        {
            this.repo = _repo;
        }

        public List<CarCardViewModel> UserAnnouncements(string userId)
        {
            var users = this.repo.All<IdentityUser>()
                .Where(u => u.Id == userId)
                .Select(x => new { x.Id, x.Email, x.UserName })
                .ToList();
            //user adds
            throw new NotImplementedException();
        }

        public List<CarCardViewModel> UserFavourites(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
