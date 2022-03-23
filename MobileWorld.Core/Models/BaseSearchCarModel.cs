namespace MobileWorld.Core.Models
{
    public class BaseSearchCarModel
    {
        public CarModel Car { get; set; } = new();

        public RegionModel Region { get; set; } = new();

        public decimal Price { get; set; }

        public decimal? MaxPrice { get; set; }

        public int? FromYear { get; set; }

        //public int? ToYear { get; set; }

        public int? MinHorsePower { get; set; }
    }
}
