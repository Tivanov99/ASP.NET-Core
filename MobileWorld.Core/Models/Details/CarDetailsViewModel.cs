using MobileWorld.Infrastructure.Data.Enums;

namespace MobileWorld.Core.Models.Details
{
    public class CarDetailsViewModel
    {
        public DateTime CreatedOn { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public GearType GearType { get; set; }

        public FuelType FuelType { get; set; }

        public string Color { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public decimal Mileage { get; set; }
    }
}
