using Microsoft.AspNetCore.Mvc;
using MobileWorld.Core.Contracts;
using MobileWorld.Core.ViewModels;
using MobileWorld.Core.Models;

namespace MobileWorld.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICarService carService;

        public CarsController(ICarService _carService)
        {
            this.carService = _carService;
        }

        public IActionResult CarsByCriteria(AdvancedSearchCarModel searchModel)
        {
            List<AdCardViewModel> cars = this.carService
                .GetAllCarsWithCriteria(searchModel);

            return View(cars);
        }

        public IActionResult CarDetails(int carId)
        {
            var carAd = this.carService
                .GetCarById(carId);

            return View(carAd);
        }

        public IActionResult AdvancedSearch()
        {
            return View("AdvancedSearchView");
        }
    }
}
