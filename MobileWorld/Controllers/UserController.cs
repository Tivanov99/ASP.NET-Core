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
            //TODO: check here , and add view
            return View();
        }

        [Authorize]
        public IActionResult Ads(string userId)
        {
            //TODO: check here , and add view
            return View();
        }
    }
}
