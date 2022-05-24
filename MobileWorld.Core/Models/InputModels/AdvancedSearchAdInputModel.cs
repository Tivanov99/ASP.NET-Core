using MobileWorld.Core.Models.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace MobileWorld.Core.Models.InputModels
{
    public class AdvancedSearchAdInputModel : BaseSearchAdInputModel
    {
        public FeatureViewModel Features { get; set; } = new();

        public int? ToYear { get; set; }

        [Range(0, (double)decimal.MaxValue, ErrorMessage = "Невалидна минимална цена")]
        public decimal? MinPrice { get; set; }
    }
}
