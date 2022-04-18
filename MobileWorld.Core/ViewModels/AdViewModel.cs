using MobileWorld.Core.Dto;
using MobileWorld.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace MobileWorld.Core.ViewModels
{
    public class AdViewModel
    {
        public AdViewModel()
        {
            Images = new();
        }

        public string Id { get; set; }

        public string Title { get; set; }

        public string PhoneNumber { get; set; }

        public CarModel Car { get; set; }

        public RegionModel Region { get; set; }

        public string CreatedOn { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public OwnerModel Owner { get; set; }

        public List<ImageDTO> Images { get; set; }
    }
}
