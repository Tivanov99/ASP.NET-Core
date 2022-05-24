using MobileWorld.Core.Models.ViewModels.Contacts;

namespace MobileWorld.Core.Models.ViewModels
{
    public class RegionViewModel : IRegionViewModel
    {
        public string RegionName { get; set; }

        public string Neiborhood { get; set; }

        public string TownName { get; set; }
    }
}
