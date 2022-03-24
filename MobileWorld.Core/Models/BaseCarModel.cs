using MobileWorld.Infrastructure.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace MobileWorld.Core.Models
{
    public class BaseCarModel
    {
        public string Make { get; set; }

        [Required]
        [StringLength(20)]
        public string Model { get; set; }

        public int Year { get; set; }

        public GearType GearType { get; set; }

        public RegionModel Region { get; set; }

        public decimal MaxPrice { get; set; }

        public EngineModel Engine { get; set; }
    }
}
