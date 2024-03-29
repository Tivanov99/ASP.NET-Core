﻿using Microsoft.EntityFrameworkCore;
using MobileWorld.Core.Models.ViewModels;
using MobileWorld.Core.Services.Contracts;
using MobileWorld.Infrastructure.Data.Common;
using MobileWorld.Infrastructure.Data.Identity;
using MobileWorld.Infrastructure.Data.Repositories;

namespace MobileWorld.Core.Services
{
    public class AdminService : IAdminService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AdminService(
            IUnitOfWork unit
            )
        {
            _unitOfWork = unit;
        }

        public void DeleteUser(string userId)
        {
            _unitOfWork
                .UserRepository
                .Delete(userId);
        }

        public UserViewModel GetUserAsViewModel(string userId)
        {
            var user = this._unitOfWork
                .UserRepository
                .GetAsQueryable()
                .Include(u => u.Ads)
                .Where(u => u.Id == userId)
                .Select(u => new UserViewModel()
                {
                    Id = u.Id,
                    UserName = u.UserName,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email,
                    AdsCount = u.Ads.Count,
                    UserAdsIds = u.Ads.Select(x=>x.Id).ToList()
                })
                .FirstOrDefault();

            return user;
        }

        public IEnumerable<UserViewModel> Users()
        => this._unitOfWork
                .UserRepository
                .GetAsQueryable()
                .Select(u => new UserViewModel()
                {
                    Id = u.Id,
                    UserName = u.UserName
                })
                .ToList();

        public async Task<ApplicationUser> GetApplicationUser(string userId)
        {
            var result = this._unitOfWork
                .UserRepository
                .GetById(userId);

            return result;
        }
    }
}
