using MobileWorld.Core.ViewModels.CarViewModels;
using Microsoft.AspNetCore.Mvc;
using MobileWorld.Core.Contracts;
using MobileWorld.Core.ViewModels;

namespace MobileWorld.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICarService carService;

        public CarsController(ICarService _carService)
        {
            this.carService = _carService;
        }

        public IActionResult CarsByCriteria(SearchCarViewModel model)
        {
            List<AdViewModel> cars = this.carService
                .GetAllCarsByCriteria(model);

            return View(cars);
        }

        public IActionResult CarDetails(int carId)
        {
            CarViewModel carAd = this.carService
                .GetCarById(carId);

            return View(carAd);
        }

        public IActionResult AdvancedSearch()
        {
            return View("AdvancedSearchView");
        }
    }
}
