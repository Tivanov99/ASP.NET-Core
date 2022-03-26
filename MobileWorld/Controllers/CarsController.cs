using Microsoft.AspNetCore.Mvc;
using MobileWorld.Core.Contracts;

namespace MobileWorld.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICarService carService;

        public CarsController(ICarService _carService)
        {
            Console.WriteLine(DateTime.Now.Year);
            this.carService = _carService;
        }


        public IActionResult AdvancedSearch()
        {
            return View("AdvancedSearchView");
        }
    }
}
