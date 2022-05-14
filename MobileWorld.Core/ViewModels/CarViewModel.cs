using MobileWorld.Infrastructure.Data.QueriesAndSPDtoModels;

namespace MobileWorld.Core.ViewModels
{
    public class CarViewModel
    {
        public string Make { get; set; }

        public string Color { get; set; }

        public int SeatsCount { get; set; }

        public decimal Mileage { get; set; }

        public int Year { get; set; }

        public int GearType { get; set; }

        public EngineViewModel Engine { get; set; }
    }
}
