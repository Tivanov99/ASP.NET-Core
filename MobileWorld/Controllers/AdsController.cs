using Microsoft.AspNetCore.Mvc;
using MobileWorld.Core.Contracts;
using MobileWorld.Core.Models;
using MobileWorld.Core.ViewModels;
using MobileWorld.Infrastructure.Data.Common;
using MobileWorld.Infrastructure.Data.Enums;
using MobileWorld.Infrastructure.Data.Models;

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
        public IActionResult CreateAd(CreateAdModel model, string userId)
        {
            List<Image> images = new List<Image>();

            foreach (var file in Request.Form.Files)
            {
                Image img = new Image();
                img.ImageTitle = file.FileName;

                MemoryStream ms = new MemoryStream();
                file.CopyTo(ms);
                img.ImageData = ms.ToArray();

                ms.Close();
                ms.Dispose();
                images.Add(img);
            }

            return View();
        }

        public IActionResult AdsByCriteria(AdvancedSearchCarModel searchModel)
        {
            List<AdCardViewModel> cars = this.service
                .GetAdsByCriteria(searchModel);

            return View(cars);
        }

        public IActionResult AdvancedSearch()
        {
            return View("AdvancedSearchView");
        }
    }
}
