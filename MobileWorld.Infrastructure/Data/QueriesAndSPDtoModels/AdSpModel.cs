using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobileWorld.Infrastructure.Data.QueriesAndSPDtoModels
{
    public class AdSpModel
    {
        //[Key]
        //public string? Id { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }

        public string PhoneNumber { get; set; }

        public string Description { get; set; }

        //[ForeignKey(nameof(Car))]
        //public int? CarId { get; set; }
        //public CarSpModel Car { get; set; }

        //public bool AutoGas { get; set; }

        //public int CubicCapacity { get; set; }

        //public int EcoLevel { get; set; }

        //public double FuelConsuption { get; set; }

        //public int FuelType { get; set; }

        //public int HorsePower { get; set; }

        //public bool Hybrid { get; set; }
    }
}
