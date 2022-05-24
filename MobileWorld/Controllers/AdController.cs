using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MobileWorld.ControllerHelper.Contracts;
using MobileWorld.Core.Models.InputModels;
using MobileWorld.Core.Services.Contracts;
using MobileWorld.Core.ViewModels;
using MobileWorld.Infrastructure.Data.Models;
using MobileWorld.Infrastructure.Data.QueriesAndSPDtoModels;
using MobileWorld.Models;

namespace MobileWorld.Controllers
{
    public class AdController : Controller
    {
        private readonly IAdService _service;
        private readonly IUserService _userService;
        private readonly IImageBinding _imageBinding;

        public AdController(
            IAdService service,
            IUserService userService,
            IImageBinding imageBinding)
        {

            this._service = service;
            this._userService = userService;
            _imageBinding = imageBinding;
        }

        public IActionResult AllAds()
        {
            List<AdCardSpViewModel> cars = this._service
                .GetAllAds();

            if (cars == null)
            {
                return View("Error", new { ErrorMessage = "Нещо се обърка! Опитайте отново." });
            }
            return View(cars);
        }

        public async Task<IActionResult> Ad(string adId)
        {
            var ad = this._service
                .GetAdById(adId);

            return View(ad);
        }

        [Authorize]
        [HttpGet]
        public IActionResult CreateAd()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult CreateAd(ModelBindingAdModel model, string userId)
        {
            if (ModelState.IsValid)
            {
                List<Image> images = _imageBinding
                  .BindImages(Request.Form.Files);

                bool isCreated = this._service.CreateAd(model, userId, images);

                if (!isCreated)
                {
                    return View("Error", new { ErrorMessage = "Нещо се обърка! Опитайте отново." });
                }

                return RedirectToAction("Index", "Home");
            }
            var message = string.Join(" | ", ModelState.Values
             .SelectMany(v => v.Errors)
             .Select(e => e.ErrorMessage));
            return View("Error", new { ErrorMessage = message });
        }

        public IActionResult AdsByCriteria(AdvancedSearchAdInputModel searchModel)
        {
            List<AdCardSpViewModel> cars = this._service
                .GetAdsByAdvancedCriteria(searchModel);

            return View(cars);
        }

        public IActionResult AdsByBaseCriteria(BaseSearchAdInputModel searchModel)
        {
            List<AdCardSpViewModel> result = null;

            if (ModelState.IsValid)
            {
                result = this._service
                               .GetAdsByBaseCriteria(searchModel);
            }
            else 
            {
                var message = string.Join(" | ", ModelState.Values
               .SelectMany(v => v.Errors)
               .Select(e => e.ErrorMessage));
                return View("Error", new { ErrorMessage = message });
            }

            return View("AllAds", result);
        }

        public IActionResult AdvancedSearch()
        {
            return View("AdvancedSearchView");
        }

        public async Task<IActionResult> Delete(string? adId)
        {
            if (adId == null)
            {
                return NotFound();
            }

            var ad = this._service
                .GetAdById(adId);

            if (ad == null)
            {
                return NotFound();
            }

            return View();
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string adId)
        {
            if (adId == null)
            {
                return RedirectToAction("Index", "Home");
            }
            bool result = this._service.Delete(adId);

            if (result == true)
            {
                return RedirectToAction("Index", "Home");
            }
            return View("Error", new { ErrorMessage = "Нещо се обърка! Опитайте отново." });
        }
        public ActionResult Edit(string adId)
        {
            var ad = this._service
                .GetAdForUpdate(adId);

            return View(ad);
        }


        [HttpPost]
        public IActionResult EditPost(ModelBindingAdModel updatedModel, string adId)
        {
            if (adId == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                this._service.Update((AdInputModel)updatedModel, adId);
                return RedirectToAction(actionName: nameof(this.Ad), new { adId = adId });

            }

            var message = string.Join(" | ", ModelState.Values
             .SelectMany(v => v.Errors)
             .Select(e => e.ErrorMessage));
            return View("Error", new { ErrorMessage = message });
        }
    }
}