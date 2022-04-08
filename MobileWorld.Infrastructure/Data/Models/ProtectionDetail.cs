using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobileWorld.Infrastructure.Data.Models
{
    public class ProtectionDetail
    {
        [Key]
        public int Id { get; set; }

        public int FeatureId { get; set; }

        public Feature Feature { get; set; }
        public bool Alarm { get; set; }

        public bool Armored { get; set; }

        public bool Immobilizer { get; set; }

        public bool Casco { get; set; }

        public bool CentralLocking { get; set; }
    }
}
