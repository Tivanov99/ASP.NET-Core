using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MobileWorld.ControllerHelper.Contracts;
using MobileWorld.Core.Contracts;
using MobileWorld.Core.Models;
using MobileWorld.Core.ViewModels;
using MobileWorld.Infrastructure.Data.Models;
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

        public async Task<IActionResult> AllAds()
        {
            List<AdCardViewModel> cars = await this._service
                 .GetAllAds();

            return View(cars);
        }

        public async Task<IActionResult> Ad(string adId)
        {
            var ad = await this._service
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
                

                this._service.CreateAd(model, userId, images, "Uploads");

                return RedirectToAction("Index", "Home");
            }
            var message = string.Join(" | ", ModelState.Values
             .SelectMany(v => v.Errors)
             .Select(e => e.ErrorMessage));
            return View("Error", new { ErrorMessage = message });
        }

        public IActionResult AdsByCriteria(AdvancedSearchCarModel searchModel)
        {
            List<AdCardViewModel> cars = this._service
                .GetAdsByAdvancedCriteria(searchModel);

            return View(cars);
        }

        public IActionResult AdsByBaseCriteria(BaseSearchCarModel searchModel)
        {
            //var result = this.service
            //    .GetAdsByBaseCriteria(searchModel);

            return View();
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

            try
            {
                this._service.Delete(adId);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception /* ex */)
            {
                //Log the error(uncomment ex variable name and write a log.)
                return RedirectToAction(nameof(Delete), new { id = adId, saveChangesError = true });
            }
        }
        public async Task<ActionResult> Edit(string adId)
        {
            var ad = await this._service
                .GetAdById(adId);
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
                this._service.Update(updatedModel, adId);
                return RedirectToAction(actionName: nameof(this.Ad), new { adId = adId });

            }

            var message = string.Join(" | ", ModelState.Values
             .SelectMany(v => v.Errors)
             .Select(e => e.ErrorMessage));
            return View("Error", new { ErrorMessage = message });
        }
    }
}