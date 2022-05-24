using MobileWorld.Core.ViewModels.Contacts;
using MobileWorld.Core.ViewModels.FeatureDetailModels;
using MobileWorld.Core.ViewModels.FeatureDetailModels.FeatureContracts;

namespace MobileWorld.Core.ViewModels
{
    public class FeatureViewModel : IFeatureViewModel
    {
        public FeatureViewModel()
        {
            ComfortDetails = new ComfortDetailViewModel();
            ExteriorDetails = new ExteriorDetailViewModel();
            InteriorDetails = new InteriorDetailViewModel();
            OthersDetails = new OthersDetailViewModel();
            ProtectionDetails = new ProtectionDetailViewModel();
            SafetyDetails = new SafetyDetailViewModel();
        }
        public IComfortDetailViewModel ComfortDetails { get; set; }

        public IExteriorDetailViewModel ExteriorDetails { get; set; }

        public IInteriorDetailViewModel InteriorDetails { get; set; }

        public IOthersDetailViewModel OthersDetails { get; set; }

        public IProtectionDetailViewModel ProtectionDetails { get; set; }

        public ISafetyDetailViewModel SafetyDetails { get; set; }
    }
}
