using System.ComponentModel.DataAnnotations;

namespace MobileWorld.Core.Models
{
    public class CarModel : BaseCarModel
    {
        public CarModel()
        {
            Images = new();
            Features = new();
        }

        [Required]
        [StringLength(35)]
        public string Color { get; set; }

        [Required]
        [Range(2, 12,ErrorMessage ="Трябва да е число в диапазона от 2 до 12.")]
        public int SeatsCount { get; set; }

        [Required]
        public decimal Mileage { get; set; }

        public List<byte[]> Images { get; set; }

        public FeaturesModel Features { get; set; }
    }
}
