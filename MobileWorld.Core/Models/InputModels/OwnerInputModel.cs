using MobileWorld.Core.Models.ViewModels.Contacts;
using System.ComponentModel.DataAnnotations;

namespace MobileWorld.Core.Models.InputModels
{
    public class OwnerInputModel : IOwnerViewModel
    {
        [Required(ErrorMessage ="Полето 'Име' е задължително!")]
        [StringLength(maximumLength:50,MinimumLength =4,ErrorMessage ="Името трява е с дължина в диапазона от 4 до 50 символа!")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Полето 'Фамилия' е задължително!")]
        [StringLength(maximumLength: 50, MinimumLength = 4, ErrorMessage = "Фамилията трява е с дължина в диапазона от 4 до 50 символа!")]
        public string LastName { get; set; }
    }
}
