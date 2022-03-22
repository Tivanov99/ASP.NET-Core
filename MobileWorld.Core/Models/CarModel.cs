using MobileWorld.Infrastructure.Data.Enums;
using MobileWorld.Infrastructure.Data.Models;

namespace MobileWorld.Core.Models
{
    public class CarModel
    {
        public string Make { get; set; }

        public string Model { get; set; }

        public string Color { get; set; }

        public int Year { get; set; }

        public GearType GearType { get; set; }

        public EngineModel Engine { get; set; }

        public int SeatsCount { get; set; }

        public decimal Mileage { get; set; }
    }
}
