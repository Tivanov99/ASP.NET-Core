﻿using MobileWorld.Core.ViewModels.UserModels;
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

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.GetErrors(model);
            }
            return RedirectToAction("Login");
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.GetErrors(model);
            }
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public IActionResult Logout()
        {
            this.SignOut();
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public IActionResult Favourites(string userId)
        {
            //TODO: check here , and add view
            return View();
        }

        [Authorize]
        public IActionResult Ads()
        {
            //TODO: check here , and add view
            return View();
        }

    }
}
