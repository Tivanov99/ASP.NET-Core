using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobileWorld.Core.Models
{
    public class CarModel : BaseCarModel
    {
        [Required]
        [StringLength(35)]
        public string Color { get; set; }

        [Required]
        [Range(2, 12)]
        public int SeatsCount { get; set; }

        [Required]
        [Column(TypeName = "decimal(6,3)")]
        public decimal Mileage { get; set; }

        [Range(0,999999)]
        public decimal MinPrice { get; set; }
    }
}
