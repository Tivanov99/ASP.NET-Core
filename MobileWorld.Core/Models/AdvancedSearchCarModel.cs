using MobileWorld.Core.Models;

namespace MobileWorld.Core.Models
{
    public class AdvancedSearchCarModel : BaseSearchCarModel
    {
        public FeaturesModel Features { get; set; } = new();

        public int? ToYear { get; set; }

        public decimal? MinPrice { get; set; }
    }
}
