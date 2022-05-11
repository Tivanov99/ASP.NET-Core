using MobileWorld.Infrastructure.Data.Enums;
using MobileWorld.Infrastructure.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace MobileWorld.Core.Models.InputModels
{
    public class CarInputModel
    {
        public CarInputModel()
        {
            //Images = new();
        }

        [Required(ErrorMessage = "Полето 'Марка' е задължително!")]
        public string Make { get; set; }

        //[Required]
        //[StringLength(20)]
        //public string Model { get; set; }

        [Range(1886, 2022, ErrorMessage = "Годината трябва да е в диапазона от 1886 до 2022")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Полето 'Скоростна кутия' е задължително!")]
        public GearType GearType { get; set; }

        public EngineModel Engine { get; set; }

        [Required(ErrorMessage = "Полето 'Цвят' е задължително!")]
        [StringLength(35,MinimumLength =3, ErrorMessage ="Цветът трябва е с дължина от 3 до 35 символа!")]
        public string Color { get; set; }

        [Required]
        [Range(2, 12, ErrorMessage = "Полето 'Брой пасажерски места' трябва да е число в диапазона от 2 до 12.")]
        public int SeatsCount { get; set; }

        [Required(ErrorMessage = "Полето 'Пробег' е задължително!")]
        [Range(0,double.MaxValue, ErrorMessage = "Пробегът трябва да е в диапазона от 0 до {2}")]
        public decimal Mileage { get; set; }

        //public List<Image> Images { get; set; }
    }
}
