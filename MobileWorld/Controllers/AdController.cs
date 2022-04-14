using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MobileWorld.Core.Contracts;
using MobileWorld.Core.Models;
using MobileWorld.Core.ViewModels;
using MobileWorld.Infrastructure.Data.Models;
using MobileWorld.Models;

namespace MobileWorld.Controllers
{
    public class AdController : Controller
    {
        private readonly IAdService service;

        public AdController(IAdService _service)
        {
            this.service = _service;
        }

        public IActionResult Ad(string adId)
        {
            var ad = this.service
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
                this.service.CreateAd((AdInputModel)model, images, userId);

                return RedirectToAction("Index", "Home");
            }

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
            var result = this.service
                .GetAdsByBaseCriteria(searchModel);

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

            var ad = this.service
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
                return RedirectToAction(nameof(Index));
            }

            try
            {
                this.service.Delete(adId);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception /* ex */)
            {
                //Log the error(uncomment ex variable name and write a log.)
                return RedirectToAction(nameof(Delete), new { id = adId, saveChangesError = true });
            }
        }
        public IActionResult Edit(string adId)
        {
            var ad = this.service.GetAdById(adId);
            return View(ad);
        }


        [HttpPost]
        public IActionResult EditPost(AdViewModel updatedModel, string? adId)
        {
            if (adId == null)
            {
                return NotFound();
            }
            Ad ad = new Ad();

            //if(await TryUpdateModelAsync<Ad>(ad,"",x=>x))
            //{

            //}
            bool result = this.service.Update(adId, updatedModel);

            if (!result)
            {
                //TODO : Return some error
            }


            return RedirectToAction(actionName: nameof(this.Ad), new { adId = adId });
        }

    }
}