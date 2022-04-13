using Microsoft.AspNetCore.Mvc;

namespace MobileWorld.Controllers
{
    public class AdminController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
