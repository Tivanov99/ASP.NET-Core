using MobileWorld.Core.ViewModels.CarViewModels.Details;

namespace MobileWorld.Core.ViewModels.CarViewModels
{
    public class FeaturesViewModel
    {
        public SafetyDetailsViewModel SafetyDetails { get; set; } = new();

        public ComfortDetailsViewModel ComfortDetails { get; set; } = new();

        public OthersDetailsViewModel OthersDetails { get; set; } = new();

        public ExteriorDetailsViewModel ExteriorDetails { get; set; } = new();

        public ProtectionDetailsViewModel ProtectionDetails { get; set; } = new();

        public InteriorDetailsViewModel InteriorDetails { get; set; } = new();
    }
}
