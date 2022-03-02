using MobileWorld.Core.ViewModels;
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
                string error = this.GetErrors(model);

                return View("Error", new { ErrorMessage = error });
            }

            return RedirectToAction("Login");
        }

        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                string error = this.GetErrors(model);

                return View("Error", new { ErrorMessage = error });
            }

            return RedirectToAction("Login");
        }

        [Authorize]
        public IActionResult Logout()
        {
            this.SignOut();
            return RedirectToAction("Index");
        }
    }
}
