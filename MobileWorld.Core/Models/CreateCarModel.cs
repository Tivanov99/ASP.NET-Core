using MobileWorld.Core.ViewModels.CarViewModels.Details;
using MobileWorld.Core.ViewModels.UserModels;
using MobileWorld.Infrastructure.Data.Enums;

namespace MobileWorld.Core.Models
{
    public class CreateCarModel
    {
        public string Make { get; set; }

        public string Model { get; set; }

        public DateTime CreatedOn { get; set; }

        public GearType GearType { get; set; }

        public FuelType FuelType { get; set; }

        public string Color { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public decimal Mileage { get; set; }

        //public string Title { get; set; }

        //public string Town { get; set; }

        //public string Region { get; set; }

        //public string Neighborhood { get; set; }

        public OwnerViewModel Owner { get; set; } = new();
    }
}
