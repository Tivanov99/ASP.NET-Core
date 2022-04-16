using System.ComponentModel.DataAnnotations;

namespace MobileWorld.Core.Models.InputModels
{
    //TODO : Check fuel type, engines are null
    public class AdInputModel
    {
        public AdInputModel()
        {
            Car = new();
            Region = new();
            Owner = new();
            Features = new();
        }

        public string? Id { get; set; }

        [Required]
        [StringLength(50,MinimumLength =5, ErrorMessage = "Заглавието трябва да е меджу 5 и 50 символа.")]
        public string Title { get; set; }

        [Range(0, 2000000)]
        public virtual decimal Price { get; set; }

        [Required(ErrorMessage ="Полето 'Телефонен номер' е задължително!")]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(700,MinimumLength = 30, ErrorMessage = "Описанието трябва да е между 30 и 700 символа!")]
        public string Description { get; set; }

        public CarInputModel Car { get; set; } 

        public RegionInputModel Region { get; set; } 

        public OwnerModel Owner { get; set; } 

        public FeaturesModel Features { get; set; }
    }
}
