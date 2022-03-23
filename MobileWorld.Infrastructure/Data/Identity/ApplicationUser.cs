using Microsoft.AspNetCore.Identity;
using MobileWorld.Infrastructure.Data.Models;

namespace MobileWorld.Infrastructure.Data.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public List<Ad> Ads { get; set; } = new();

        public List<FavoriteAd> FavoriteAds { get; set; } = new();
    }
}
