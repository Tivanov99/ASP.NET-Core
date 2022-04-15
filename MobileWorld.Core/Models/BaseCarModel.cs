using MobileWorld.Infrastructure.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace MobileWorld.Core.Models
{
    public class BaseCarModel
    {
        [Required]
        public string Make { get; set; }

        //[Required]
        //[StringLength(20)]
        //public string Model { get; set; }

        [Range(1886,2022,ErrorMessage ="Годината трябва да е между 1886 и 2022")]
        public int Year { get; set; }

        [Required]
        public GearType GearType { get; set; }

        [Range(0, 2000000)]
        public decimal MaxPrice { get; set; }

        public EngineModel Engine { get; set; }
    }
}
