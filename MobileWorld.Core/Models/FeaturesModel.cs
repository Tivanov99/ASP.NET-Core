using MobileWorld.Core.ViewModels.CarViewModels.Details;

namespace MobileWorld.Core.ViewModels.CarViewModels
{
    public class FeaturesModel
    {
        public SafetyDetailsModel SafetyDetails { get; set; } = new();

        public ComfortDetailsModel ComfortDetails { get; set; } = new();

        public OthersDetailsModel OthersDetails { get; set; } = new();

        public ExteriorDetailsModel ExteriorDetails { get; set; } = new();

        public ProtectionDetailsModel ProtectionDetails { get; set; } = new();

        public InteriorDetailsModel InteriorDetails { get; set; } = new();
    }
}
