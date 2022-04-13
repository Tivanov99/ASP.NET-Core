using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MobileWorld.Core.Contracts;
using MobileWorld.Core.Models;
using MobileWorld.Infrastructure.Data.Common;
using MobileWorld.Infrastructure.Data.Identity;

namespace MobileWorld.Controllers
{
    //[Authorize(Roles = GlobalConstants.AdministratorRole)]
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdminController(
            IAdminService adminService,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _adminService = adminService;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Users()
        {
            var users = this._adminService
                .Users();
            foreach (var currUser in users)
            {
                currUser.Role = _userManager
                    .GetRolesAsync(
                                    _userManager.FindByIdAsync(currUser.Id).Result
                                   )
                    .Result[0];
            }
            var list = new List<UserViewModel>()
            {
                new UserViewModel()
                {
                    Id="1",
                    UserName="test",
                    Role= "adminche"
                }
            };
            return View(users);
        }

        //[Authorize(Roles = GlobalConstants.AdministratorRole)]
        public async Task<IActionResult> CreateRolle()
        {
            await _roleManager.CreateAsync(new IdentityRole()
            {
                Name = GlobalConstants.AdministratorRole
            });

            await _roleManager.CreateAsync(new IdentityRole()
            {
                Name = GlobalConstants.BaseRole
            });
            return Ok();
        }
    }
}
