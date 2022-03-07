using MobileWorld.Core.ViewModels.CarViewModels;
using Microsoft.AspNetCore.Mvc;
using MobileWorld.Core.Contracts;

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
            List<CarCardViewModel> cars = this.carService
                .GetAllCarsByCriteria(model);

            return View(cars);
        }

        public IActionResult CarDetails(string carId)
        {
            CarAdViewModel carAd = this.carService
                .GetCarById(carId);

            return View(carAd);
        }

        public IActionResult DetailedSearch()
        {
            return View("DetailedSearchView");
        }
    }
}
