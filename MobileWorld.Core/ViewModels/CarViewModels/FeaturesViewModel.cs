using MobileWorld.Core.ViewModels.CarViewModels.Details;

namespace MobileWorld.Core.ViewModels.CarViewModels
{
    public class FeaturesViewModel
    {
        public SafetyDetails SafetyDetails { get; set; } = new();

        public ComfortDetails ComfortDetails { get; set; } = new();

        public OthersDetails OthersDetails { get; set; } = new();

        public ExteriorDetails ExteriorDetails { get; set; } = new();

        public ProtectionDetails ProtectionDetails { get; set; } = new();

        public InteriorDetails InteriorDetails { get; set; } = new();
    }
}
