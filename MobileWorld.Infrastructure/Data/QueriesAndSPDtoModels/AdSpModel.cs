using MobileWorld.Infrastructure.Data.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobileWorld.Infrastructure.Data.QueriesAndSPDtoModels
{
    public class AdSpModel
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string PhoneNumber { get; set; }

        public string CreatedOn { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        //CarModel Starts
        public string Make { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public int GearType { get; set; }

        public string Color { get; set; }

        public int SeatsCount { get; set; }

        public decimal Mileage { get; set; }
        //CarModel ends

        //EngineModel starts

        public int FuelType { get; set; }

        public int HorsePower { get; set; }

        public int? NewtonMeter { get; set; }

        public int EcoLevel { get; set; }

        public int CubicCapacity { get; set; }

        public double FuelConsuption { get; set; }
        //EngineModel ends
    }
}
