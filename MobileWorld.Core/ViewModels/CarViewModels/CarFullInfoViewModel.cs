namespace MobileWorld.Core.ViewModels.CarViewModels
{
    public class CarFullInfoViewModel
    {
        public string Make { get; set; }

        public string Location { get; set; }

        public int? HorsePower { get; set; }

        public string GearType { get; set; }

        public string EngineType { get; set; }

        public FeaturesViewModel Features { get; set; } = new();
    }
}
