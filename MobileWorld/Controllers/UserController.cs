using MobileWorld.Core.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

namespace MobileWorld.Controllers
{
    public class UserController : MyBaseController
    {
        private readonly IUserService userService;
        private readonly RoleManager<IdentityRole> roleManager;
        public UserController(IUserService _userService,
            RoleManager<IdentityRole> _roleManager)
        {
            this.userService = _userService;
            this.roleManager = _roleManager;
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

        public async Task<IActionResult> CreateRole()
        {

        }

    }
}
