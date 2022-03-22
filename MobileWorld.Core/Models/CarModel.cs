using MobileWorld.Infrastructure.Data.Enums;

namespace MobileWorld.Core.Models
{
    public class CarModel : BaseCarModel
    {
        public string Color { get; set; }

        public EngineModel Engine { get; set; }

        public int SeatsCount { get; set; }

        public decimal Mileage { get; set; }
    }
}
