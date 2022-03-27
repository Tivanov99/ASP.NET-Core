﻿
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobileWorld.Core.Models
{

    //TODO : Check fuel type, engines are null
    public class CreateAdModel
    {
        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [Required]
        [Phone]
        public int PhoneNumber { get; set; }

        [Column(TypeName = "decimal(6,2)")]
        public decimal Price { get; set; }

        [Required]
        [MaxLength(700)]
        public string Description { get; set; }

        public string TownName { get; set; }

        public CarModel Car { get; set; }

        public RegionModel Region { get; set; }

        public OwnerModel Owner { get; set; } = new();
    }
}
