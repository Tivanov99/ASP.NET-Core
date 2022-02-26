using Microsoft.AspNetCore.Mvc;
using MobileWorld.Models;

namespace MobileWorld.Controllers
{
    public class UserController : Controller
    {
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
                string error = String.Join(" ", ModelState.Values
                    .SelectMany(e => e.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList());

                return View("Error", new { ErrorMessage = error });
            }

            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                string error = String.Join(" ", ModelState.Values
                    .SelectMany(e => e.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList());

                return View("Error", new { ErrorMessage = error });
            }
            return RedirectToAction("Index");
        }
    }
}
