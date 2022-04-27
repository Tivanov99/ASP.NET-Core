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
        public IActionResult FavoritesAds(string userId)
        {
            var result = this.userService
                .UserFavourites(userId);
            return View(result);
        }

        [Authorize]
        public IActionResult UserAds(string userId)
        {
            var result = this.userService
                .UserAds(userId);
            return View(result);
        }

        //[Authorize(Roles = GlobalConstants.AdministratorRole)]
        //public IActionResult ManageUsers()
        //{
        //    var users = this.userService.GetUsers();
        //    return Ok(users);
        //}
        public IActionResult Fav(string adId, string userId)
        {
            bool result = this.userService.AddToFavorites(adId, userId);
            return View();
        }

        public IActionResult UnFav(string adId, string userId)
        {
            bool result = this.userService.RemoveFromFavorites(adId, userId);
            return View();
        }

    }
}
