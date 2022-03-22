namespace MobileWorld.Core.Models
{
    public class CreateAdModel
    {
        public string Title { get; set; }

        public int PhoneNumber { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public CarModel Car { get; set; }

        public RegionModel Region { get; set; }

        public OwnerModel Owner { get; set; } = new();
    }
}
