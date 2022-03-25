using MobileWorld.Core.Models;
using MobileWorld.Infrastructure.Data.Common;

namespace MobileWorld.Core.ViewModels
{
    public class AdViewModel
    {
        public string Title { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string CreatedOn { get; set; }

        public CarModel Car { get; set; }

        public OwnerModel Owner { get; set; }

        public RegionModel Region { get; set; }

        public FeaturesModel Features { get; set; } = new();
    }
}
