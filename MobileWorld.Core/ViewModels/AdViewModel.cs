using MobileWorld.Core.Models;
using MobileWorld.Infrastructure.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace MobileWorld.Core.ViewModels
{
    public class AdViewModel
    {
        public string Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Phone]
        [Required]
        public string PhoneNumber { get; set; }

        public CarModel Car { get; set; }

        public RegionModel Region { get; set; }

        public string CreatedOn { get; set; }

        public decimal Price { get; set; }

        [Required]
        [MaxLength(700)]
        public string Description { get; set; }


        public OwnerModel Owner { get; set; }

        public List<Image> Images { get; set; } = new();
    }
}
