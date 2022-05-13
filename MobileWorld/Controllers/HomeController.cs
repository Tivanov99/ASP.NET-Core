using Microsoft.AspNetCore.Mvc;
using MobileWorld.Core.Contracts;
using MobileWorld.Core.ViewModels;
using MobileWorld.Infrastructure.Data.QueriesAndSPDtoModels;

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
            List<AdSpViewModel> cars = await this.adService
                .GetIndexAds();
            return View(cars);
        }

        public IActionResult Privacy()
        {
            return Redirect("~/Identity/Account/Login");
        }

    }
}