using MobileWorld.Core.ViewModels.Contacts;
using MobileWorld.Infrastructure.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace MobileWorld.Core.Models
{
    public class EngineModel : IEngineViewModel 
    {
        [Required]
        public FuelType FuelType { get; set; }

        [Required]
        [Range(40, 2000, ErrorMessage = "Полето 'Конски сили' трябва да са в диапазона от 0 до 2000")]
        public int HorsePower { get; set; }

        [Range(100, 2000, ErrorMessage = "Полето 'Нютон-метъри' трябва да са в диапазона от 100 до 2000")]
        public int? NewtonMeter { get; set; }

        public bool Hybrid { get; set; }

        [Required]
        [Range(1, 7,ErrorMessage = "Полето 'Евро' трябва да са в диапазона от 1 до 7")]
        public int EcoLevel { get; set; }

        public bool AutoGas { get; set; }

        [Required]
        [Range(900, 9000, ErrorMessage = "Полето 'Кубични сантиметри' трябва да са в диапазона от 900 до 9000")]
        public int CubicCapacity { get; set; }

        [Required]
        [Range(3, 100, ErrorMessage = "Полето 'Среден разход на гориво' трябва да са в диапазона от 3 до 100")]
        public double FuelConsuption { get; set; }
    }
}
