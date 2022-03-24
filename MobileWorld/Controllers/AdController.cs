using Microsoft.AspNetCore.Mvc;

namespace MobileWorld.Controllers
{
    public class AdController : Controller
    {

        public IActionResult AdDetails(int carId)
        {
            var carAd = this.carService
                .GetCarById(carId);

            return View(carAd);
        }
    }
}
