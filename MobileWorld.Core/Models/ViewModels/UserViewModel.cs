﻿using MobileWorld.Core.Models.ViewModels.Contacts;

namespace MobileWorld.Core.Models.ViewModels
{
    public class UserViewModel : IUserViewModel
    {
        public UserViewModel()
        {
            UserAdsIds = new();
        }

        public string Id { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public List<string> UserAdsIds { get; set; }

        public string Role { get; set; }

        public int AdsCount { get; set; }
    }
}
