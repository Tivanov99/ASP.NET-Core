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
                List<string> errors = ModelState.Values
                    .SelectMany(e => e.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

            }
            return View(model);
        }
    }
}
