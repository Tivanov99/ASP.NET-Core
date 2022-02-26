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
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }
    }
}
