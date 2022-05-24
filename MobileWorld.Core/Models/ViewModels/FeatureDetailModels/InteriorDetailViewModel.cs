using MobileWorld.Core.Models.ViewModels.FeatureDetailModels.FeatureContracts;

namespace MobileWorld.Core.Models.ViewModels.FeatureDetailModels
{
    public class InteriorDetailViewModel : IInteriorDetailViewModel
    {
        public bool SuedeSaloon { get; set; }

        public bool LeatherSalon { get; set; }

        public bool Taxi { get; set; }

        public bool Educational { get; set; }

        public bool Ruler { get; set; }
    }
}
