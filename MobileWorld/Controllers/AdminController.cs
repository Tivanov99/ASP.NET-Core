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
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdminController(
            IAdminService adminService,
            RoleManager<IdentityRole> roleManager)
        {
          _adminService = adminService;
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Users()
        {
            var users = _adminService.Users();
            return null;
        }

        [Authorize(Roles = GlobalConstants.AdministratorRole)]
        public async Task<IActionResult> CreateRolle()
        {
            await roleManager.CreateAsync(new IdentityRole()
            {
                Name = "Administator"
            });

            await roleManager.CreateAsync(new IdentityRole()
            {
                Name = "Base"
            });
            return Ok();
        }
    }
}
