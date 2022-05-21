using MobileWorld.Core.ViewModels;
using MobileWorld.Core.ViewModels.Contacts;
using System.ComponentModel.DataAnnotations;

namespace MobileWorld.Core.Models.InputModels
{
    //TODO : Check fuel type, engines are null
    public class AdInputModel : IAdInputModel
    {
        public AdInputModel()
        {
            Car = new CarInputModel();
            Region = new RegionInputModel();
            Owner = new OwnerInputModel();
            Features = new FeatureViewModel();
            Images = new();
        }
        public string Id { get; set; }
        public DateTime CreatedOn { get; set; }

        [Required(ErrorMessage = "Полето 'Заглавие' е задължително!")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Заглавието трябва да е меджу 5 и 50 символа.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Полето 'Цена' е задължително!")]
        [Range(0, 2000000, ErrorMessage = "Цената трябва да е в диапазона между 0 и 2000000!")]
        public virtual decimal Price { get; set; }

        [Required(ErrorMessage = "Полето 'Телефонен номер' е задължително!")]
        [Phone(ErrorMessage = "Невалиден телефонен номер!")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Полето 'Описание' е задължително!")]
        [StringLength(700, MinimumLength = 30, ErrorMessage = "Описанието трябва да е в диапазона между 30 и 700 символа!")]
        public string Description { get; set; }

        public ICarViewModel Car { get; set; }

        public IRegionViewModel Region { get; set; }

        public IOwnerViewModel Owner { get; set; }

        public IFeatureViewModel Features { get; set; }

        public List<string> Images { get; set; }
    }
}
