using MobileWorld.Core.ViewModels.CarViewModels.Details;
using MobileWorld.Core.ViewModels.UserModels;

namespace MobileWorld.Core.ViewModels.CarViewModels
{
    public class CarAdViewModel
    {
        public string Title { get; set; }

        public string Town { get; set; }

        public string Region { get; set; }

        public string Neighborhood { get; set; }

        public CarDetailsViewModel Car { get; set; } = new();

        public OwnerViewModel Owner { get; set; } = new();


    }
}
