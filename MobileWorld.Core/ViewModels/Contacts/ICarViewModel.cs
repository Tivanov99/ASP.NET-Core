using MobileWorld.Infrastructure.Data.Enums;

namespace MobileWorld.Core.ViewModels.Contacts
{
    internal interface ICarViewModel
    {
        public string Make { get; set; }

        public string Color { get; set; }

        public int SeatsCount { get; set; }

        public decimal Mileage { get; set; }

        public int Year { get; set; }

        public GearType GearType { get; set; }

        public IEngineViewModel Engine { get; set; }

        public FeatureViewModel Features { get; set; }
    }
}
