namespace MobileWorld.Core.Models.Contracts
{
    public interface IOwnerModel
    {
        public string OwnerId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool IsFavoriteAd { get; set; }
    }
}
