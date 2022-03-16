using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobileWorld.Infrastructure.Data.Models
{
    public class Ad
    {
        public string Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [Required]
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

        [Range(0, 999999)]
        public decimal Price { get; set; }

        [Required]
        [MaxLength(700)]
        public string Description { get; set; }
    }
}
