using MobileWorld.Core.ViewModels.UserModels;
using MobileWorld.Infrastructure.Data.Models;

namespace MobileWorld.Core.Models
{
    public class CreateAdModel
    {
        public Car Car { get; set; }

        public RegionModel Region { get; set; }

        public OwnerModel Owner { get; set; } = new();
    }
}
