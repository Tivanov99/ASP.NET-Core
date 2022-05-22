using MobileWorld.Core.Models;
using MobileWorld.Core.ViewModels;

namespace MobileWorld.Core.Models
{
    public class AdvancedSearchCarModel : BaseSearchAdModel
    {
        public FeatureViewModel Features { get; set; } = new();

        public int? ToYear { get; set; }

        public decimal? MinPrice { get; set; }
    }
}
