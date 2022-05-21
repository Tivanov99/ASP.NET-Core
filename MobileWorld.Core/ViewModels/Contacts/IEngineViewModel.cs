namespace MobileWorld.Core.ViewModels.Contacts
{
    public interface IEngineViewModel
    {
        public int FuelType { get; set; }

        public int HorsePower { get; set; }

        public int? NewtonMeter { get; set; }

        public int EcoLevel { get; set; }

        public int CubicCapacity { get; set; }

        public double FuelConsuption { get; set; }
    }
}
