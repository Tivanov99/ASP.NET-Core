namespace MobileWorld.Core.ViewModels
{
    public class AdViewModel
    {
        public AdViewModel()
        {
            Car = new CarViewModel();
        }

        public string Id { get; set; }

        public string Title { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime CreatedOn { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public CarViewModel Car { get; set; }

        //public RegionModel Region { get; set; }

        //public OwnerModel Owner { get; set; }

        //public List<ImageDTO> Images { get; set; }
    }
}
