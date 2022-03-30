using MobileWorld.Infrastructure.Data.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobileWorld.Infrastructure.Data.Models
{
    public class Ad
    {
        [Key]
        public string Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [Required]
        [Phone]
        public int PhoneNumber { get; set; }

        [ForeignKey(nameof(Car))]
        public int CarId { get; set; }

        public Car Car { get; set; }

        [Required]
        [ForeignKey(nameof(Region))]
        public int RegionId { get; set; }

        public Region Region { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        public decimal Price { get; set; }

        [Required]
        [MaxLength(700)]
        public string Description { get; set; }

        [ForeignKey(nameof(Owner))]
        public string OwnerId { get; set; }

        public ApplicationUser Owner { get; set; }

        public List<FavoriteAd> Fans { get; set; } = new();

        public List<Image> Images { get; set; } = new();
    }
}
