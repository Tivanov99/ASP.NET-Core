using Microsoft.AspNetCore.Identity;
using MobileWorld.Infrastructure.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace MobileWorld.Infrastructure.Data.Identity
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(30)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(40)]
        public string LastName { get; set; }

        public List<Ad> Ads { get; set; } = new();
    }
}
