using MobileWorld.Core.ViewModels;

namespace MobileWorld.Core.Models.InputModels
{
    public class AdvancedSearchAdInputModel : BaseSearchAdInputModel
    {
        public FeatureViewModel Features { get; set; } = new();

        public int? ToYear { get; set; }

        public decimal? MinPrice { get; set; }
    }
}
