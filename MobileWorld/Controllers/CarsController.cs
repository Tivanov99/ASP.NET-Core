using MobileWorld.Core.ViewModels;
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

        public IActionResult CarsByCriteria(SearchCarModel model)
        {
            List<CarCardViewModel> cars = this.carService
                .GetAllCarsByCriteria(model);

            return View(cars);
        }
        public IActionResult Details(int carId)
        {
            CarDetailsViewModel car = this.carService
                .GetCarById(carId);

            return View();
        }
    }
}
