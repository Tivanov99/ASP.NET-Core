using System.ComponentModel.DataAnnotations.Schema;

namespace MobileWorld.Infrastructure.Data.QueriesAndSPDtoModels
{
    public class AdSpModel
    {
        [Column("AdId")]
        public string Id { get; set; }

        [Column("Title")]
        public string Title { get; set; }

        [Column("Price")]
        public decimal Price { get; set; }

        [Column("PhoneNumber")]
        public string PhoneNumber { get; set; }

        [Column("Description")]
        public string Description { get; set; }

        //[Column("Model")]
        //public string Model { get; set; }

        [Column("Year")]
        public int Year { get; set; }

        [Column("GearType")]
        public int GearType { get; set; }

        [Column("Color")]
        public string Color { get; set; }

        [Column("Make")]
        public string Make { get; set; }

        [Column("SeatsCount")]
        public int SeatsCount { get; set; }

        [Column("Mileage")]
        public decimal Mileage { get; set; }

        //public bool AutoGas { get; set; }

        //public int CubicCapacity { get; set; }

        //public int EcoLevel { get; set; }

        //public double FuelConsuption { get; set; }

        //public int FuelType { get; set; }

        //public int HorsePower { get; set; }

        //public bool Hybrid { get; set; }
    }
}
