using System.ComponentModel.DataAnnotations;

namespace MobileWorld.Core.Models
{
    public class UserUpdateModel
    {
       
        [Required(ErrorMessage = "Полето 'Потребителско име' не е разрешено да бъде празно!")]
        [StringLength(30,MinimumLength =3, ErrorMessage = "Полето '{0}' трябва да бъде най-малко {2} и най-много {1} знака.")]
        public string UserName { get; set; }


        [Required(ErrorMessage = "Полето 'Име' е задължително.")]
        [StringLength(40, ErrorMessage = "Полето '{0}' трябва да бъде най-малко {2} и най-много {1} знака.", MinimumLength = 3)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Полето 'Фамилия' е задължително.")]
        [StringLength(40, ErrorMessage = "Полето '{0}' трябва да бъде най-малко {2} и най-много {1} знака.", MinimumLength = 3)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Полето 'Имейл' е задължително.")]
        [EmailAddress(ErrorMessage = "Не валиден имейл адрес.")]
        public string Email { get; set; }

        [Required]
        public string Role { get; set; }
    }
}
