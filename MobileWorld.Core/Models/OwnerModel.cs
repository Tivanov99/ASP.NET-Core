using System.ComponentModel.DataAnnotations;

namespace MobileWorld.Core.Models
{
    public class OwnerModel
    {
        public string OwnerId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Required]
        [Phone]
        public int PhoneNumber { get; set; }
    }
}
