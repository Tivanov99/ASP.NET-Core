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

        public IActionResult AllCars(SearchCarModel model)
        {


            //TODO: make request to db using model 
            return View();
        }
    }
}
