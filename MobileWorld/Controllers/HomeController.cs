using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MobileWorld.Core.Contracts;
using MobileWorld.Core.ViewModels;
using System.Diagnostics;

namespace MobileWorld.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAdService adService;

        public HomeController(ILogger<HomeController> logger,
            IAdService _adService)
        {
            _logger = logger;
            this.adService = _adService;
        }

        public async Task<IActionResult> Index()
        {
            List<AdCardViewModel> cars = await this.adService
                .GetIndexAds()
                ;
            return View(cars);
        }

        public IActionResult Privacy()
        {
            return Redirect("~/Identity/Account/Login");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}