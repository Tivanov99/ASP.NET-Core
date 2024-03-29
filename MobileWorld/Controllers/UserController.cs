﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MobileWorld.Core.Services.Contracts;

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
        public IActionResult Favorite(string adId, string userId)
        {
            if(userId == null || adId==null)
            {
                return Redirect("~/Identity/Account/Login");
            }

            bool result = this.userService.AddToFavorites(adId, userId);
            return RedirectToAction("Ad", "Ad", new { adId = adId });
        }
        public IActionResult UnFavorite(string adId, string userId)
        {
            if(adId == null || userId == null)
            {
                return Redirect("~/Identity/Account/Login");
            }

            bool result = this.userService.RemoveFromFavorites(adId, userId);
            return RedirectToAction("Ad", "Ad", new { adId = adId });
        }



    }
}
