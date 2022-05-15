using MobileWorld.Core.ViewModels.FeatureDetailModels;

namespace MobileWorld.Core.ViewModels
{
    public class FeatureViewModel
    {
        public ComfortDetailViewModel ComfortDetails { get; set; }

        public ExteriorDetailViewModel ExteriorDetails { get; set; }

        public InteriorDetailViewModel InteriorDetails { get; set; }

        public OthersDetailViewModel OthersDetails { get; set; }

        public ProtectionDetailViewModel ProtectionDetails { get; set; }

        public SafetyDetailViewModel SafetyDetails { get; set; }
    }
}
