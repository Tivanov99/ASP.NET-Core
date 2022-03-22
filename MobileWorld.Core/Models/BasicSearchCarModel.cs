using MobileWorld.Core.Models;

namespace MobileWorld.Core.ViewModels.CarViewModels
{
    public class BasicSearchCarModel
    {
        public CarModel Car { get; set; }

        public RegionModel Region { get; set; }

        public decimal Price { get; set; }

        public decimal? MaxPrice { get; set; }

        public int? FromYear { get; set; }

        //public int? ToYear { get; set; }

        public int? MinHorsePower { get; set; }


    }
}
