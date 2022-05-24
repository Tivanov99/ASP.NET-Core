using MobileWorld.Core.Models.ViewModels.Contacts;
using MobileWorld.Infrastructure.Data.Enums;

namespace MobileWorld.Core.Models.ViewModels;

public class EngineViewModel : IEngineViewModel
{
    public FuelType FuelType { get; set; }

    public int HorsePower { get; set; }

    public int? NewtonMeter { get; set; }

    public int EcoLevel { get; set; }

    public int CubicCapacity { get; set; }

    public double FuelConsuption { get; set; }
}
