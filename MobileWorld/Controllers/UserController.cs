using MobileWorld.Core.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MobileWorld.Controllers
{
    public class UserController : MyBaseController
    {
        private readonly IUserService userService;
        public UserController(IUserService _userService)
        {
            this.userService = _userService;
        }

        [Authorize]
        public IActionResult Favourites(string userId)
        {
            var result = this.userService.UserFavourites(userId);
            return View();
        }

        [Authorize]
        public IActionResult Ads(string userId)
        {
            var result = this.userService.UserAnnouncements(userId);

            //TODO: check here , and add view
            return View();
        }
    }
}
