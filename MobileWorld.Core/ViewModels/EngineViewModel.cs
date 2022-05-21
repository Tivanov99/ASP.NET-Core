using MobileWorld.Core.ViewModels.Contacts;

namespace MobileWorld.Core.ViewModels;

public class EngineViewModel : IEngineViewModel
{
    public int FuelType { get; set; }

    public int HorsePower { get; set; }

    public int? NewtonMeter { get; set; }

    public int EcoLevel { get; set; }

    public int CubicCapacity { get; set; }

    public double FuelConsuption { get; set; }
}
