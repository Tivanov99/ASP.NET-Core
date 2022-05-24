using System.ComponentModel.DataAnnotations;

namespace MobileWorld.Core.Models.InputModels
{
    public class BaseSearchAdInputModel
    {
        public string? Make { get; set; }

        public string? TownName { get; set; }

        //public string Model { get; set; }

        [Range(0, (double)decimal.MaxValue, ErrorMessage = "Невалидна максимална цена")]
        public decimal? MaxPrice { get; set; }

        public int? Year { get; set; }

        public int? FuelType { get; set; }

        public int? GearType { get; set; }
    }
}
