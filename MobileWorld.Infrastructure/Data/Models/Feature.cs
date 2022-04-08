using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobileWorld.Infrastructure.Data.Models
{
    public class Feature
    {
        [Key]
        public int Id { get; set; }

        public int CarId { get; set; }

        public virtual Car Car { get; set; }

        public virtual SafetyDetail SafetyDetails { get; set; } = new();

        public virtual ComfortDetail ComfortDetails { get; set; } = new();

        public virtual OthersDetail OthersDetails { get; set; } = new();

        public virtual ExteriorDetail ExteriorDetails { get; set; } = new();

        public virtual ProtectionDetail ProtectionDetails { get; set; } = new();

        public virtual InteriorDetail InteriorDetails { get; set; } = new();
    }
}
