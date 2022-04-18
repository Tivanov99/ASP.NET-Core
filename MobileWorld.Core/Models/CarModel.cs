using MobileWorld.Infrastructure.Data.Models;

namespace MobileWorld.Core.Models
{
    public class CarModel : BaseCarModel
    {
        public string Color { get; set; }

        public int SeatsCount { get; set; }

        public decimal Mileage { get; set; }

        public Feature Features { get; set; }
    }
}
