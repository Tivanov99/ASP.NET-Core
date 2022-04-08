using MobileWorld.Infrastructure.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace MobileWorld.Infrastructure.Data.Models
{
    public class Car
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        [DataType("Nvarchar")]
        public string Make { get; set; }

        [Required]
        [StringLength(20)]
        [DataType("Nvarchar")]
        public string Model { get; set; }

        [Range(1886, 2022)]
        [Required]
        public int Year { get; set; }

        [Required]
        public GearType GearType { get; set; }

        [Required]
        [StringLength(35)]
        [DataType("Nvarchar")]
        public string Color { get; set; }

        public virtual Engine Engine { get; set; }

        [Required]
        [Range(2, 12)]
        public int SeatsCount { get; set; }

        [Required]
        public decimal Mileage { get; set; }

        public virtual Feature Feature { get; set; }

        public string AdId { get; set; }

        public virtual Ad Ad { get; set; }
    }
}
