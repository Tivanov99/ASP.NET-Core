using Microsoft.AspNetCore.Mvc;
using MobileWorld.Core.Services;

namespace MobileWorld.Controllers
{
    public class AdsController : Controller
    {
        private readonly AdService service;

        public AdsController(AdService _service)
        {
            this.service = _service;
        }

        public IActionResult AdDetails(string adId)
        {
            var carAd = this.service
                .GetAdById(adId);

            return View(carAd);
        }
    }
}
