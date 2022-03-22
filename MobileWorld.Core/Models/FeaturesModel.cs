using MobileWorld.Core.Models.Details;

namespace MobileWorld.Core.Models
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
