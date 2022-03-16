using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobileWorld.Infrastructure.Data.Models
{
    public class Region
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Town))]
        public int TownId { get; set; }

        public Town Town { get; set; }

        [Required]
        [StringLength(50)]
        public string RegionName { get; set; }


        [Required]
        [StringLength(40)]
        public string Neiborhood { get; set; }
    }
}
