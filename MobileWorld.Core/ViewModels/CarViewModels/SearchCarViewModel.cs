namespace MobileWorld.Core.ViewModels.CarViewModels
{
    public class SearchCarViewModel : CarFullInfoViewModel
    {
        public decimal? MaxPrice { get; set; }

        public int? AfterYear { get; set; }

        public int? BeforeYear { get; set; }

        public int? MinHorsePower { get; set; }
    }
}
