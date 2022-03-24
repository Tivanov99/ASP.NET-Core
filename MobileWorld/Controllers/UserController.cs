using MobileWorld.Core.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MobileWorld.Core.Models;
using MobileWorld.Core.ViewModels;

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

            var cars = new AdCardViewModel()
            {
                CarId = 33,
                Title = "Sport Car",
                Description = "Mnogo zapazena",
                Price = 333,
            };
            //return View(new List<AdCardViewModel>() { cars});
            return View(result);

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
