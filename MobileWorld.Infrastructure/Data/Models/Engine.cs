using MobileWorld.Infrastructure.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace MobileWorld.Infrastructure.Data.Models
{
    public class Engine
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public FuelType FuelType { get; set; }

        [Required]
        [Range(40,2000)]
        public int HorsePower { get; set; }

        [Required]
        [Range(100,2000)]
        public int NewtonMeter { get; set; }

        [Required]
        public bool Turbo { get; set; }

        [Required]
        public bool Hybrid { get; set; }

        [Required]
        [Range(1,7)]
        public int EcoLevel { get; set; }

        [Required]
        public bool AutoGas { get; set; }

        [Required]
        [Range(900,9000)]
        public int CubicCapacity { get; set; }

        [Required]
        [Range(3,100)]
        public double FuelConsuption { get; set; }
    }
}
