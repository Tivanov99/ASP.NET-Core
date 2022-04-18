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
        private Microsoft.AspNetCore.Hosting.IHostingEnvironment Environment;
        private readonly IAdService service;


        public AdController(Microsoft.AspNetCore.Hosting.IHostingEnvironment _environment,
            IAdService _service)
        {
            Environment = _environment;
            this.service = _service;
        }

       public IActionResult AllAds()
        {
            List<AdCardViewModel> cars = this.service
                .GetAllAds();
            return View(cars);
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
                string wwwPath = this.Environment.WebRootPath;
                string contentPath = this.Environment.ContentRootPath;

                string path = Path.Combine(this.Environment.WebRootPath, "Uploads");

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                List<string> uploadedFiles = new List<string>();
                foreach (IFormFile postedFile in Request.Form.Files)
                {
                    string fileName = Path.GetFileName(postedFile.FileName);
                    using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                    {
                        postedFile.CopyTo(stream);
                        uploadedFiles.Add(fileName);
                    }
                }

                this.service.CreateAd(model, userId, uploadedFiles, "Uploads");

                return RedirectToAction("Index", "Home");
            }
                var message = string.Join(" | ", ModelState.Values
                 .SelectMany(v => v.Errors)
                 .Select(e => e.ErrorMessage));
                return View("Error", new { ErrorMessage =message});
                //TODO; return error to correct view
        }

        public IActionResult AdsByCriteria(AdvancedSearchCarModel searchModel)
        {
            List<AdCardViewModel> cars = this.service
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
                return RedirectToAction("Index", "Home");
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
            var ad = this.service
                .GetAdById(adId);
            return View(ad);
        }


        [HttpPost]
        public IActionResult EditPost(ModelBindingAdModel updatedModel, string? adId)
        {
            if (adId == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                this.service.Update(updatedModel, adId);
                return RedirectToAction(actionName: nameof(this.Ad), new { adId = adId });

            }
           
                var message = string.Join(" | ", ModelState.Values
                 .SelectMany(v => v.Errors)
                 .Select(e => e.ErrorMessage));
                return View("Error", new { ErrorMessage = message });
        }
    }
}