using System.ComponentModel.DataAnnotations;

namespace MobileWorld.Core.ViewModels
{
    public class LoginModel
    {
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Invalid {0}.")]
        public string Username { get; set; }

        [StringLength(20, MinimumLength = 6, ErrorMessage = "Invalid {0}.")]
        public string Password { get; set; }
    }
}
