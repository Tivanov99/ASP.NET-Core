namespace MobileWorld.Core.Models.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel()
        {
            UserAds = new();
        }
        public string Id { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public List<AdViewModel> UserAds { get; set; }

        public string Role { get; set; }

        public int AdsCount { get; set; }
    }
}
