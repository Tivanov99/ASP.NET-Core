using MobileWorld.Core.ViewModels.CarViewModels.Details;

namespace MobileWorld.Core.ViewModels.CarViewModels
{
    public class FeaturesViewModel
    {
        public SafetyDetails SafetyDetails { get; set; }

        public ComfortDetails ComfortDetails { get; set; }

        public OthersDetails OthersDetails { get; set; }

        public ExteriorDetails ExteriorDetails { get; set; }

        public ProtectionDetails ProtectionDetails { get; set; }

        public InteriorDetails InteriorDetails { get; set; }
    }
}
