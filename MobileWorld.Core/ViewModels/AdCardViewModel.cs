using MobileWorld.Infrastructure.Data.Models;

namespace MobileWorld.Core.ViewModels
{
    public class AdCardViewModel
    {
        public string AdId { get; set; }

        public string Title { get; set; }

        public string Url { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string Image { get; set; }

        //TODO : Add property for date of creating ad
    }
}
