using Microsoft.AspNetCore.Mvc;

namespace MobileWorld.Controllers
{
    public class MyBaseController : Controller
    {
        public string GetErrors(object model)
        {
            string errors = String.Join(" ", ModelState.Values
                    .SelectMany(e => e.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList());
            return errors;
        }
    }
}
