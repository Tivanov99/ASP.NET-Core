using MobileWorld.Infrastructure.Data.Enums;

namespace MobileWorld.Core.Models
{
    public class BaseSearchCarModel
    {
        public string Make { get; set; } 

        //public string Model { get; set; }

        public decimal? Price { get; set; }

        public int? Year { get; set; }

        public string TownName { get; set; }

        public int? GearType { get; set; }

        public int?  FuelType { get; set; }
    }
}
