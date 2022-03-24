using Microsoft.AspNetCore.Mvc;

namespace MobileWorld.Controllers
{
    public class AdController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
