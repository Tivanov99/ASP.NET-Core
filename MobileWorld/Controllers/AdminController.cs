using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MobileWorld.Core.Contracts;
using MobileWorld.Core.Models;
using MobileWorld.Infrastructure.Data.Common;
using MobileWorld.Infrastructure.Data.Identity;

namespace MobileWorld.Controllers
{
    [Authorize(Roles = GlobalConstants.AdministratorRole)]
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
        public IActionResult Delete(string userId)
        {
            this._adminService.DeleteUser(userId);
            return this.RedirectToAction(nameof(Users));
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
            return View(users);
        }

        public IActionResult EditUser(string userId)
        {
            var user = this._adminService.GetUserAsViewModel(userId);
            user.Role = _userManager.GetRolesAsync(
                                                    _userManager.FindByIdAsync(user.Id).Result
                                                 ).Result[0];
            return View(user);
        }

        public IActionResult UpdateUser(UserUpdateModel model, string userId)
        {
            var user = this._adminService.GetUserAsViewModel(userId);
            var rolle = _userManager.GetRolesAsync(
                                                     _userManager.FindByIdAsync(user.Id).Result
                                                  ).Result[0];

            bool isInRolle = rolle == model.Role;

           
            if (!isInRolle)
            {
                _userManager.RemoveFromRoleAsync(,rolle)
            }

            //TODO: change user role if is not in rolle
            return this.RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = GlobalConstants.AdministratorRole)]
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
