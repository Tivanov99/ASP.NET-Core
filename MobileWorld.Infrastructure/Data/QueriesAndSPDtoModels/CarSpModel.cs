using System.ComponentModel.DataAnnotations.Schema;

namespace MobileWorld.Infrastructure.Data.QueriesAndSPDtoModels
{
    [ComplexType]
    public class CarSpModel
    {
        [Column("CarId")]
        public int Id { get; set; }
        [Column("Model")]
        public string Model { get; set; }

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
    }
}
