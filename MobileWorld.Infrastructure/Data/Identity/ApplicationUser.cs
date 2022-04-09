using Microsoft.AspNetCore.Identity;
using MobileWorld.Infrastructure.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace MobileWorld.Infrastructure.Data.Identity
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(40,ErrorMessage ="Потребителското име трябва да е между 5 и {0} символа")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(40, ErrorMessage = "Фамилното име трябва да е между 5 и {0} символа")]
        public string LastName { get; set; }

        public List<Ad> Ads { get; set; } = new();

        public List<FavoriteAd> FavoriteAds { get; set; } = new();
    }
}
