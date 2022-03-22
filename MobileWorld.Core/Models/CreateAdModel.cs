using MobileWorld.Core.ViewModels.UserModels;

namespace MobileWorld.Core.Models
{
    public class CreateAdModel
    {
        public CarModel Car { get; set; }

        public RegionModel Region { get; set; }

        public OwnerModel Owner { get; set; } = new();
    }
}
