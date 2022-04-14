﻿namespace MobileWorld.Core.Models
{
    public class UserViewModel
    {
        public UserViewModel()
        {
            Roles= new List<string>();
        }
        public string Id { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public int MyProperty { get; set; }

        public List<string> Roles { get; set; } 
    }
}
