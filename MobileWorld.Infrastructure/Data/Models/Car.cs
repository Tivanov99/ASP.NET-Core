using MobileWorld.Infrastructure.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobileWorld.Infrastructure.Data.Models
{
    public class Car
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Model { get; set; }

        [Range(1886, 2022)]
        [Required]
        public int Year { get; set; }

        public DateTime CarDate { get; set; }

        [Required]
        public GearType GearType { get; set; }

        [Required]
        [StringLength(35)]
        public string Color { get; set; }

        [Required]
        [StringLength(30)]
        public string Make { get; set; }

        [ForeignKey(nameof(Engine))]
        public int EngineId { get; set; }

        public virtual Engine Engine { get; set; }

        [Required]
        [Range(2, 12)]
        public int SeatsCount { get; set; }

        [Required]
        [Column(TypeName = "decimal(6,3)")]
        public decimal Mileage { get; set; }

        //public FeaturesModel MyProperty { get; set; }
    }
}
