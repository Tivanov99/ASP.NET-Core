using MobileWorld.Infrastructure.Data.Enums;

namespace MobileWorld.Core.Models.ViewModels.Contacts
{
    public interface IEngineViewModel
    {
        public FuelType FuelType { get; set; }

        public int HorsePower { get; set; }

        public int? NewtonMeter { get; set; }

        public int EcoLevel { get; set; }

        public int CubicCapacity { get; set; }

        public double FuelConsuption { get; set; }
    }
}
