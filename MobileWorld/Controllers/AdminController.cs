using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MobileWorld.Core.Contracts;
using MobileWorld.Infrastructure.Data.Common;

namespace MobileWorld.Controllers
{

    [Authorize(Roles = GlobalConstants.AdministratorRole)]
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;
        private readonly UserManager<IdentityRole> _userManager;

        public AdminController(
            IAdminService adminService,
            UserManager<IdentityRole> userManager)
        {
          _adminService = adminService;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Users()
        {
            var user = _userManager.FindByIdAsync("da");
            var role = _userManager.GetRolesAsync(user.Result);


            return View();
        }

        [Authorize(Roles = GlobalConstants.AdministratorRole)]
        public async Task<IActionResult> CreateRolle()
        {
            await _userManager.CreateAsync(new IdentityRole()
            {
                Name = "Administator"
            });

            await _userManager.CreateAsync(new IdentityRole()
            {
                Name = "Base"
            });
            return Ok();
        }
    }
}
