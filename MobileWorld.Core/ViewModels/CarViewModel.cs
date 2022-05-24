using MobileWorld.Core.ViewModels.Contacts;
using MobileWorld.Infrastructure.Data.Enums;

namespace MobileWorld.Core.ViewModels
{
    public class CarViewModel : ICarViewModel
    {
        public CarViewModel()
        {
            Engine = new EngineViewModel();
            Features = new FeatureViewModel();
        }

        public string Make { get; set; }

        public string Color { get; set; }

        public int SeatsCount { get; set; }

        public decimal Mileage { get; set; }

        public int Year { get; set; }

        public GearType GearType { get; set; }

         public  IEngineViewModel Engine { get; set; }

        public IFeatureViewModel Features { get; set; }
    }
}
