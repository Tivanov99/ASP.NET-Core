using MobileWorld.Core.ViewModels;

namespace MobileWorld.Core.Models
{
    public class UserViewModel
    {
        public UserViewModel()
        {
            Roles= new ();
            UserAds = new();
        }
        public string Id { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public List<AdViewModel> UserAds { get; set; } 

        public List<string> Roles { get; set; }

        public int AdsCount { get; set; }
    }
}
