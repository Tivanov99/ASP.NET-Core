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

            car.Description = "ВЪЗМОЖЕН ЛИЗИНГ БЕЗ ДОКАЗВАНЕ НА ДОХОДИ, ПРИ МИНИМАЛНА ПЪРВОНАЧАЛНА ВНОСКА СТАРТИРАЩА ОТ 10% ОДОБРЕНИЕ И РЕГИСТРАЦИЯ В РАМКИТЕ НА ДЕНЯ. Автомобила е от шоурум на BMW в Южна Швейцария (Мендризо). Само един собственик който го връща в представителството и взима нов. Пълна подръжка и документация за всяко обслужване на 15 хиляди километра изцяло, и единствено в сервиз на BMW.";
            return View(car);
        }
    }
}
