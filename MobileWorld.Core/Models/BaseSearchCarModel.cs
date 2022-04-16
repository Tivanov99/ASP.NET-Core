using MobileWorld.Infrastructure.Data.Enums;

namespace MobileWorld.Core.Models
{
    public class BaseSearchCarModel
    {
        public string Make { get; set; } 

        public string Model { get; set; }

        public decimal? MaxPrice { get; set; }

        public int? FromYear { get; set; }

        public string TownName { get; set; }

        public GearType GearType { get; set; }

        public FuelType  FuelType { get; set; }
    }
}
