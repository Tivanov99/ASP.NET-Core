using System.ComponentModel.DataAnnotations;

namespace MobileWorld.Infrastructure.Data.Models
{
    public class Town
    {
        public int Id { get; set; }

        [Required]
        [StringLength(40)]
        public string TownName { get; set; }

        public int? PostalCode { get; set; }
    }
}
