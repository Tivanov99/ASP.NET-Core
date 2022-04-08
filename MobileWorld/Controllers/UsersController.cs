﻿using MobileWorld.Core.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MobileWorld.Core.ViewModels;

namespace MobileWorld.Controllers
{
    public class UsersController : MyBaseController
    {
        private readonly IUserService userService;
        public UsersController(IUserService _userService)
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

    }
}
