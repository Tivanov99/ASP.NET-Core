using Microsoft.AspNetCore.Mvc;

namespace MobileWorld.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
