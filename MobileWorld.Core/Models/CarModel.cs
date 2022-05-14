using MobileWorld.Infrastructure.Data.Models;

namespace MobileWorld.Core.Models
{
    public class CarModel : BaseCarModel
    {
        public int Year { get; set; }
        public string Color { get; set; }

        public int SeatsCount { get; set; }

        public decimal Mileage { get; set; }
        //public FeaturesModel Features { get; set; }
    }
}
