using MobileWorld.Core.Models.ViewModels.FeatureDetailModels.FeatureContracts;

namespace MobileWorld.Core.Models.ViewModels.FeatureDetailModels
{
    public class ExteriorDetailViewModel : IExteriorDetailViewModel
    {
        public bool HalogenHeadlights { get; set; }

        public bool Coupe { get; set; }

        public bool Sedan { get; set; }

        public bool LedHeadlights { get; set; }

        public bool XenonLights { get; set; }

        public bool AlloyWheels { get; set; }

        public bool Metallic { get; set; }

        public bool PanoramicSunroof { get; set; }

        public bool Spoilers { get; set; }

        public bool Shibedah { get; set; }
    }
}
