﻿using MobileWorld.Infrastructure.Data.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobileWorld.Infrastructure.Data.Models
{
    public class Ad
    {
        [Key]
        public string Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        //[ForeignKey(nameof(Car))]
        //public int CarId { get; set; }

        public virtual Car Car { get; set; } 

        [Required]
        [ForeignKey(nameof(Region))]
        public int RegionId { get; set; }

        public Region Region { get; set; }

        [Required]
        [DataType("datetime2")]
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        [Required]
        public decimal Price { get; set; }

        [Required]
        [MaxLength(700)]
        [Column(TypeName = "varchar(700)")]
        public string Description { get; set; }

        public string OwnerId { get; set; }

        public ApplicationUser Owner { get; set; }

        public List<FavoriteAd> Fans { get; set; } = new();

        public List<Image> Images { get; set; } = new();
    }
}
