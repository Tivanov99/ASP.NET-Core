
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobileWorld.Core.Models
{

    //TODO : Check fuel type, engines are null
    public class CreateAdModel
    {
        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [Column(TypeName = "decimal(6,2)")]
        public decimal Price { get; set; }

        [Required]
        [MaxLength(700)]
        public string Description { get; set; }

        public CarModel Car { get; set; } = new();

        public RegionModel Region { get; set; } = new();

        public OwnerModel Owner { get; set; } = new();

        public FeaturesModel Features { get; set; } = new();

    }
}
