using MobileWorld.Infrastructure.Data.Enums;

namespace MobileWorld.Core.Models.Contracts
{
    internal interface ICarModel
    {
        public string Make { get; set; }

        public string Color { get; set; }

        public int SeatsCount { get; set; }

        public decimal Mileage { get; set; }

        public int Year { get; set; }

        public GearType GearType { get; set; }
    }
}
