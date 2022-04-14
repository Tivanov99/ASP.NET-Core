﻿using Microsoft.AspNetCore.Identity;
using MobileWorld.Core.Models;
using MobileWorld.Infrastructure.Data.Identity;

namespace MobileWorld.Core.Contracts
{
    public interface IAdminService
    {
        IEnumerable<UserViewModel> Users();

        ApplicationUser GetUser(string userId);

        void DeleteUser(string userId);
    }
}
