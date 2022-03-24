using System.ComponentModel.DataAnnotations;

namespace MobileWorld.Core.Models
{
    public class TownModel
    {
        [Required]
        [StringLength(40)]
        public string Name { get; set; }

        public int? PostalCode { get; set; }
    }
}
