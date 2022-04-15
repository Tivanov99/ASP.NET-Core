﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobileWorld.Core.Models
{
    public class CarModel : BaseCarModel
    {
        [Required]
        [StringLength(35)]
        public string Color { get; set; }

        [Required]
        [Range(2, 12,ErrorMessage ="Трябва да е число в диапазона от 2 до 12.")]
        public int SeatsCount { get; set; }

        [Required]
        public decimal Mileage { get; set; }

        [Required]
        public List<byte[]> Images { get; set; }

        public FeaturesModel Features { get; set; } = new();
    }
}
