using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobileWorld.Infrastructure.Data.QueriesAndSPDtoModels
{
    public class CarSpModel
    {
        public string Model { get; set; }
        public int Year { get; set; }
        public int GearType { get; set; }
        public string Color { get; set; }
        public string Make { get; set; }
        public int SeatsCount { get; set; }
        public decimal Mileage { get; set; }


        //public AdSpModel Ad { get; set; }

        //[ForeignKey(nameof(Ad))]

        //public string? AdId { get; set; }
    }
}
