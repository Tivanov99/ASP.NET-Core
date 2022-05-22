using MobileWorld.Infrastructure.Data.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobileWorld.Infrastructure.Data.QueriesAndSPDtoModels
{
    public class AdCardSpViewModel
    {
        public string AdId { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }

        public string ImageTitle { get; set; }

        public int HorsePower { get; set; }

        public FuelType FuelType { get; set; }

        public decimal Mileage { get; set; }

        public int Year { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
