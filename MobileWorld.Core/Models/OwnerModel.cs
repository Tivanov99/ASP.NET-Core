using System.ComponentModel.DataAnnotations;

namespace MobileWorld.Core.Models
{
    public class OwnerModel
    {
        public string? OwnerId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public bool IsFavoriteAd { get; set; }
    }
}
