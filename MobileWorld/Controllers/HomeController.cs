using Microsoft.AspNetCore.Mvc;
using MobileWorld.Core.Contracts;
using MobileWorld.Core.ViewModels;
using System.Diagnostics;

namespace MobileWorld.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICarService carService;

        public HomeController(ILogger<HomeController> logger,
            ICarService _carService)
        {
            _logger = logger;
            this.carService = _carService;
        }

        public IActionResult Index()
        {
            var cars = this.carService.GetIndexCars();
            return View(cars);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}