using MobileWorld.Core.ViewModels.Contacts;

namespace MobileWorld.Core.ViewModels
{
    public class OwnerViewModel : IOwnerViewModel, IOwnerDataModel
    {
        public string OwnerId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool IsFavoriteAd { get; set; }
    }
}
