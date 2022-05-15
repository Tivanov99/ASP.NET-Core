using MobileWorld.Core.Models.Contracts;
using MobileWorld.Infrastructure.Data.Enums;
using MobileWorld.Infrastructure.Data.QueriesAndSPDtoModels;

namespace MobileWorld.Core.ViewModels
{
    public class CarViewModel : ICarModel
    {
        public string Make { get; set; }

        public string Color { get; set; }

        public int SeatsCount { get; set; }

        public decimal Mileage { get; set; }

        public int Year { get; set; }

        public GearType GearType { get; set; }

        public EngineViewModel Engine { get; set; }

        public FeatureViewModel Features { get; set; }
    }
}
