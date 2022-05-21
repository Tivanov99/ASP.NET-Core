using MobileWorld.Core.Models.Contracts;

namespace MobileWorld.Core.ViewModels.Contacts
{
    public interface IAdViewModel
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime CreatedOn { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public ICarViewModel Car { get; set; }

        public IRegionViewModel Region { get; set; }

        public IOwnerViewModel Owner { get; set; }

        public List<string> Images { get; set; }
    }
}
