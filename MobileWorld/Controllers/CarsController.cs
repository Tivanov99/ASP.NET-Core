using Microsoft.AspNetCore.Mvc;
using MobileWorld.Models;

namespace MobileWorld.Controllers
{
    public class CarsController : Controller
    {
        public IActionResult AllCars(SearchCarModel model)
        {
            return View();
        }
    }
}
