using MobileWorld.Core.ViewModels.CarViewModels;

namespace MobileWorld.Core.Models
{
    public class AdvancedSearchCarModel : BaseSearchCarModel
    {
        public FeaturesModel Features { get; set; }

        public int ToYear { get; set; }
    }
}
