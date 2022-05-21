using MobileWorld.Core.ViewModels.Contacts;
using System.ComponentModel.DataAnnotations;

namespace MobileWorld.Core.Models.InputModels
{
    public class RegionInputModel : IRegionViewModel
    {
        [StringLength(70,ErrorMessage ="Полето 'Регион' трябва е не по-дълго от 70 символа!")]
        public string? RegionName { get; set; }

        [StringLength(70, ErrorMessage = "Полето 'Квартал' трябва е не по-дълго от 70 символа!")]
        public string? Neiborhood { get; set; }

        [Required( ErrorMessage = "Полето 'Локация' трябва е не по-дълго от 70 символа!")]
        public string TownName { get; set; }
    }
}
