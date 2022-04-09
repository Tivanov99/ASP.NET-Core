using Microsoft.AspNetCore.Identity;
using MobileWorld.Infrastructure.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace MobileWorld.Infrastructure.Data.Identity
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(45, MinimumLength = 3)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(45,MinimumLength =3)]
        public string LastName { get; set; }

        public List<Ad> Ads { get; set; } = new();

        public List<FavoriteAd> FavoriteAds { get; set; } = new();
    }
}
