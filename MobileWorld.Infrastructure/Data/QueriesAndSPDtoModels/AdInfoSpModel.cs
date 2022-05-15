namespace MobileWorld.Infrastructure.Data.QueriesAndSPDtoModels
{
    public class AdInfoSpModel
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime CreatedOn { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string RegionName { get; set; }

        public string Neiborhood { get; set; }

        public string TownName { get; set; }

        public string OwnerId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool IsFavoriteAd { get; set; }
    }
}
