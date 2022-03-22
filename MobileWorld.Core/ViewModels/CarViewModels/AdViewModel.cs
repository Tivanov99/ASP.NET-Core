using MobileWorld.Core.Models;

namespace MobileWorld.Core.ViewModels.CarViewModels
{
    public class AdViewModel
    {
        public string Title { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public CarModel Car { get; set; }

        public OwnerModel Owner { get; set; }

        public FeaturesModel Features { get; set; } = new();
    }
}
