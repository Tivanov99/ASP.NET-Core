
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobileWorld.Core.Models
{
    //TODO : Check fuel type, engines are null
    public class AdInputModel
    {
        public AdInputModel()
        {
            Car = new();
            Region = new();
            Owner = new();
            Features = new();
        }
        [Required]
        [MinLength(5)]
        [StringLength(50, ErrorMessage = "Заглавието трябва да е меджу 5 и 50 символа.")]
        public string Title { get; set; }

        [Range(0, 2000000)]
        public virtual decimal Price { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(700)]
        [MinLength(30)]
        public string Description { get; set; }

        public CarModel Car { get; set; } 

        public RegionModel Region { get; set; } 

        public OwnerModel Owner { get; set; } 

        public FeaturesModel Features { get; set; }
    }
}
