using MobileWorld.Infrastructure.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace MobileWorld.Core.Models
{
    public class BaseCarModel
    {
        [Required]
        [StringLength(30)]
        public string Make { get; set; }

        [Required]
        [StringLength(20)]
        public string Model { get; set; }


        [Range(1886, 2022)]
        public int Year { get; set; }

        [Required]
        public GearType GearType { get; set; }

        public RegionModel Region { get; set; }

        [Range(0,999999)]
        public decimal MaxPrice { get; set; }

        public EngineModel Engine { get; set; }
    }
}
