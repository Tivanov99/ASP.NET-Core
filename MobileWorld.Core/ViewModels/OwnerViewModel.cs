using MobileWorld.Core.Models.Contracts;

namespace MobileWorld.Core.ViewModels
{
    public class OwnerViewModel :IOwnerModel
    {
        public string OwnerId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool IsFavoriteAd { get; set; }
    }
}
