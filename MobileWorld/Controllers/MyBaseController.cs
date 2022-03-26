using Microsoft.AspNetCore.Mvc;

namespace MobileWorld.Controllers
{
    public class MyBaseController : Controller
    {
        public IActionResult GetErrors(object model)
        {
            string errors = String.Join(" ", ModelState.Values
                    .SelectMany(e => e.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList());

            return View("Error", new { ErrorMessage = errors });
        }

    }
}
