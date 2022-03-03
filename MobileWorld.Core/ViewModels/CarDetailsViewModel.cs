namespace MobileWorld.Core.ViewModels
{
    public class CarDetailsViewModel
    {
        public OwnerViewModel Owner { get; set; }

        public DateTime Date { get; set; }

        public string Title { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public string Location { get; set; }

        public string Transmission { get; set; }

        public string EngineType { get; set; }

        public string Color { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public int Mileage { get; set; }
    }
}
