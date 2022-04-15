using MobileWorld.Infrastructure.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace MobileWorld.Core.Models
{
    public class EngineModel 
    {
        [Required]
        public FuelType FuelType { get; set; }

        [Required]
        [Range(40, 2000)]
        public int HorsePower { get; set; }

        [Range(100, 2000)]
        public int? NewtonMeter { get; set; }

        public bool Hybrid { get; set; }

        [Required]
        [Range(1, 7)]
        public int EcoLevel { get; set; }

        public bool AutoGas { get; set; }

        [Required]
        [Range(900, 9000)]
        public int CubicCapacity { get; set; }

        [Required]
        [Range(3, 100)]
        public double FuelConsuption { get; set; }
    }
}
