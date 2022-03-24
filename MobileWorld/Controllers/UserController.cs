using MobileWorld.Core.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MobileWorld.Core.Models;

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
        public IActionResult UserAds(string userId)
        {
            var result = this.userService.UserAds(userId);

            //TODO: check here , and add view
            return View();
        }

        //[Authorize]
        [HttpGet]
        public IActionResult CreateAd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateAd(CreateAdModel model)
        {
            return View();
        }

    }
}
