using System.ComponentModel.DataAnnotations;

namespace MobileWorld.Core.ViewModels.UserModels
{
    public class RegisterModel
    {
        [StringLength(20, MinimumLength = 5, ErrorMessage = "{0} must be between {2} and {1} characters.")]
        public string Username { get; set; }

        [EmailAddress(ErrorMessage = "Email must be valid email.")]
        public string Email { get; set; }

        [StringLength(20, MinimumLength = 6, ErrorMessage = "{0} must be between {2} and {1} characters.")]
        public string Password { get; set; }

        [Compare(nameof(Password), ErrorMessage = "Password and ConfirmPassword must be equal.")]
        public string ConfirmPassword { get; set; }
    }
}
