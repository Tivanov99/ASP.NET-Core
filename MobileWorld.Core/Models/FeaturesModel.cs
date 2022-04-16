using MobileWorld.Core.Models.Details;
using MobileWorld.Infrastructure.Data.Models;

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
        }
        public virtual SafetyDetailModel SafetyDetails { get; set; }

        public virtual ComfortDetailModel ComfortDetails { get; set; }

        public virtual OthersDetailModel OthersDetails { get; set; }

        public virtual ExteriorDetailModel ExteriorDetails { get; set; }

        public virtual ProtectionDetailModel ProtectionDetails { get; set; }

        public virtual InteriorDetailModel InteriorDetails { get; set; }
    }
}
