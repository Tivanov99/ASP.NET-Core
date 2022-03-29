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
            var ad = this.service
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
            return View(ad);
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
            bool isSuccessfully = this.service.CreateAd(model, images, userId);


            //TODO : Redirect correct view after successfully add
            return View();
        }

        public IActionResult AdsByCriteria(AdvancedSearchCarModel searchModel)
        {
            List<AdCardViewModel> cars = this.service
                .GetAdsByAdvancedCriteria(searchModel);

            return View(cars);
        }

        public IActionResult AdsByBaseCriteria(BaseSearchCarModel searchModel)
        {
            var result = this.service.GetAdsByBaseCriteria(searchModel);

            return View();
        }

        public IActionResult AdvancedSearch()
        {
            return View("AdvancedSearchView");
        }
    }
}
