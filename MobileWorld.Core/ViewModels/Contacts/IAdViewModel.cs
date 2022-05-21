using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public CarViewModel Car { get; set; }

        public RegionViewModel Region { get; set; }

        public OwnerViewModel Owner { get; set; }

        public List<string> Images { get; set; }
    }
}
