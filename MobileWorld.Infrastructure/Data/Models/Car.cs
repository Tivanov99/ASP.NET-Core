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
        public string Model { get; set; }

        [Range(1886,2022)]
        [Required]
        public int Year { get; set; }

        public int MyProperty { get; set; }

        [Required]
        public GearType GetType { get; set; }

        public string Color { get; set; }

        public string Make { get; set; }

        [ForeignKey(nameof(Engine))]
        public int EngineId { get; set; }

        public Engine Engine { get; set; }

        [Required]
        public int SeatsCount { get; set; }

        [Required]
        [Range(0,(double)decimal.MaxValue)]
        public decimal Mileage { get; set; }
    }
}
