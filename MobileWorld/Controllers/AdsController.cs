using Microsoft.AspNetCore.Mvc;
using MobileWorld.Core.Contracts;
using MobileWorld.Core.ViewModels;

namespace MobileWorld.Controllers
{
    public class AdsController : Controller
    {
        private readonly IAdService service;

        public AdsController(IAdService _service)
        {
            this.service = _service;
        }

        public IActionResult AdDetails(string adId)
        {
            var carAd = this.service
                .GetAdById(adId);

            var model = new AdViewModel()
            {

            };
            return View(carAd);
        }
    }
}
