using Microsoft.AspNetCore.Mvc;
using MobileWorld.Core.Contracts;
using MobileWorld.Core.Models;
using MobileWorld.Core.ViewModels;
using MobileWorld.Infrastructure.Data.Common;
using MobileWorld.Infrastructure.Data.Enums;

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
                Description = "mngoo nova",
                CreatedOn = DateTime.UtcNow.ToString(GlobalConstants.dateTimeFormat),
                Owner = new OwnerModel()
                {
                    PhoneNumber = 0893668829,

                },
                Region = new RegionModel()
                {
                    RegionName = "Burgas",
                    Neiborhood = "Vuzrajdane",
                    Town = new TownModel()
                    {
                        Name = "Burgas",
                    }
                },
                Car = new CarModel()
                {
                    GearType = GearType.Автоматична,
                    Mileage = 180000,
                    Color = "Mid night",
                    Engine = new EngineModel()
                    {
                        FuelType = FuelType.Безин,
                        HorsePower = 230,
                        EcoLevel = 4,
                    }
                }
            };
            return View(model);
        }


        //[Authorize]
        [HttpGet]
        public IActionResult CreateAd()
        {
            return View();
        }

        //[Authorize]
        [HttpPost]
        public IActionResult CreateAd(CreateAdModel model)
        {
            return View();
        }
    }
}
