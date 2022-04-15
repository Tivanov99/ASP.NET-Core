using MobileWorld.Core.Models.Details;

namespace MobileWorld.Core.Models
{
    public class FeaturesModel
    {
        public FeaturesModel()
        {
            SafetyDetails = new();
            ComfortDetails = new();
            OthersDetails = new();
            ExteriorDetails = new();
            ProtectionDetails = new();
            InteriorDetails = new();
            EngineDetails = new();
        }
        public SafetyDetailModel SafetyDetails { get; set; }

        public ComfortDetailModel ComfortDetails { get; set; }

        public OthersDetailModel OthersDetails { get; set; }

        public ExteriorDetailModel ExteriorDetails { get; set; }

        public ProtectionDetailModel ProtectionDetails { get; set; }

        public InteriorDetailModel InteriorDetails { get; set; }

        public EngineDetailModel EngineDetails { get; set; }

    }
}
