using MobileWorld.Core.ViewModels;
using Microsoft.AspNetCore.Mvc;

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
